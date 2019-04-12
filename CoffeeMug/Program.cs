using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMug;

namespace CoffeeMug
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeCup = new CoffeeCup();
            var coffeePot = new CoffeePot();
            var workTask = new WorkTask();
            do
            {
                coffeeCup.Drink();
                workTask.Execute();
                if (coffeeCup.Empty())
                {
                    if (coffeePot.Empty())
                        coffeePot.Make();
                    coffeeCup.Refill();
                }
            } while (!workTask.Done());
        }
    }
}
