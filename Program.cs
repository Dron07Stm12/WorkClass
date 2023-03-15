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
            //Восходящие преобразования. Upcasting
            //Объекты производного типа (который находится внизу иерархии) в то же время представляют
            //и базовый тип. Например, объект Employee в то же время является и объектом класса Person. 
            Employee employee = new Employee("Tom", "Microsoft");
            Person person = employee;
            Console.WriteLine(Equals(person,employee));// указывает на один и тотже обьект
            //В данном случае переменной person, которая представляет тип Person, присваивается ссылка на
            //объект Employee. Но чтобы сохранить ссылку на объект одного класса в переменную другого класса,
            //необходимо выполнить преобразование типов - в данном случае от типа Employee к типу Person.
            //И так как Employee наследуется от класса Person, то автоматически выполняется неявное
            //восходящее преобразование - преобразование к типу, которые находятся вверху иерархии классов,
            //то есть к базовому классу.

            //В итоге переменные employee и person будут указывать на один и тот же объект в памяти,
            //но переменной person будет доступна только та часть, которая представляет функционал типа Person.

            Console.WriteLine(person.Name +" works of"+ employee.Company);

            //происходит неявное восходящее преобразование
            Person person1 = new Client("Dron","CrediAg");
            Console.WriteLine(person1.Name.GetHashCode());


        }
    }
}
