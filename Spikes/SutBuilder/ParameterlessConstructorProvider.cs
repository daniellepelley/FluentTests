using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ParameterlessConstructorProvider
        : IConstructorProvider
    {
        public ConstructorInfo Get<T>()
            where T : class
        {
            var constructorInfo = typeof(T)
                .GetConstructors()
                .FirstOrDefault(x => !x.GetParameters().Any());

            if (constructorInfo == null)
            {
                throw new ConstructorNotFoundException("No parameterless constructor found");
            }
            return constructorInfo;
        }
    }
}