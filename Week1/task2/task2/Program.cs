using System;

namespace task2
{
    class Student
    {
        public string name;
        public string id;
        public int year;
        public Student(string n, string i, int y)
        {
            name = n;
            id = i;
            year = y;

        }
        public void PrintName()
        {
            Console.WriteLine(name + " ");
        }
        public void PrintInfo()
        {
            Console.WriteLine("id: "+id  + ", year: " + year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Khakimova Munira", "18BD360365", 2018);
            s.PrintName();
            s.PrintInfo();

        }
    }
}
