using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    [Serializable]
    public class Mother

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
        public long Phone_Number { get; set; }
        public string Home_Street { get; set; }
        public string Home_City { get; set; }
        public string Home_Country { get; set; }
        public string Wanted_Street { get; set; }
        public string Wanted_City { get; set; }
        public string Wanted_Country { get; set; }
        public bool[] Wanted_Days = new bool[7] { false, false, false, false, false, false, false };

        [XmlIgnore]//for serilaize to xml because cant convert to string
        public DateTime[,] Wanted_Hours = new DateTime[2, 7];
        public string Help_Matrix
        {
            get//return matrix as string
            {
                string result = "";
                if (Wanted_Hours != null)//succeded to intiliaze
                {
                    result += Wanted_Hours[0, 0];//while adding know to convert to string
                    for (int i = 0; i < 2; i++)//rows
                        for (int j = 0; j < 7; j++)//coulmns
                            if(i!=0||j!=0)//we already have the first place so dont want to add again
                               result += "," + Wanted_Hours[i, j];
                   
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
                            Wanted_Hours[i, j] = DateTime.Parse(values[index++]);//insert
                }
            }
        }

        public int Min_Years_Experience { get; set; }//our
        public bool Food_From_Nanny { get; set; }//our
        public bool Want_Hour_Salary { get; set; }//our
        public bool Take_By_Car { get; set; }//our
        public bool Smoking_Nanny { get; set; }//our
        public bool Religious_Nanny { get; set; }//our
        public string Comments { get; set; }

        public override string ToString()
        {
            string toPrint = "mother: \n Id: " + Id + " \n Name: " + First_Name + " " + Family_Name 
          + "\n Phone: " + Phone_Number + " \n adress: " + Home_Country + " " + Home_City + " " + Home_Street
          + " \n wanted nanny adress: " + Wanted_Country + " " + Wanted_City + " " + Wanted_Street + "\n wanted days: ";

            for (int i = 0; i < 7; i++)
            {
                if (Wanted_Days[i] == true)//mom wants this day
                    toPrint += (Days)i + " ";
            }
            toPrint += "\n start wanted hour: ";
            for (int i = 0; i < 7; i++)
            {
                toPrint += Wanted_Hours[0, i].ToShortTimeString() + " ";
            }
            toPrint += "\n end wanted hour:   ";
            for (int i = 0; i < 7; i++)
            {
                toPrint += Wanted_Hours[1, i].ToShortTimeString() + " ";
            }
            toPrint += "\n Minimum required years of experience: " + Min_Years_Experience + "\n Want Food From Nanny: " + Food_From_Nanny
                + "\n Want Per Hour Salary: " + Want_Hour_Salary + "\n Take child to nanny by car: " + Take_By_Car 
                + "\n enable smoking nanny: " + Smoking_Nanny + "\n Wants Religious Nanny: " + Religious_Nanny + "\n comments: "+Comments+"\n";
            return toPrint;
        }

    }
}
