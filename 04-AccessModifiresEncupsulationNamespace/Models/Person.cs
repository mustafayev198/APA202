using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AccessModifiresEncupsulationNamespace.Models
{
    public class Person
    {
        public string name;
        protected string name1;
        internal string name2;
        private string name3;
        protected internal string name4;
        private protected string name5;
        //    public Person(string name)
        //    {
        //        this.name = name;
        //    }
        public void GetInfo()
        {
            // public fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name}");

            // protected fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name1}");

            // internal fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name2}");

            // private fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name3}");

            // protected internal fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name4}");

            // private protected fielde oz classinda cata bilirik.
            Console.WriteLine($"{this.name5}");

        }
    }

}