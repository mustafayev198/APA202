using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    internal class Student : Person
    {
        public bool isStudent;
        public Student()
        {
            // public fielde drived classda cata bilirik.
            Console.WriteLine(this.name);

            //protected fielde drived classda cata bilirik.
            Console.WriteLine(this.name1);

            //internal fielde drived classda cata bilirik.
            Console.WriteLine(this.name2);

            //private fielde drived classda cata bilmirik.
            //Console.WriteLine(this.name3);

            //protected internal fielde drived classda cata bilirik.
            Console.WriteLine(this.name4);

            //private protected fielde drived classda cata bilirik.
            Console.WriteLine(this.name5);

        }
    }
}