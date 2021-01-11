using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_January
{
    class SavingsAccount : Account
    {
        // decimal or double
        public decimal Rate = 0.06m;
        public override decimal CalculateInterest() 
        {
            decimal interest = Balance * Rate;
            return interest;
        }

        public SavingsAccount(string firstName, string lastName, decimal balance) : base(firstName, lastName, balance) { }

        public override string ToString()
        {
            return string.Format($"{LastName},{FirstName} - Savings Account").ToString();
        }
    }
}
