using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace BE
{
    [Serializable]
    
    public class Child
    {
        private int id;
        public int Id
        { get
            { return id; }
            set
            {
                if (value <= 0) throw new Exception("cant add minus id");
                else if (value.ToString().Length < 9)
                    throw new Exception("cant add less then 9 digits id");
                else
                    id = value;
            }
        }
        public int Mother_Id { get; set; }
        public string First_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public bool Is_Special_Needs { get; set; }
        public string Special_Needs { get; set; }
        public bool Is_Allergy { get; set; }
        public string Allergy { get; set; }//our,
        public bool Without_Diapers { get; set; }//our

        public override string ToString()
        {
            string toPrint = "child: \n Id: " + Id + "\n mom id:  " + Mother_Id + "\n Name: " + First_Name + "\n Age: " + (DateTime.Now.Subtract(Birth_Date).Days) / 30
                +" montes \n "+"special needs: " + Special_Needs + " \n allergies: " + Allergy + "\n Without_Diapers: " + Without_Diapers+"\n";
            return toPrint;
        }

    }
}
