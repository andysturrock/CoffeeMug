using System;

namespace CoffeeMug
{
    public class CoffeePot : Container
    {
        public CoffeePot()
        {
        }

        public void Make()
        {
            Console.Out.WriteLine("Making coffee...");
            System.Threading.Thread.Sleep(1000);
            Empty(false);
            Console.Out.WriteLine("CoffePot is now full");
        }
    }
}