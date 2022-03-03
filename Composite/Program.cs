using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee yunus = new Employee {Name = "Yunus Emre KORKMAZ"};
            Employee yusuf = new Employee { Name = "Yusuf KORKMAZ" };
            Employee tuncer = new Employee { Name = "Tuncer KORKMAZ" };
            Employee taner = new Employee { Name = "Taner KORKMAZ" };
            Employee sinan = new Employee { Name = "Sinan KORKMAZ" };
            taner.AddSubordinate(yunus);
            taner.AddSubordinate(yusuf);
            tuncer.AddSubordinate(sinan);
            taner.AddSubordinate(tuncer);
            
            
            Console.WriteLine(taner.Name);
            foreach (Employee father in taner)
            {
                Console.WriteLine("  {0}",father.Name);
                foreach (Employee siblings in father)
                {
                    Console.WriteLine("    {0}", siblings.Name);
                }
            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }

    }

    class Contributor:IPerson
    {
        public string Name { get; set; }
    }

    class Employee:IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
