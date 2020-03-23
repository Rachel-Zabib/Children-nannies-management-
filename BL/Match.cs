using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    /// <summary>
    /// class for find five best nannies that are matching to mom
    /// help in sorting them by their difeerences days and hours
    /// </summary>
   
    public class Match : IComparable
    {
       public Nanny nan;
       public  int day_difference=0;
       public  double hour_difference = 0;
        public int CompareTo(object obj)
        {
            Match m = obj as Match;
            if (day_difference > m.day_difference)
                return 1;
            if(day_difference < m.day_difference)
                return -1;
            //if (day_difference == m.day_difference)
            //{
                if (hour_difference > m.hour_difference)
                    return 1;
                if (hour_difference < m.hour_difference)
                    return -1;
                //if (hour_difference == m.hour_difference)
                    return 0;
            //}
                
        }
    }
}
