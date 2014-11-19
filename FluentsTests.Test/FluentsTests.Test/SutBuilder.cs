using System;

namespace FluentsTests.Test
{
    public class SutBuilder<TSut> : ISutBuilder<TSut>
    {
        public TSut Build()
        {
            return Activator.CreateInstance<TSut>();
        }
    }
}