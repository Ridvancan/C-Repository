using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesign
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
       public void UpdatePrice()
        {
            Console.WriteLine("Updated!");
            Notify();
        }

        public void Attach(Observer observers)
        {
            _observers.Add(observers);
        }
        public void Detach(Observer observers)
        {
            _observers.Remove(observers);
        }
        private void Notify()
        {
            foreach (var obs in _observers)
            {
                obs.Update();
            }
        }

    }
    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Product Price Reduced!!!");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Salaries will increase!!!");
        }
    }
}
