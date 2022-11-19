using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting
{
    static class Something
    {
        public static void DoSomething(int i)
        {
            if (i == 1)
                throw new NotImplementedException();
            else
                Console.WriteLine("doing something");
        }

        public static void Sleep()
        {
            Thread.Sleep(1000);
        }

        
    }
}
