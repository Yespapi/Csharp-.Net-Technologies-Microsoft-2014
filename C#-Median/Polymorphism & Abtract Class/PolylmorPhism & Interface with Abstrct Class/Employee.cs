using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorPhism
{
    public abstract class Employee : IPayable 
    {

       //read-olny property that gets employee's firqname 
       public string FirstName { get; private set; }

       // read-only property that gets employee's last name
       public string LastName { get; private set; }

       // read-only property that gets employee's social security number
       public string SocialSecurityNumber { get; private set; }

       // three-parameter constructor
       public Employee(string first, string last, string ssn)
       {
           FirstName = first;
           LastName = last;
           SocialSecurityNumber = ssn;
       } // end three-parameter Employee constructor

       // return string representation of Employee object
       public override string ToString()
       {
           return string.Format("{0} {1}\nsocial security number: {2}",
              FirstName, LastName, SocialSecurityNumber);
       } // end method ToString

       // Note: We do not implement IPayable method GetPaymentAmount here so
       // this class must be declared abstract to avoid a compilation error.
       public abstract decimal GetPaymentAmount();

    }
}
