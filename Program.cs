using System;
using System.Collections;

namespace Console_Class
{

    class Person
    {
        public string Name { get; set; }
        //public Person(string name) => Name = name;

        public Person(string name) { Name = name; }
    }
    class Company /*: IEnumerable*/
    {
        Person[] personal;

        public Company(Person[] people)
        {
                personal= people;
        }

        //public Company(Person[] people) => personal = people;
        // индексатор
        //public Person this[int index]
        //{
        //    get => personal[index];
        //    set => personal[index] = value;
        //}

        //Индексаторы позволяют индексировать объекты и обращаться к данным по индексу.
        //Фактически с помощью индексаторов мы можем работать с объектами как с массивами.
        public Person this[int index]
        {
            get { return personal[index]; }
            set { personal[index] = value; }
        
        }

        public IEnumerator GetEnumerator()
        {
            return personal.GetEnumerator();

        }

        //IEnumerator IEnumerable.GetEnumerator() 
        //{ return personal.GetEnumerator(); }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(new Person[] { new Person("Dron"), new Person("Lero"),new Person("Nata") });
            Console.WriteLine(company[0].Name);
            Person person = company[1]; 
            Console.WriteLine(person.Name);
            Console.WriteLine("***");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(company[i].Name);
            }
            Console.WriteLine("***");
            foreach (Person item in company)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("***");
            foreach (var item in company)
            {
                Console.WriteLine(((Person)item).Name);
            }
            Console.WriteLine("***");

            IEnumerator enumerator = company.GetEnumerator();

            while (enumerator.MoveNext()) {

                Console.WriteLine(((Person)enumerator.Current).Name);
            }
            Console.WriteLine("***");


            company[0] = new Person("Kampot");
            Console.WriteLine(company[0].Name);

            person.Name = "Belka";
            company[2].Name = person.Name;
            Console.WriteLine(company[2].Name);

        }
    }
}
