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

            }
            ;



        }
       
    }
}
