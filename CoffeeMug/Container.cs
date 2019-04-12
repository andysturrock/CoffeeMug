using System;

namespace CoffeeMug
{
    public class Container
    {
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