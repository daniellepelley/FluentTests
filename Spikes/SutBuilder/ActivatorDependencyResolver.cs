using System;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ActivatorDependencyResolver : IDependencyResolver
    {
        public object Resolve(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}