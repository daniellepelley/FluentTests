using System;

namespace SutBuilder.Interfaces
{
    public interface IDependencyResolver
    {
        object Resolve(Type type);
    }
}