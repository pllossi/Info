using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeGesting
{
    public class Hours
    {
        public int Hour 
        {
            get {  return Hour; }
            private set 
            {
                if (value < 0)
                {
                    value= 24-value;
                }
                if (value >= 24)
                {
                    value = 0;
                }
                Hour = value;
            }
        }
        public int Minutes
        {
            get { return Minutes; }
            private set
            {
                if (value < 0)
                {
                    Hour--;
                    value = 60 - value;
                }
                if (value >= 60)
                {
                    Hour++;
                    value = value - 60;
                }

            }
        }
        
        public Hours(int hoursValue=0, int minutesValue = 00)
        {
            if (hoursValue < 0) {
                throw new ArgumentOutOfRangeException("Le ore sono negative");
            }
            Hour=hoursValue;
            if (minutesValue < 0)
            {
                throw new ArgumentOutOfRangeException("I minuti sono negativi");
            }
            Minutes = minutesValue;
        }
        
        public bool isAm() 
        {
            if (Hour < 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertHours (int toAdd)
        {
            Hour += toAdd;
        }

        public void InsertMinutes(int toAdd)
        {
            Minutes += toAdd;
        }

        public override bool Equals(object? obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(obj is Hours)
            {
                return false;
            }
            Hours obj2 = obj as Hours;
            if (obj2.Hour == Hour && obj2.Minutes == Minutes)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"${Hour}:${Minutes}";
        }
    }
}
