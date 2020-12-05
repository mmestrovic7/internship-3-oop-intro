using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

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
                        AddEvent(eventGuestLists);
                        break;
                    case 2:
                        DeleteEvent(eventGuestLists);
                        break;
                    case 3:
                        EditEvent(eventGuestLists);
                        break;
                    case 4:
                        AddPersonToEvent(eventGuestLists);
                        break;
                    case 5:
                        DeletePersonFromEvent(eventGuestLists);
                        break;
                    case 6:
                        rightInput=PrintAndExit(eventGuestLists);
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
        static bool DoesAnEventExist(string newEventName, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var doesItExist = false;

                foreach (var e in eventGuestLists)
                    if (newEventName.ToLower() == e.Key.Name.ToLower())
                    doesItExist = true;

                    
          
            return doesItExist;

        }
        static bool IsTimeTaken(int number, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var doesItExist = false;

            foreach (var e in eventGuestLists)
                if (number >= e.Key.StartTime && number <= e.Key.EndTime)
                   doesItExist=true ;



            return doesItExist;


        }
        static Event GetKey(string eventName, Dictionary<Event, List<Person>> eventGuestLists)
        {
            var key = new Event("", EventType.Coffee, 1, 1);
            foreach (var e in eventGuestLists)
            {
                if (e.Key.Name.ToLower() == eventName.ToLower())
                    key = e.Key;

            }
            return key;

        }
        static void AddEvent(Dictionary<Event, List<Person>> eventGuestLists)
        {
            Console.WriteLine("Unesite ime novog eventa:");

            var newEventName = Console.ReadLine();
            while (DoesAnEventExist(newEventName, eventGuestLists))
            {
                Console.WriteLine("Već postoji ovaj event unesite neko drugo ime.");
                newEventName = Console.ReadLine();
            }

            var newType = -1;
            while (newType < 0 || newType > 4)
            {
                Console.WriteLine("Koji je tip novog eventa, unesite broj od 0 do 3? 0=Kava, 1=Predavanje, 2=Koncert, 3=Učenje");
                while (newType == -1)
                    newType = IntegerInput();
                if (newType < 0 || newType > 3)
                    newType = -1;
            }

            Console.WriteLine("Unesite kada će event započeti:");
            var newStartTime = IntegerInput();
            while (IsTimeTaken(newStartTime, eventGuestLists))
            {
                Console.WriteLine("Vrijeme je već zauzeto");
                newStartTime = IntegerInput();

            }
            Console.WriteLine("Unesite kada će event završiti:");
            var newEndTime = IntegerInput();
            while (IsTimeTaken(newEndTime, eventGuestLists) == true || newEndTime < newStartTime)
            {
                Console.WriteLine("Broj mora biti veći od prvog i ne smije biti zauzet");
                newEndTime = IntegerInput();

            }
            eventGuestLists.Add(new Event(newEventName, (EventType)newType, newStartTime, newEndTime), new List<Person> { });


        }
        static void DeleteEvent(Dictionary<Event, List<Person>> eventGuestLists)
        {

            Console.WriteLine("Unesite ime eventa kojeg ćete izbrisati:");
            var deleteEventName = Console.ReadLine();
            while (!DoesAnEventExist(deleteEventName, eventGuestLists))
            {
                Console.WriteLine("Ovaj event ne postoji");
                deleteEventName = Console.ReadLine();
            }
            var deleteKey = GetKey(deleteEventName, eventGuestLists);
            eventGuestLists.Remove(deleteKey);

        }
        static void AddPersonToEvent(Dictionary<Event, List<Person>> eventGuestLists)
        {

            Console.WriteLine("Unesite ime eventa na kojeg želite dodati osobu:");
            var addPersonEventName = Console.ReadLine();
            while (!DoesAnEventExist(addPersonEventName, eventGuestLists))
            {
                Console.WriteLine("Ovaj event ne postoji");
                addPersonEventName = Console.ReadLine();

            }
            var addKey = GetKey(addPersonEventName, eventGuestLists);
            Console.WriteLine("Unesite OIB osobe");
            var oib = 0;
            var doesOibExist = true;
            while (doesOibExist)
            {
                oib = IntegerInput();
                doesOibExist = false;
                foreach (var person in eventGuestLists[addKey])

                    if (person.OIB == oib)
                    {
                        doesOibExist = true;
                        Console.WriteLine("Osoba s ovim OIB-om vec postoji");
                    }

            }
            Console.WriteLine("Unesite ime osobe");
            var newFirstName = Console.ReadLine();
            Console.WriteLine("Unesite prezime osobe");
            var newLastName = Console.ReadLine();
            Console.WriteLine("Unesite broj mobitela osobe");
            var newPhoneNumber = IntegerInput();
            eventGuestLists[addKey].Add(new Person(newFirstName, newLastName, oib, newPhoneNumber));

        }
        static void DeletePersonFromEvent(Dictionary<Event, List<Person>> eventGuestLists)
        {
            Console.WriteLine("Unesite ime eventa sa kojeg želite ukloniti osobu:");
            var removePersonEventName = Console.ReadLine();
            while (!DoesAnEventExist(removePersonEventName, eventGuestLists))
            {
                Console.WriteLine("Ovaj event ne postoji");
                removePersonEventName = Console.ReadLine();

            }
            var removeKey = GetKey(removePersonEventName, eventGuestLists);
            
            var deletePersonName = "";
            var doesNameExist = false;
            var position = 0;
            while (!doesNameExist)
            {
                Console.WriteLine("Unesite ime osobe koju želite ukloniti:");
                deletePersonName = Console.ReadLine();
                var i= 0;

                foreach (var person in eventGuestLists[removeKey])
                {
                    if (person.FirstName.ToLower() == deletePersonName.ToLower())

                    {
                        doesNameExist = true;
                        position = i;
                    }

                    i++;
                }
            }
            
            eventGuestLists[removeKey].RemoveAt(position);
            

        }
        static void EditEvent(Dictionary<Event,List<Person>> eventGuestLists)
        {
            Console.WriteLine("Unesite ime eventa kojeg želite urediti:");
            var changeEventName = Console.ReadLine();
            while (!DoesAnEventExist(changeEventName, eventGuestLists))
            {
                Console.WriteLine("Ovaj event ne postoji");
                changeEventName = Console.ReadLine();

            }
            var changeKey = GetKey(changeEventName, eventGuestLists);

        }
        static bool PrintAndExit(Dictionary<Event, List<Person>> eventGuestLists)
        {
            Console.WriteLine("1.Ispis detalja eventa u formatu: name – event type – start time – end time – trajanje – ispis broja ljudi na eventu");
            Console.WriteLine("2.Ispis svih osoba na eventu u formatu: [Redni broj u listi]. name – last name – broj mobitela");
            Console.WriteLine("3.Ispis svih detalja. Kombinacija ispisa detalja eventa ( 6.1.) i ispisa svih osoba( 6.2.)");
            Console.WriteLine("4.Izlazak iz podmenija.");
            bool rightInput = false;
            while (!rightInput)
            {
                Console.WriteLine("Na podmeniju ste. Izaberite što želite:");
                var parsedOption = IntegerInput();
                switch(parsedOption)
                {
                    case 1:
                        foreach(var e in eventGuestLists)
                        {
                            Console.WriteLine(e.Key.Name +" - "+ e.Key.EventType+" - "+e.Key.StartTime+" - "+e.Key.EndTime+" - "+(e.Key.EndTime-e.Key.StartTime)+" - "+e.Value.Count);
                        }
                        break;
                    case 2:
                        var i = 1;
                        foreach (var e in eventGuestLists)
                        { i = 1;
                        foreach(var person in e.Value)
                            {
                                Console.WriteLine("[" + i + "]. "+person.FirstName+" - "+person.LastName+" - "+person.PhoneNumber);
                                i++;
                        }
                        }

                        break;
                    case 3:
                        foreach (var e in eventGuestLists)
                        {

                            Console.WriteLine(e.Key.Name + " - " + e.Key.EventType + " - " + e.Key.StartTime + " - " + e.Key.EndTime + " - " + (e.Key.EndTime - e.Key.StartTime) + " - " + e.Value.Count);
                            i = 1;
                            foreach (var person in e.Value)
                            {
                                Console.WriteLine("[" + i + "]. " + person.FirstName + " - " + person.LastName + " - " + person.PhoneNumber);
                                i++;
                            }
                        }

                        break;
                    case 4:
                        rightInput = true;
                      
                        break;
                    default:
                        Console.WriteLine("Morate unijeti broj od 1 do 4");
                        break;
                }
                
            }
            return rightInput;
        }



    }
}
