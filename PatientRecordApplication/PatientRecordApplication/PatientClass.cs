using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    class PatientClass
    {        
        private decimal balanceOwed;

        /// <summary>
        /// Getter and setter for the patient's ID number.
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// Getter and setter for the patients's name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PatientClass ()
        {

        }

        /// <summary>
        /// Sets the patient's ID number, name, and balance owed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        public PatientClass (string id, string name, decimal balance)
        {
            IDNumber = id;
            Name = name;
            BalanceOwed = balance;
        }

        /// <summary>
        /// Getter and setter for the balance owed.
        /// </summary>
        public decimal BalanceOwed 
        { 
            get => balanceOwed;
            
            set
            {
                if (value >= 0)
                {
                    balanceOwed = value;
                }
                else
                {
                    throw new System.Exception();
                }
            } 
        }
    }
}
