using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]
    public class Nanny
    {

        private int id;
        public int Id
        {
            get
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
        public string Family_Name { get; set; }
        public string First_Name { get; set; }
        public DateTime Birth_Date { get; set; }
        public long Phone_Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Elevator { get; set; }
        public int Floor { get; set; }
        public float Years_Experience { get; set; }
        public int Max_Children { get; set; }
        public int Min_Kid_Age { get; set; }
        public int Max_Kid_Age { get; set; }
        public bool Is_Hour_Salary { get; set; }
        public float Hour_Salary { get; set; }
        public float Month_Salary { get; set; }
        public bool[] Work_Day = new bool[7] { false, false, false, false, false, false, false };

        [XmlIgnore]
        public DateTime[,] Work_Hours = new DateTime[2, 7];
        public string Help_Matrix
        {
            get//return matrix as string
            {
                string result = "";
                if (Work_Hours != null)//succeded to intiliaze
                {
                    result += Work_Hours[0, 0];//while adding know to convert to string
                    for (int i = 0; i < 2; i++)//rows
                        for (int j = 0; j < 7; j++)//coulmns
                            if (i != 0 || j != 0)//we already have the first place so dont want to add again
                                result += "," + Work_Hours[i, j];

                }
                return result;
            }
            set//set values in matrix from string
            {
                if (value != null && value.Length > 0)//there is string to take values from
                {
                    int index = 0;
                    string[] values = value.Split(',');//divide all string toeach value of matrix 
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 7; j++)
                            Work_Hours[i, j] = DateTime.Parse(values[index++]);//insert
                }
            }
        }



        public bool Vacation_By_Education { get; set; }
        public bool Vacation_By__Tmt { get; set; }
        public string Recommendations { get; set; }
        public bool Is_Religious { get; set; }//our
        public bool Is_OutDoors { get; set; }//our
        public bool Smoking { get; set; }//our
        public bool Comfort_With_Pets { get; set; }//our
        public bool[] Spoken_Languages = new bool[6] { false, false, false, false, false, false };//our
        public bool Gives_Food{get;set;}

        public override string ToString()
        {
            string toPrint = "Nanny: \n Id: " + Id + " \n Name: " + First_Name + " " + Family_Name + "\n Age: " + (DateTime.Now.Subtract(Birth_Date).Days)/365
                + "\n Phone: " + Phone_Number + " \n adress: " +Country+" "+City+" "+Street+ "\n Elevator:"+Elevator
                + "\n floor: "+Floor+ "\n Years Experience: " + Years_Experience + "\n max amount of children: " + Max_Children+ "\n range of ages: " + Min_Kid_Age +"-"+Max_Kid_Age
                + "\n enable hour salary: " + Is_Hour_Salary+ "\n salary per hour: " + Hour_Salary + "\n salary per month: " + Month_Salary + "\n work days: " ;
          for (int i = 0; i < 7; i++)
            {
                if (Work_Day[i] == true)//nanny works in this day
                    toPrint += (Days)i+" ";
            }
            toPrint += "\n start work hours: ";
            for (int i = 0; i < 7; i++)
            {
                toPrint += Work_Hours[0, i].ToShortTimeString()+" ";
            }
            toPrint += "\n end work hours:  ";
            for (int i = 0; i < 7; i++)
            {
                toPrint += Work_Hours[1, i].ToShortTimeString() + " ";
            }
            toPrint += "\n Vacation By Education: " + Vacation_By_Education + "\n Vacation By TMT: " + Vacation_By__Tmt
                + "\n Recommendations: " + Recommendations + "\n religious: " + Is_Religious + "\n can keep in other houses: " + Is_OutDoors
                + "\n smoking: " + Smoking + "\n agree to keep in houses with pets: " + Comfort_With_Pets+ "\n spoken Languages: ";
            for (int i = 0; i < 6; i++)
            {
                if (Spoken_Languages[i] == true)//nanny knows this Language
                    toPrint += (Languages)i + " ";
            }
            toPrint += "\n gives food: " + Gives_Food+"\n";

            return toPrint;
        }
 
    }
}
