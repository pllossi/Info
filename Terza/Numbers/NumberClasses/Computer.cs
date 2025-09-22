using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NumberClasses
{
    public class Computer 
    {

        public int NumEven(int numMax=100)
        {
            if (numMax <= 0) throw new ArgumentException("numMax must be greater than 0");
            while (true)
            {
                Random rand = new Random();
                int num = rand.Next(1, numMax);
                if (num % 2 == 0)
                {
                    return num;
                }
            }
        }

        public int NumRand(int numMax=100)
        {
            if (numMax <= 0) throw new ArgumentException("numMax must be greater than 0");
            Random rand = new Random();
            int num = rand.Next(1, numMax);
            return num;
        }
    }
}