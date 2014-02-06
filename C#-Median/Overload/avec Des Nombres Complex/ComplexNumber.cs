using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{


    public class ComplexNumber
    {
        public double Real { get; private set; }

        public double Imaginary { get; private set; }

        //constructor
        public ComplexNumber(double a, double b)
        {
            Real = a;
            Imaginary = 2;
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2}i)",
   Real, (Imaginary < 0 ? "-" : "+"), Math.Abs(Imaginary));
        }

        //overload the addition operator

        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real + y.Real, x.Imaginary + y.Imaginary);
        }
        //overload the soustraction operator
        public static ComplexNumber operator-(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real + y.Real, x.Imaginary - y.Imaginary);

        }

        // overload the multiplication operator
        public static ComplexNumber operator *(
           ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(
               x.Real * y.Real - x.Imaginary * y.Imaginary,
               x.Real * y.Imaginary + y.Real * x.Imaginary);
        } // end operator *    

    }
}
