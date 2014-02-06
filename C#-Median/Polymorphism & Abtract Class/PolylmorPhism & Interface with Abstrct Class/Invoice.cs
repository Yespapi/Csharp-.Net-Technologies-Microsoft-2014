using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorPhism
{
   public class Invoice : IPayable
    {
       private int quantity;

       private  decimal pricePerItem;

       //property that gets and sets the part number on the invoice
       public string PartNumber {get;set;}

       //property that gets and sets the part descripitojn on the invoice
       public string PartDescription { get; set; }

       //four-parameter constructor
       public Invoice(string part, string description,int count, decimal price ) 
       {
           PartNumber =part;
           PartDescription =  description;
           Quantity = count;
           pricePerItem= price;

       }

       public int Quantity
       {
           get {
               return quantity;
           }
           set {
               if(value >=0 ) //validate quantity
                   quantity = value;
               else 
                   throw new  ArgumentOutOfRangeException("Quantity", value, "Quantity must be >=0 ");
           }//end set

       }//end property quantity

        public decimal PricePerItem
   {
      get
      {
         return pricePerItem;
      } // end get
      set
      {
         if ( value >= 0 ) // validate price
            pricePerItem = value; 
         else
            throw new ArgumentOutOfRangeException( "PricePerItem",
               value, "PricePerItem must be >= 0" );
      } // end set
   } // end property PricePerItem


       // return string representation of Invoice object
   public override string ToString()
   {
      return string.Format(
         "{0}: \n{1}: {2} ({3}) \n{4}: {5} \n{6}: {7:C}",
         "invoice", "part number", PartNumber, PartDescription,
         "quantity", Quantity, "price per item", PricePerItem );
   } // end method ToString

      // method required to carry out contract with interface IPayable
   public decimal GetPaymentAmount()
   {
      return Quantity * PricePerItem; // calculate total cost
   } // end method GetPaymentAmount  

    }
}
