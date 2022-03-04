using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager
            {
                Name = "Emre",
                Salary = 14000
            };
            Manager manager2 = new Manager
            {
                Name = "Sinem",
                Salary = 16000
            };
            Worker worker = new Worker
            {
                Name = "Yusuf",
                Salary = 13000
            };
            Worker worker2 = new Worker
            {
                Name = "Ali",
                Salary = 12500
            };

            manager.SubOrdinates.Add(manager2);
            manager2.SubOrdinates.Add(worker);
            manager2.SubOrdinates.Add(worker2);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(manager);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payRiseVisitor);

            Console.ReadLine();


        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase Employee;

        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    class Manager: EmployeeBase
    {
        public Manager()
        {
            SubOrdinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> SubOrdinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in SubOrdinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker: EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrollVisitor:VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class PayRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0}'s salary increased to {1}", worker.Name, worker.Salary*(decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0}'s salary increased to {1}", manager.Name, manager.Salary * (decimal)1.14);
        }
    }
}
