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
            
            
           
          
            bool rightInput = false;
            while (!rightInput)
            {
                Console.WriteLine("Na početnom ste izborniku. Izaberite što želite:");
                var parsedOption = IntegerInput();

                switch (parsedOption)
                {
                    case 1:
                        
                        Console.WriteLine("Unesite ime novog eventa:");

                        var newEventName = Console.ReadLine();
                        while(doesAnEventExist(newEventName,eventGuestLists))
                        {
                            Console.WriteLine("Već postoji ovaj event unesite neko drugo ime.");
                            newEventName = Console.ReadLine();
                        }

                        var newType = -1;
                        while(newType<0||newType>4)
                        { 
                        Console.WriteLine("Koji je tip novog eventa, unesite broj od 0 do 3? 0=Kava, 1=Predavanje, 2=Koncert, 3=Učenje");
                        while(newType==-1)
                        newType = IntegerInput();
                            if (newType < 0 || newType > 3)
                                newType = -1;
                        }

                        Console.WriteLine("Unesite kada će event započeti:");
                        var newStartTime = IntegerInput();
                        while(isTimeTaken(newStartTime,eventGuestLists))
                            {
                            Console.WriteLine("Vrijeme je već zauzeto");
                            newStartTime = IntegerInput();

                        }
                        Console.WriteLine("Unesite kada će event završiti:");
                        var newEndTime = IntegerInput();
                        while (isTimeTaken(newEndTime, eventGuestLists)==true||newEndTime<newStartTime)
                        {
                            Console.WriteLine("Broj mora biti veći od prvog i ne smije biti zauzet");
                            newEndTime = IntegerInput();

                        }
                        eventGuestLists.Add(new Event(newEventName, (EventType)newType, newStartTime, newEndTime), new List<Person> { });

                      


                        break;
                    case 2:
                        Console.WriteLine(eventGuestLists.Count);
                        Console.WriteLine("Unesite ime eventa kojeg ćete izbrisati:");
                        var deleteEventName = Console.ReadLine();
                        while (!doesAnEventExist(deleteEventName, eventGuestLists))
                        {
                            Console.WriteLine("Ovaj event ne postoji");
                            deleteEventName = Console.ReadLine();
                        }
                        var key = getKey(deleteEventName, eventGuestLists);
                        eventGuestLists.Remove(key);
                        Console.WriteLine(eventGuestLists.Count);


                        break;
                    case 3:
                        Console.WriteLine("Unesite ime eventa kojeg želite urediti:");
                        var changeEventName = Console.ReadLine();
                        while (!doesAnEventExist(changeEventName, eventGuestLists))
                        {
                            Console.WriteLine("Ovaj event ne postoji");
                            changeEventName = Console.ReadLine();
                        }

                        break;
                    case 4:
                        
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        
                        break;
                    default:
                        Console.WriteLine("Morate unijeti broj od 1 do 6");
                        break;
                }
            }
        }
        static int IntegerInput()
        {
            bool isItANumber = false;
            int parsedNumber = -1;
            while (!isItANumber)
            {
                var number = Console.ReadLine();
                isItANumber = int.TryParse(number, out parsedNumber);
                if (!isItANumber)
                    Console.WriteLine("Morate unijeti broj");

            }
            return parsedNumber;
        }
        static bool doesAnEventExist(string newEventName, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var doesItExist = false;

                foreach (var e in eventGuestLists)
                    if (newEventName.ToLower() == e.Key.Name.ToLower())
                    doesItExist = true;

                    
          
            return doesItExist;

        }
        static bool isTimeTaken(int number, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var doesItExist = false;

            foreach (var e in eventGuestLists)
                if (number >= e.Key.StartTime && number <= e.Key.EndTime)
                   doesItExist=true ;



            return doesItExist;


        }
        static Event getKey(string eventName, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var key = new Event("", EventType.Coffee, 1, 1);
            foreach (var e in eventGuestLists)
            {
                if (e.Key.Name.ToLower() == eventName.ToLower())
                    key = e.Key;

            }
            return key;

        }




    }
}
