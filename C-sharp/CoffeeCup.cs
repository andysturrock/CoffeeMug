using System;

namespace CoffeeMug
{
    public class CoffeeCup : IContainer
    {
        private CoffeePot coffeePot;

        public CoffeeCup(CoffeePot coffeePot)
        {
            this.coffeePot = coffeePot;
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
            coffeePot.PourCup();
            Empty(false);
            Console.Out.WriteLine("Coffee cup is full.");
        }

        // This is better C# but you can't call a property
        //public bool Empty { get; private set; }
        private bool empty = true;
        public bool Empty()
        {
            return empty;
        }

        protected void Empty(bool empty)
        {
            this.empty = empty;
        }
    }
}
