using System;

namespace FluentTests
{
    public class SutBuilder<TSut>
        : ISutBuilder<TSut>
    {
        public TSut Build()
        {
            return Activator.CreateInstance<TSut>();
        }
    }
}
