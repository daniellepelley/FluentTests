using System;
using System.Linq.Expressions;
using System.Text;
using NUnit.Framework;

namespace AAATester.Spec
{
    public static class Extensions
    {
        public static SpecMethod<TSut> Method<TSut, TFunc>(this SpecWhen<TSut> source, Func<TSut, TFunc> func)
            where TFunc : LambdaExpression
        {
            var method = func(source._sut);

            return new SpecMethod<TSut>(method);
        }

        //public static SpecWhenAnd<TSut> When<TSut>(this TSut sut, params Expression<Action<TSut>>[] actions)
        //{
        //    foreach (var expression in actions)
        //    {
        //        var methodCallExp = (MethodCallExpression)expression.Body;
        //        var methodName = methodCallExp.Method.Name;

        //        var action = expression.Compile();

        //        action(sut);
        //    }
        //    return new SpecWhenAnd<TSut>(sut);
        //}
    }

    public class SpecMethod<TSut>
    {
        private LambdaExpression _lambdaExpression;
        private object[] _parameters;

        public SpecMethod(LambdaExpression lambdaExpression)
        {
            _lambdaExpression = lambdaExpression;
            var methodName = NameFromExpression(lambdaExpression);
        }

        public SpecMethodParameters<TSut> WithParameters(params object[] parameters)
        {
            _parameters = parameters;
            return new SpecMethodParameters<TSut>(_lambdaExpression, parameters);
        }

        private static string NameFromExpression(LambdaExpression expression)
        {
            var callExpression =
                expression.Body as MethodCallExpression;

            if (callExpression == null)
            {
                throw new Exception("expression must be a MethodCallExpression");
            }

            return callExpression.Method.Name;
        }
    }

    public class SpecMethodParameters<TSut>
    {
        private LambdaExpression _lambdaExpression;
        private object[] _parameters;

        public SpecMethodParameters(LambdaExpression lambdaExpression, object[] parameters)
        {
            _parameters = parameters;
            _lambdaExpression = lambdaExpression;
            var methodName = NameFromExpression(lambdaExpression);
        }

        private static string NameFromExpression(LambdaExpression expression)
        {
            var callExpression =
                expression.Body as MethodCallExpression;

            if (callExpression == null)
            {
                throw new Exception("expression must be a MethodCallExpression");
            }

            return callExpression.Method.Name;
        }

        public object Execute()
        {
            var m = _lambdaExpression.Compile(); 
            return m.DynamicInvoke(_parameters);
        }

        public void Returns(object value)
        {
            Assert.AreEqual(value, Execute());
        }
    }

    public class SpecWhen<TSut>
    {

        internal readonly TSut _sut;

        public SpecWhen(TSut sut)
        {
            _sut = sut;
        }

        public SpecWhenAnd<TSut> When(params Expression<Action<TSut>>[] actions)
        {
            foreach (var expression in actions)
            {
                var methodCallExp = (MethodCallExpression)expression.Body;
                var methodName = methodCallExp.Method.Name;

                foreach (var argument in methodCallExp.Arguments)
                {
                    var lambda = Expression.Lambda(argument);
                    var val = lambda.Compile().DynamicInvoke().ToString();


                    var description = GetDescription(methodName, val);
                    Console.WriteLine(description);
                }

                var action = expression.Compile();

                action(_sut);
            }
            return new SpecWhenAnd<TSut>(_sut);
        }

        private string GetDescription(string methodName, string value)
        {
            var sb = new StringBuilder();

            foreach (char c in methodName)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
            }

            return "When " + sb.ToString().Trim() + " '" + value + "'";
        }

        public SpecThen<TSut> Then()
        {
            return new SpecThen<TSut>(_sut);
        }
    }

    public class SpecWhenAnd<TSut>
    {
        private readonly TSut _sut;

        public SpecWhenAnd(TSut sut)
        {
            _sut = sut;
        }

        public SpecWhenAnd<TSut> And(params Action<TSut>[] actions)
        {
            foreach (var action in actions)
            {
                action(_sut);
            }
            return this;
        }

        public SpecThen<TSut> Then()
        {
            return new SpecThen<TSut>(_sut);
        }

        private string GetDescription(string methodName, string value)
        {
            var sb = new StringBuilder();

            foreach (char c in methodName)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
            }

            return "Then " + sb.ToString().Trim() + " '" + value + "'";
        }

        public ThenValue<TSut, TValue> Then<TValue>(Expression<Func<TSut, TValue>> expression)
        {
            var methodCallExp = (MemberExpression) expression.Body;
            var methodName = methodCallExp.Member.Name;
            Console.WriteLine("Then " + methodName);

            return new ThenValue<TSut, TValue>(
                new SpecThen<TSut>(_sut),
                expression.Compile()(_sut));
        }


        public SpecThenAre<TSut, TValue> ThenValues<TValue>(Func<TSut, TValue> action, TValue value)
        {
            return new SpecThenAre<TSut, TValue>(
                new SpecThen<TSut>(_sut),
                action(_sut),
                value);
        }
    }

    public class ThenValue<TSut, TValue>
    {
        private readonly SpecThen<TSut> _specThen;
        private readonly TValue _value1;

        public ThenValue(SpecThen<TSut> specThen, TValue value1)
        {
            _value1 = value1;
            _specThen = specThen;
        }

        public SpecThen<TSut> IsEqualTo(TValue value)
        {
            Console.WriteLine("Is Equal To '" + value + "'");
            Assert.AreEqual(_value1, value);
            return _specThen;
        }

        public SpecThen<TSut> IsNotEqualTo(TValue value)
        {
            Console.WriteLine("Is Not Equal To '" + value + "'");
            Assert.AreNotEqual(_value1, value);
            return _specThen;
        }

    }
}