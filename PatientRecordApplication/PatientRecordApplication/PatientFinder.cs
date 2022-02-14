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
    /// Searches for specified patients in a file.
    /// </summary>
    class PatientFinder
    {
        /// <summary>
        /// Getter and setter for the file's name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PatientFinder()
        {

        }

        /// <summary>
        /// Sets the file's name.
        /// </summary>
        /// <param name="fileName"></param>
        public PatientFinder(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Prints all patient records that have a balance greater than or equal to the amount specified.
        /// </summary>
        public void LowestBalanceDue()
        {
            Console.Clear();

            Console.Write("Enter the Minimum Balance Due: $");
            decimal balance = 0M;

            try
            {
               balance = decimal.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid value entered for minimum balance due.");
            }

            FileStream inFile = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string currentLine = reader.ReadLine();
            string[] patientInfo;
            
            Console.Clear();
            Console.WriteLine(currentLine);
            
            while (currentLine != null)
            {
                patientInfo = currentLine.Split(' ');
                
                try
                {
                    if (decimal.Parse(patientInfo[2]) >= balance)
                    {
                        Console.WriteLine(currentLine);
                    }
                }
                catch (System.FormatException)
                {

                }
                catch (Exception)
                {

                }
                
                currentLine = reader.ReadLine();
            }

            reader.Close();
            inFile.Close();
        }

        /// <summary>
        /// Prints the patient records that matches the ID number specified.
        /// </summary>
        public void FindPatientByID()
        {
            Console.Clear();

            Console.Write("Enter the Patient's ID Number: ");
            string id = Console.ReadLine();

            FileStream inFile = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            
            string currentLine = reader.ReadLine();
            string[] patientInfo;

            Console.Clear();
            Console.WriteLine(currentLine);
            
            while (currentLine != null)
            {
                patientInfo = currentLine.Split(' ');

                if (patientInfo[0] == id)
                {
                    Console.WriteLine(currentLine);
                }                
                
                currentLine = reader.ReadLine();
            }

            reader.Close();
            inFile.Close();
        }
    }
}
