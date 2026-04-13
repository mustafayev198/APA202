using System;
using System.Collections.Generic;

namespace UniversityManagementSystem
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }

        public Person(string firstName, string lastName, int age, string email, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Email = email;
            this.Id = id;
        }

        public string GetFullName() => $"{FirstName} {LastName}";

        public void ShowBasicInfo()
        {
            Console.WriteLine($"ID: {Id} | Ad: {GetFullName()} | Yaş: {Age} | Email: {Email}");
        }
    }

    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public string Faculty { get; set; }
        public double GPA { get; set; }
        public int Year { get; set; }

        public Student(string firstName, string lastName, int age, string email, string id,
                       string studentNumber, string faculty, double gpa, int year)
               : base(firstName, lastName, age, email, id)
        {
            this.StudentNumber = studentNumber;
            this.Faculty = faculty;
            this.GPA = gpa;
            this.Year = year;
        }

        public void ShowStudentInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Telebe No: {StudentNumber} | Fakulte: {Faculty} | Kurs: {Year} | GPA: {GPA}");
        }

        public decimal CalculateScholarship()
        {
            if (GPA >= 90) return 500;
            if (GPA >= 80) return 350;
            if (GPA >= 70) return 200;
            return 0;
        }
    }

    public class Teacher : Person
    {
        public string Department { get; set; }
        public string MainSubject { get; set; }
        public decimal BaseSalary { get; set; }
        public int ExperienceYears { get; set; }

        public Teacher(string firstName, string lastName, int age, string email, string id,
                       string department, string mainSubject, decimal baseSalary, int experienceYears)
               : base(firstName, lastName, age, email, id)
        {
            this.Department = department;
            this.MainSubject = mainSubject;
            this.BaseSalary = baseSalary;
            this.ExperienceYears = experienceYears;
        }

        public void ShowTeacherInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Kafedra: {Department} | Fenn: {MainSubject} | Tecrube: {ExperienceYears} il");
        }

        public decimal CalculateSalary()
        {
            return BaseSalary + (ExperienceYears * 50);
        }
    }

    public class Administrator : Person
    {
        public string Position { get; set; }
        public string Department { get; set; }
        public int AccessLevel { get; set; }

        public Administrator(string firstName, string lastName, int age, string email, string id,
                             string position, string department, int accessLevel)
               : base(firstName, lastName, age, email, id)
        {
            this.Position = position;
            this.Department = department;
            this.AccessLevel = accessLevel;
        }

        public void ShowAdminInfo()
        {
            ShowBasicInfo();
            Console.WriteLine($"Vezife: {Position} | Şöbe: {Department} | Giriş Seviyyesi: {AccessLevel}");
        }

        public void GrantAccess(Student student)
        {
            Console.WriteLine($"[SİSTEM]: Administrator {LastName} telebe {student.GetFullName()} uçun giriş icazesi verdi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Student s1 = new Student("eli", "Memmedov", 20, "ali@uni.edu.az", "S001", "101", "İT", 88.5, 2);
            Student s2 = new Student("Aysel", "Quliyeva", 19, "aysel@uni.edu.az", "S002", "102", "Riyaziyyat", 92.0, 1);
            Student s3 = new Student("Vuqar", "Hesenov", 21, "vuqar@uni.edu.az", "S003", "103", "İqtisadiyyat", 68.5, 3);

            Teacher t1 = new Teacher("Leyla", "eliyeva", 45, "leyla@uni.edu.az", "T001", "Komputer Elmleri", "Alqoritmler", 1200, 15);
            Teacher t2 = new Teacher("Kamran", "Rzayev", 38, "kamran@uni.edu.az", "T002", "Fizika", "Kvant Fizikasi", 1000, 8);

            Administrator admin = new Administrator("Zaur", "Bağirov", 50, "zaur@uni.edu.az", "A001", "Dekan", "İT Fakultesi", 5);

            Console.WriteLine("=== Telebe Melumatlari ===");
            s1.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s1.CalculateScholarship()} AZN\n");
            s2.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s2.CalculateScholarship()} AZN\n");
            s3.ShowStudentInfo(); Console.WriteLine($"Teqaud: {s3.CalculateScholarship()} AZN\n");

            Console.WriteLine("=== Muellim Melumatlari ===");
            t1.ShowTeacherInfo(); Console.WriteLine($"umumi Maaş: {t1.CalculateSalary()} AZN\n");
            t2.ShowTeacherInfo(); Console.WriteLine($"umumi Maaş: {t2.CalculateSalary()} AZN\n");

            Console.WriteLine("=== Administrator Melumatlari ===");
            admin.ShowAdminInfo();
            admin.GrantAccess(s1);
            Console.WriteLine();

            decimal totalScholarship = s1.CalculateScholarship() + s2.CalculateScholarship() + s3.CalculateScholarship();
            decimal totalSalary = t1.CalculateSalary() + t2.CalculateSalary();

            Console.WriteLine("===============================");
            Console.WriteLine("       uMUMİ STATİSTİKA        ");
            Console.WriteLine("===============================");
            Console.WriteLine($"umumi Teqaud Xerci: {totalScholarship} AZN");
            Console.WriteLine($"umumi Maaş Xerci:   {totalSalary} AZN");
            Console.WriteLine("===============================");
        }
    }
}