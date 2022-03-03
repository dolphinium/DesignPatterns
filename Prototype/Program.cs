using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer
            {
                FirstName = "Yunus Emre",
                LastName = "KORKMAZ",
                City = "Eskişehir",
                Id = 1
            };
           

            Customer customer2 = (Customer) customer.Clone();       // Type Casting on Clone Operation
            customer2.FirstName = "Yusuf";

            Console.WriteLine(customer.FirstName);          // output = Yunus Emre 
            Console.WriteLine(customer2.FirstName);         // output = Yusuf 


            Console.ReadLine();

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    

    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();      // Create a shallow copy of Person
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();      // Create a shallow copy of Person
        }
    }
}
