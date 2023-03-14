using System;

namespace Console_Class
{

    class Person
    {
      /*public*/  string name;
      /*public*/  int age;

        public Person(string name) : base()
        {
            this.name = name;
            Console.WriteLine("Person(string name)" + this.name);
        }
        public Person(string name, int age) :this(name) 
        {
            this.age = age;
            Console.WriteLine("Person(string name, int age)" + name + this.age);
        }
    }

    class Employee : Person
    {
        string company;

        public Employee(string name, int age, string company) : base(name, age)
        {
            this.company = company;
            Console.WriteLine("Employee(string name, int age, string company)"+ name + age + company);
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Employee tom = new Employee("Tom", 22, "Microsoft");
        }
    }
}
