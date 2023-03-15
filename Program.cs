using System;
using System.Collections;

namespace Console_Class
{
    class Person
    {
        public string Name { get; set; }
        public Person(string name) : base()
        {
            Name = name;
        }
        public void Print()
        {
            Console.WriteLine($"Person {Name}");
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    class Employee : Person
    {
        public string Company { get; set; }
        public Employee(string name, string company) : base(name)
        {
            Company = company;
        }
    }

    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, string bank) : base(name)
        {
            Bank = bank;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //оператор as
            //Person person = new Person("Tom");
            //Employee employee = person as Employee;
            //if (employee == null)
            //{
            //    Console.WriteLine("Преобразование прошло неудачно");
            //}
            //else { employee.Print(); }

            //оператор is
            Person person2 = new Person("Tom");
            if (person2 is Employee employee )
            {
                Console.WriteLine(employee.Name);
            }

            else
            {
                Console.WriteLine("Преобразование не допустимо");
            }


            Employee employee1 = new Employee("Dron","Nargus");

            if (employee1 is Person person3)
            {
                person3.Print();
            }
        }
    }
}
