using System;

namespace SutBuilder
{
    public interface IDependencyResolver
    {
        object Resolve(Type type);
    }
}