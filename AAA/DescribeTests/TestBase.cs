using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescribeTests
{
    public class TestBase
    {
        private readonly ActionResult _it = new ActionResult();

        public ActionResult It
        {
            get { return _it; }
        }

        public void Run(params string[] strings)
        {
            foreach (var str in strings)
            {
                It[str]();
            }
        }
    }
}
