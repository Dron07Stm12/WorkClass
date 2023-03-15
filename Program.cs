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
            //Восходящие преобразования. Upcasting(от производного к базовому)


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

            //происходит неявное восходящее преобразование(потомучто Client производный от Person), но видимость или доступ
            //ссылки person1  будет только к функционалу базового класса т.е. к классу Person
            Person person1 = new Client("Dron","CrediAg");
            Console.WriteLine(person1.Name);


            object obj = new Client("Bob", "ContosoBank");  // от Client к object
            Console.WriteLine(((Client)obj).Name + " works " + ((Client)obj).Bank);


            //Нисходящие преобразования. Downcasting(от  базовому  к производного)


            //вопрос, можно ли обратиться к функционалу типа Employee через переменную типа Person.
            //Но автоматически такие преобразования не проходят, ведь не каждый человек (объект Person)
            //является сотрудником предприятия (объектом Employee). И для нисходящего преобразования
            //необходимо применить явное преобразование, указав в скобках тип, к которому нужно выполнить преобразование:

            Employee employee1 = new Employee("Tom", "Microsoft");
            Person person2 = employee1;   // преобразование от Employee к Person
            //а вот наоборот нельзя
            //Employee employee2 = person;    // так нельзя, нужно явное преобразование
            Employee employee2 = (Employee)person2;  // преобразование(явное) от Person к Employee

            object obj2 = new Employee("Lero","Home");

            // не можем положить обьект базового класса в ссылку производного, без явного приведения
            Employee employee3 = (Employee)obj2;
            Console.WriteLine(employee3.Name+" sitting of "+employee3.Company);
            //или
            Console.WriteLine(((Employee)obj2).Name +" "+ ((Employee)obj2).Company);

            // объект Client также представляет тип Person
            Person person3 = new Client("Sam", "ContosoBank");
            //производим нисходящее явное преобразование от  Person к  Client
            Client client = (Client)person3;
            Console.WriteLine(client.Name);
            Console.WriteLine(client.Bank);



            // Объект Employee также представляет тип object
            object obj3 = new Employee("Bill", "Microsoft");

            // преобразование к типу Client, чтобы получить свойство Bank
            // не будет так как Client не является обьектом Employee
            //string bank = ((Client)obj3).Bank;

            Person person4 = new Person("Bob");
            Employee employee4 = (Employee)person4; // ! Ошибка

            //В данном случае мы пытаемся преобразовать объект типа Person к типу Employee,
            //а объект Person не является объектом Employee. Причем в последнем случае Visual Studio не подскжет,
            //что в данной строке ошибка, и данная строка даже нормально скомилируется, тем не менее в процессе
            //выполнения программы мы получим ощибку. В этом в том числе и кроектся коварство преобразований,
            //поэтому в подобных ситуациях надо проявлять осторожность.






        }
    }
}
