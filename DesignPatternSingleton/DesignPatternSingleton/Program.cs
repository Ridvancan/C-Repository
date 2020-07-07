using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customermanager =CustomerManager.CreatNew();
        }

        class CustomerManager
        {
            private static CustomerManager _customerManager;
            static object _lockObject = new object();
            private CustomerManager()
            {

            }
            public static CustomerManager CreatNew()
            {
                lock (_lockObject)//Kilit Sistemi Thread Safe.
                { 
                    if (_customerManager == null)
                {

                    _customerManager = new CustomerManager();
                }
                return _customerManager;
                }

            }
        }
    }
}
