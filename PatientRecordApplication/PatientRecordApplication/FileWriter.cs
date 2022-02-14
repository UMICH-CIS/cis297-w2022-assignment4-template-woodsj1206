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
    /// Writes to a specified file.
    /// </summary>
    class FileWriter
    {
        /// <summary>
        /// Getter and setter for the file's name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileWriter()
        {

        }

        /// <summary>
        /// Sets the file's name.
        /// </summary>
        /// <param name="fileName"></param>
        public FileWriter(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Collects patient information and saves it to a file.
        /// </summary>
        public void AddPatient()
        {
            Console.Clear();

            PatientClass patient = new PatientClass();

            Console.Write("Enter the Patient ID: ");
            patient.IDNumber = Console.ReadLine();

            Console.Write("Enter the Name of the Patient: ");
            patient.Name = Console.ReadLine();

            Console.Write("Enter the Balance the Patient Owes: $");

            try
            {
                patient.BalanceOwed = decimal.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid value entered for balance owed.");

            }
            catch (System.Exception)
            {
                Console.WriteLine("Balance owed cannot be negative.");
            }

            FileStream outFile = new FileStream(FileName, FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(outFile);
            writer.WriteLine($"{patient.IDNumber} {patient.Name} {patient.BalanceOwed}");

            writer.Close();
            outFile.Close();
        }
    }
}
