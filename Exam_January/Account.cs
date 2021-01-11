using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_January
{
    abstract class Account
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public DateTime InterestDate { get; set; } // if issues check here 

        public Account ( string firstName, string lastName, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            
        }

        public void Deposit(decimal amountToAdd) 
        {
            Balance += amountToAdd;
        }

        public void Withdraw(decimal amountToAdd) 
        {
            Balance -= amountToAdd;
        }

        public abstract decimal CalculateInterest();

        public override string ToString()
        {
            return string.Format($"{LastName},{FirstName}").ToString();
        }

    }
}
