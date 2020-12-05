using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace oop3
{
    public class Person
    {
        public Person(string firstName,string lastName, int oib, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            OIB = oib;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OIB { get; set; }
        public int PhoneNumber { get; set; }
    }
}
