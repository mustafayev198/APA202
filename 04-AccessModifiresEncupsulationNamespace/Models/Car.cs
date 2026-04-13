using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Car
    {

        public Car()
        {
            Person person = new Person();

            // public fielde non-drive classda cata bilirik
            Console.WriteLine(person.name);

            // protected fielde non-drived classda cata bilmirik.
            //Console.WriteLine(person.name1);

            // internal fielde non-drived classda cata bilirik.
            Console.WriteLine(person.name2);

            // private fielde non-drived classda cata bilmirik.
            //Console.WriteLine(person.name3);

            // protected internal fielde non-drived classda cata bilirik.
            Console.WriteLine(person.name4);

            // private protected fielde non-drived classda cata bilmirik.
            //Console.WriteLine(person.name5);
        }

        private int _horsePower = 2000;
        public int HorsePower
        {
            get
            {
                return _horsePower;
            }
            set
            {
                //_horsePower = value;
            }
        }
    }
}