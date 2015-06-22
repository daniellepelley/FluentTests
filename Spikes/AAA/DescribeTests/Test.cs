using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DescribeTests
{
    public class Tests : TestBase
    {
        string str = "Yes";

        public Tests()
        {
            It["This is no"] = () =>
            {
                str = "No";
            };

            It["This is yes"] =
                () =>
                { 
                    str = "Yes";
                };
        }

        [Test]
        public void Test1()
        {
            Run("This is yes",
                "This is no");

            Assert.AreEqual("No", str);
        }
    }
}
