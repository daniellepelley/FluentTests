using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescribeTests
{
    public class ActionResult
    {
        private Dictionary<string, Action> _actions = new Dictionary<string, Action>();

        public Action this[string index]
        {
            get { return _actions[index]; }
            set { _actions.Add(index, value); }
        }
    }
}
