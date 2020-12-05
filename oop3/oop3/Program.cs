using System;
using System.Collections.Generic;

namespace oop3
{
    class Program
    {
        static void Main(string[] args)
        {
            var exampleEvent1 = new Event("Magan", EventType.Coffee, 8, 9);
            var examplePerson1 = new Person("Lucija", "Topic", 00, 10);
            var examplePerson2 = new Person("Jelena", "Bilobrk", 01, 11);
            var exampleEvent2 = new Event("Hozier", EventType.Concert, 7, 8);
            var examplePerson3 = new Person("Bruna", "Vujevic", 02, 12);
            var examplePerson4 = new Person("Marija", "Mestrovic", 03, 13);
            var exampleEvent3 = new Event("Weeknd", EventType.Concert, 9, 10);
            var examplePerson5 = new Person("Bruna", "Jurasovic", 04, 14);

            var exampleGuestList1 = new List<Person>();
            exampleGuestList1.Add(examplePerson1);
            exampleGuestList1.Add(examplePerson2);
            var exampleGuestList2 = new List<Person>();
            exampleGuestList2.Add(examplePerson3);
            exampleGuestList2.Add(examplePerson4);
            var exampleGuestList3 = new List<Person>();
            exampleGuestList3.Add(examplePerson5);


            var eventGuestLists = new Dictionary<Event, List<Person>>()
            {
                {exampleEvent1,exampleGuestList1 },
                {exampleEvent2,exampleGuestList2 },
                {exampleEvent3,exampleGuestList3 },

            };
            
            Console.WriteLine("1.Dodavanje eventa");
            Console.WriteLine("2.Brisanje eventa");
            Console.WriteLine("3.Edit eventa");
            Console.WriteLine("4.Dodavanje osobe na event");
            Console.WriteLine("5.Uklanjanje osobe sa eventa");
            Console.WriteLine("6.Ispis detalja eventa.");
            Console.WriteLine("Izaberite što želite:");
            
            bool rightInput = false;
            while (!rightInput)
            {
                bool isItANumber = false;
                int parsedOption = 0;
                while (!isItANumber)
                {
                    var option = Console.ReadLine();
                    isItANumber = int.TryParse(option, out parsedOption);
                    if (!isItANumber)
                        Console.WriteLine("Morate unijeti broj");

                }
                switch (parsedOption)
                {
                    case 1:
                        rightInput = true;
                        break;
                    case 2:
                        rightInput = true;
                        break;
                    case 3:
                        rightInput = true;
                        break;
                    case 4:
                        rightInput = true;
                        break;
                    case 5:
                        rightInput = true;
                        break;
                    case 6:
                        rightInput = true;
                        break;
                    default:
                        Console.WriteLine("Morate unijeti broj od 1 do 6");
                        break;
                }
            }


            



        }
       
    }
}
