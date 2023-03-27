using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Net.Http.Headers;

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
        public IEnumerator GetEnumerator()
        {
            return person1.GetEnumerator();

        }
        //реализация интерфейса IEnumerable и метода GetEnumerator() явным образом
        //IEnumerator IEnumerable.GetEnumerator() { return person1.GetEnumerator(); }

    }



    class User
    {
        //public string Name
        //{
        //    set { name = value; }
        //    get { return name; }

        //}
        string name = "";
        string email = "";
        string phone = "";

        public string this[string s] 
        {

            get {

                switch (s)
                {
                    case "name": return name;  
                        
                    case "email":   return email;

                    case "phone": return phone;
                        default: throw new Exception("Unknown Property Name - неверно");
                           
                }



            }

            set { 
                switch (s) 
                {
                        case"name": name = value; 
                        break;
                        case "email": email = value;    
                        break;
                        case "phone": phone = value;
                        break;  
                
                
                }
            
            
            
            }   
        
        }



    }












    internal class Program
    {
        static void Main(string[] args)
        {

            StringValues strings2 = "1";
            StringValues strings3 = "0";
            string s5 = StringValues.Concat(strings2, strings3);
            Console.WriteLine(StringValues.Concat(strings2, strings3));




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

           





            Console.WriteLine("****");

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
            IEnumerator enumerator = company.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(((Person)enumerator.Current).Name);

            }
            enumerator.Reset();

            //индексы необязательно должны представлять тип int, устанавливаемые/возвращаемые значения
            //необязательно хранить в массиве. Например, мы можем рассматривать объект как хранилище атрибутов/свойств и
            //передавать имя атрибута в виде строки
            //В данном случае индексатор в классе User в качестве индекса получает строку,
            //которая хранит название атрибута (в данном случае название поля класса).


            //Мы работаем с обьектом типа User со ссылкой user
            User user = new User();

            //так как у этого обьекта(ссылки user) есть 3 string поля,
            //а индексатор( возвращаемым тип также string) и индексом string,
            // то User в качестве индекса получает строку,
            //которая хранит название атрибута (в данном случае название поля класса).
            user["name"] = "Tom";
            Console.WriteLine(user["name"]);

            string str = user["name"] as string;
            if (str != null) { Console.WriteLine(str + " as"); }
            else
            {
                Console.WriteLine("Преобразование не корректно");
            }
            user["email"] = "D";
            string str2 = user["email"];
            Console.WriteLine(str2);
            Console.WriteLine(str2);


        }
    }
}
