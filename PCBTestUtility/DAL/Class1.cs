using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microstar.Production.PCBTest.DAL
{
    public class Class1
    {
        public delegate void Fly(int a);

        public void Engine()
        {
            Fly fly = (int c) =>
                {
                    Console.Write("{0}", c);
                };

            fly(4);
        }

        public void Sum(int c)
        {

        }
    }
}
