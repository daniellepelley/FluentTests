using System;
using System.Linq.Expressions;
using System.Reflection;
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

        public SpecWhen<dynamic> Stub()
        {
            Assert.Inconclusive("Tested stubbed out");
            return new SpecWhen<dynamic>(new {});
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

        public ThenValue<TSut, TValue> Then<TValue>(Func<TSut, TValue> action)
        {
            return new ThenValue<TSut, TValue>(
                new SpecThen<TSut>(_sut),
                action(_sut));
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
        private SpecThen<TSut> _specThen;
        private TValue _value1;

        public ThenValue(SpecThen<TSut> specThen, TValue value1)
        {
            _value1 = value1;
            _specThen = specThen;
        }

        public SpecThen<TSut> IsEqualTo(TValue value)
        {
            Assert.AreEqual(_value1, value);
            return _specThen;
        }

        public SpecThen<TSut> IsNotEqualTo(TValue value)
        {
            Assert.AreNotEqual(_value1, value);
            return _specThen;
        }

    }



    public static class Spec
    {
        public static SpecWhen When(string className)
        {
            Assert.Fail(className + " not implemented");
            return new SpecWhen(new {});
        }
    }


    public class SpecWhen
    {
        internal readonly dynamic _sut;

        public SpecWhen(dynamic sut)
        {
            _sut = sut;
        }

        public SpecWhenAnd<dynamic> When(Action<dynamic> action)
        {
            return new SpecWhenAnd<dynamic>(_sut);
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

        public SpecThen<dynamic> Then()
        {
            return new SpecThen<dynamic>(_sut);
        }
    }


}