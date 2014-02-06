using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharps_Median
{
    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        private decimal baseSalary;



        //constructeur 
        public BasePlusCommissionEmployee(string first, string last,
                           string ssn, decimal sales, decimal rate, decimal salary)
            : base(first, last, ssn, sales, rate)
        {
            baseSalary = salary;
        }

        public decimal BaseSalary
        {

            get
            {
                return baseSalary;
            }//end get
            set
            {
                if (value >= 0)
                    baseSalary = value;
                else throw new ArgumentOutOfRangeException("BaseSalary",
                  value, "BaseSalary must be >= 0");
            }//end set 
        }

        public override decimal Earnings()
        {
            return baseSalary + (commissionRate * grossSales);
        }

       // return string representation of BasePlusCommissionEmployee
       public override string ToString()
       {
          // not allowed: attempts to access private base class members   
          return string.Format(
             "{0}: {1} {2}\n{3}: {4}\n{5}: {6:C}\n{7}: {8:F2}\n{9}: {10:C}",
             "base-salaried commission employee", firstName, lastName,
             "social security number", socialSecurityNumber,
             "gross sales", grossSales, "commission rate", commissionRate,
             "base salary", baseSalary );
       } // end method ToString
   

    }
}
