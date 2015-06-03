using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace SutBuilder.Moq
{
    public class MoqFactory<T>
        : IFactory<T>
        where T : class
    {
        public T Create()
        {
            return new Mock<T>().Object;
        }
    }
}
