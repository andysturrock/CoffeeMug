using System;

namespace CoffeeMug
{
    public class WorkTask
    {
        private int work = 10;
        private Random random = new Random();

        public WorkTask()
        {
            Console.Out.WriteLine($"There are {work} bits of work to do - let's get going!");
        }

        public bool Done()
        {
            return work <= 0;
        }

        public void Execute()
        {
            Console.Out.WriteLine("Working...");
            // Do a random amount of work
            work -= random.Next(1, 5);
            System.Threading.Thread.Sleep(1000);
            Console.Out.WriteLine($"Stopping work for now - {work} bits of work left");
        }
    }
}