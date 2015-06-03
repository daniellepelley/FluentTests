using System;

namespace SutBuilder
{
    public class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
        { }        

        public ConstructorNotFoundException(string message)
            :base(message)
        { }
    }
}