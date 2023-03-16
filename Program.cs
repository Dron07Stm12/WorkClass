using System;
using System.Collections;

namespace Console_Class
{
    //Индексаторы позволяют индексировать объекты и обращаться к данным по индексу.
    //Фактически с помощью индексаторов мы можем работать с объектами как с массивами.
    //По форме они напоминают свойства со стандартными блоками get и set,
    //которые возвращают и присваивают значение.


    class Person 
    {
      public string Name { get; set; }
        public Person(string name)
        {
                Name= name;
           
        } 
    
    
    }

    class Company : IEnumerable
    {
        private Person[] person1;

        public Company(Person[] people)
        {
            person1 = people;
        }

         public  Person this[int index] {

            get { return person1[index]; }
            set { person1[index] = value; } 
        
         }

        // просто реализация метода  GetEnumerator()
        //public IEnumerator GetEnumerator()
        //{
        //    return person1.GetEnumerator();

        //}
        //реализация интерфейса IEnumerable и метода GetEnumerator() явным образом
        IEnumerator IEnumerable.GetEnumerator() { return person1.GetEnumerator(); }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(new Person[] {new Person("Dron"),new Person("Lero"),new Person("Nata") } );

            Person person = company[0];
            Console.WriteLine(person.Name);
            // можно использовать ключевое слово as. С помощью него программа пытается преобразовать
            //выражение к определенному типу, при этом не выбрасывает исключение. В случае неудачного преобразования
            //выражение будет содержать значение null:
            Person person1 = company[0] as Person;

            if (person1 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(person1.Name + " as");
               
            }

            string s = company[0].Name as string;
            if (s != null)
            {
                Console.WriteLine(s +" as");
            }

           





            Console.WriteLine("***");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(company[i].Name);
            }
            Console.WriteLine("*** also foreach");

            foreach (Person item in company)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("*** also IEnumerator");
            //IEnumerator enumerator = company.GetEnumerator();
            //while (enumerator.MoveNext()) 
            //{
            //    Console.WriteLine(((Person)enumerator.Current).Name);
            
            //}
            //enumerator.Reset(); 
        }
    }
}
