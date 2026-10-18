using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Option
    {
        public ConsoleKey key;
        public string title;
        public Action action;
      
        public void Run()
        {
            action?.Invoke();
        }
    }
}
