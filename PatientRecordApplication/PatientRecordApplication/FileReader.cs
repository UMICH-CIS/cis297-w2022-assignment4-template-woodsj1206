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
    /// Reads from a specified file.
    /// </summary>
    class FileReader
    {
        /// <summary>
        /// Getter and setter for the file's name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public FileReader()
        {

        }

        /// <summary>
        /// Sets the file's name.
        /// </summary>
        /// <param name="fileName"></param>
        public FileReader(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Reads data from a file.
        /// </summary>
        public void ReadFile()
        {
            Console.Clear();

            FileStream inFile = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            
            StreamReader reader = new StreamReader(inFile);

            string currentLine = reader.ReadLine();

            while (currentLine != null)
            {   
                Console.WriteLine(currentLine);
                
                currentLine = reader.ReadLine();
            }

            reader.Close();

            inFile.Close();
        }
    }
}
