using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();      // we can not create a customer manager object via CustomerManager customerManager = new CustomerManager(); 
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager; // create static field for object
        static object _lockObject = new object();

        private CustomerManager() // initialize a private constructor
        {
        }

        public static CustomerManager
            CreateAsSingleton() 
        {
            lock (_lockObject)          // Thread safe singleton pattern
            {
                if (_customerManager == null)           // if customer manager instance didn't creating yet, create a instance
                {
                    _customerManager = new CustomerManager();           
                }
            }

            return _customerManager;
        }


        public void Save() // if we use static we can not reach the save operation via instance of customer manager!
        {
            Console.WriteLine("Saved!");
        }

    }
}
