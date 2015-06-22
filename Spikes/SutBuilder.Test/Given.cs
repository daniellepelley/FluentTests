using FluentTests.Core;

namespace SutBuilder.Test
{
    public class Given<TSut> : IGiven<TSut>
        where TSut : class 
    { }
}