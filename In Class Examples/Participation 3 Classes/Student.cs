using System;
using System.Collections.Generic;
using System.Text;

namespace Participation_3_Classes
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }
        public Address address { get; set; }

        public Student()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Major = String.Empty;
            GPA = 0;
            Address address = new Address();
        }

        public Student(string firstname, string lastname, string major, double gpa)
        {
            FirstName = firstname;
            LastName = lastname;
            Major = major;
            GPA = gpa;
            Address address = new Address();
        }

        public string CalculateDistinction()
        {
            
        }
    }
}
