using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace homework_due_dates_program
{
    internal class Program
    {
        private static string[] options = { "", " View Homework", " Add Homework", " Complete Homework", " Quit Program" };
        private static string fileName = "homework.txt";
        static void Main()
        {
            Console.WriteLine("\nWelcome to your Homework Homescreen, Select an option");
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
                Console.WriteLine("Press any Key To Return to Menu");
                Console.ReadKey();
                Main();

            }
            fileReader.Close();

        }
        static void addHomework()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter Subject: ");
                string homeworkName = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Subject Name: {0}", homeworkName);
                Console.WriteLine("Enter Homework Description: ");
                string homeworkWDescription = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Subject Name: {0}", homeworkName);
                Console.WriteLine("Description: {0}", homeworkWDescription);
                Console.WriteLine("Enter Homework Due Date: ");
                DateTime homeworkDueDate = DateTime.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Subject Name: {0}", homeworkName);
                Console.WriteLine("Description: {0}", homeworkWDescription);
                Console.WriteLine("Due Date: {0}", homeworkDueDate);
                Console.WriteLine("Are the Details Above Correct? (y/n)");
                char input = Char.Parse(Console.ReadLine());

                if (input == 'y')
                {
                    if (homeworkDueDate < DateTime.Now)
                    {
                        Console.WriteLine("Please Enter a Date in the Future");
                        addHomework();
                    }
                    StreamWriter Homework = new StreamWriter("HomeworkDocument.txt", true);
                    Homework.WriteLine("{0},{1},{2}, false", homeworkName, homeworkWDescription, homeworkDueDate);
                    Homework.Close();
                    Console.WriteLine("Homework Successfully Added");
                    Thread.Sleep(500);
                    Console.WriteLine("Returning to Menu");
                    Thread.Sleep(500);
                    Main();
                }
                else
                {
                    Console.WriteLine("Please Enter the Homework Details Again");
                    Thread.Sleep(500);
                    addHomework();
                }
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(500);
                addHomework();
            }
        }

        static void completeHomework()
        {
            Console.Clear();
            Console.WriteLine("Which Homework would you like to complete?");
        }
    }
}

