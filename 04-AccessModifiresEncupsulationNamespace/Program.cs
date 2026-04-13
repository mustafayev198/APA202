using _04_AccessModifiresEncupsulationNamespace.Models;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace _04_AccessModifiresEncupsulationNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Student student = new Student();
            //student.name = "Test";
            //Console.WriteLine(student.name);

            // private olan fielde reflection vasitesile catmaq ve deyer vermek.

            Person person = new Person();

            typeof(Person).GetField("name3", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(person, "Apa202");


            var newName = typeof(Person).GetField("name3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);

            Console.WriteLine(newName);

            Car car = new Car();

            //car.HorsePower = 50;
            Console.WriteLine(car.HorsePower);

        }
    }
}