using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class Contract
    {
        public static int counter = 10000000;
        public int Num_Of_Contract { get; set; }//start in eight digits
        public int Nanny_Id { get; set; }
        public int Child_Id { get; set; }
        public bool Meeting { get; set; }
        public bool Contract_Was_Signed { get; set; }
        public double Hour_Salary { get; set; }//empty if it is per month
        public double Month_Salary { get; set; }//total salary
        public bool Is_Month_Salary { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool Including_Social_Benefits { set; get; }//our


        public override string ToString()//
        {
            string toPrint = "contract: \n number: " + Num_Of_Contract + "\n nanny id:  " + Nanny_Id + "\n child id: " + Child_Id + "\n Meeting took place: " + Meeting
                            + "\n Contract Was Signed : " +Contract_Was_Signed + " \n salary per hour: " + Hour_Salary + "\n Total salary after discount: " + Month_Salary+"\n including social benefits: " + Including_Social_Benefits
                            + "\n start date: "+Start_Date.ToShortDateString()+ "\n end date: " + End_Date.ToShortDateString()+"\n";
            return toPrint;
        }



    }
}
