using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeGesting
{
    public class Date
    {
        public int year
        {
            get
            {
                return this.year;
            }
            private set
            {
                if (value > 0)
                    throw new ArgumentException("L'anno è negativo");
                this.year = value;
            }
        }

        public int month
        {
            get 
            {
                return this.month;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Il mese é negativo");
                }
                while (value > 12) 
                { 
                    value -= 12;
                    year++;
                }
                this.month = value;
                    
            }
        }
        public int day
        {
            get
            {
                return this.day;
            }
            private set 
            {
                while ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && value > 29)
                {
                    month++;
                    value -= 30;
                }
                while ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                {
                    month++;
                    value -= 31;
                }
                if (year % 4 == 0 && day > 28) 
                {
                    month++;
                    value -= 28;
                }
                if(year%4 != 0 && day > 27)
                {
                    month++;
                    value -= 27;
                }
                this.day = value;
            }
         

    }
}
