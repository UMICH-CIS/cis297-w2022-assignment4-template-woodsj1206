using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PatientRecordApplication
{
    /// <summary>
    /// This program uses file modification to implement a patient record application.
    /// </summary>
    /// <Student>Jonathan Woods</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    class Program
    {
        /// <summary>
        /// The program allows a user to add, display, and search for patient information.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Enter the File Name to Store the Patient Records: ");
            string fileName = Console.ReadLine() + ".txt";

            if (!File.Exists(fileName)) //Adds a title to the top of the file.
            {
                FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                
                writer.WriteLine($"Patient Records:");
                
                writer.Close();
                outFile.Close();
            }

            //Creates a file writer and reader with the specified file name.
            FileWriter fileWriter =  new FileWriter(fileName);
            FileReader fileReader = new FileReader(fileName);

            PatientFinder patientFinder = new PatientFinder(fileName);

            while (true)
            {
                switch (ShowMenu())
                {
                    case 1:
                        fileWriter.AddPatient();
                        break;

                    case 2:
                        fileReader.ReadFile();
                        break;

                    case 3:
                        patientFinder.FindPatientByID();
                        break;

                    case 4:
                        patientFinder.LowestBalanceDue();
                        break;

                    case 5: 
                        return;

                    default:
                        break;
                }

                Console.WriteLine("Press Enter to Continue.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Displays a menu of options and allows the user to select one.
        /// </summary>
        /// <returns>Returns the user's input.</returns>
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1: Add New Patient to File.");
            Console.WriteLine("2: Display File Information.");
            Console.WriteLine("3: Search Patient by ID Number.");
            Console.WriteLine("4: Find Patients with the Minimun Balance Due.");
            Console.WriteLine("5: Exit Program");
            Console.Write("\nChoose an Option: ");

            int userInput = 0;
            
            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid value entered for user input.");
            }

            return userInput;
        }
    }
}
