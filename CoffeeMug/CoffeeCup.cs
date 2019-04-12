using System;

namespace CoffeeMug
{
    public class CoffeeCup : Container
    {
        public CoffeeCup()
        {
        }

        public void Drink()
        {
            Console.Out.WriteLine("Drinking coffee...");
            System.Threading.Thread.Sleep(1000);
            Empty(true);
            Console.Out.WriteLine("Finished drinking coffee.");
        }

        public void Refill()
        {
            Console.Out.WriteLine("Refilling coffee cup...");
            System.Threading.Thread.Sleep(1000);
            Empty(false);
            Console.Out.WriteLine("Coffee cup is full.");
        }
    }
}
