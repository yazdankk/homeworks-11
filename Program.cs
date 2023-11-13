using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework_due_dates_program
{
    internal class Program
    {
        private static string[] options = { "", " View Homework", " Add Homework", " Complete Homework", " Quit Program" };
        private static string fileName = "homework.txt";
        static void Main()
        {
            Console.WriteLine("Welcome to your Homework Homescreen, Select an option");
            for (int i = 1; i < options.Length; i++)
            {
                Console.WriteLine(i + options[i]);
            }
            string userOption = Console.ReadLine();

            if (userOption == "1")
            {
                viewHomework();
            }
            else if (userOption == "2")
            {
                addHomework();
            }
            else if (userOption == "3")
            {
                completeHomework();
            }
            else if (userOption == "4")
            {
                Console.WriteLine("Exiting the program...");
            }
            else
            {
                Console.WriteLine("Invalid Option, Try again");
            }
        }

        static void viewHomework()
        {
            StreamReader fileReader = new StreamReader("homework.txt");
            while (!fileReader.EndOfStream)
            {
                string line = fileReader.ReadLine();
                string[] stringsplit = line.Split(',');
                string homework = stringsplit[0] + "\n" + stringsplit[1] + "\n" + stringsplit[2] + "\n" + stringsplit[3] + "\n" + stringsplit[4];
                Console.WriteLine(homework);
            }
            fileReader.Close();
        }
        static void addHomework()
        {

            Console.WriteLine("Enter Subject Name:");
            string newSubject = Console.ReadLine();
            Console.WriteLine("Enter Due Date:");
            DateTime newDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Give a description of the homework:");
            string newDescription = Console.ReadLine();
            Console.WriteLine("Is this homework completed? (true/false):");
            bool newChoice = bool.Parse(Console.ReadLine());
            Console.WriteLine("Here is your homework.");
            Console.WriteLine(newSubject + "\n" + newDate + "\n" + newDescription + "\n" + newChoice);

            StreamWriter sr = new StreamWriter("homework.txt", true);
            sr.WriteLine(newSubject + ",");
            sr.WriteLine(newDate + ",");
            sr.WriteLine(newDescription + ",");
            sr.WriteLine(newChoice + ",");
            sr.Close();
        }
        static void completeHomework()
        {

        }
    }
}

