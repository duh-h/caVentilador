using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caVentilador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            stack.TrocaDePeca("a", "a1");


        }
    }
}
