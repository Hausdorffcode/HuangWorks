using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuangWeb.Middlewares
{
    public class MyMiddlewareConfigOption
    {
        private string _name = "";
        public MyMiddlewareConfigOption(string name)
        {
            _name = name;
        }

        public string GetMessage()
        {
            return $"{_name},你好！";
        }
    }
}
