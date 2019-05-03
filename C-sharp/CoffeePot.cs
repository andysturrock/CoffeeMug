using System;

namespace CoffeeMug
{
    public class CoffeePot : IContainer
    {
        // The number of cups of coffee this pot contains when full
        private int maxNumberOfCups = 3;
        // The number of cups of coffee this pot contains right now
        private int currentNumberOfCups;

        public CoffeePot()
        {
            currentNumberOfCups = maxNumberOfCups;
        }

        public bool Empty()
        {
            return currentNumberOfCups == 0;
        }

        public void Make()
        {
            Console.Out.WriteLine("Making coffee...");
            System.Threading.Thread.Sleep(1000);
            currentNumberOfCups = maxNumberOfCups;
            Console.Out.WriteLine("CoffePot is now full");
        }

        public void PourCup()
        {
            --currentNumberOfCups;
        }
    }
}