using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalStudents
{
    public class ClassOfStudents
    {
        private Students[] students;
        public ClassOfStudents(int numberOfStudents)
        {
            if(numberOfStudents < 0) { throw new Exception("Il numero di studenti non può essere negativo"); }
            students = new Students[numberOfStudents];
        }
        public void AddStudent(Students student)
        {
            int index = Int32.MaxValue;
            int i = 0;
            while (i < students.Length && index == Int32.MaxValue)
            {
                if (students[i] == null)
                {
                    index = i;
                }
                i++;
            }
            if (index != Int32.MaxValue)
            {
                students[index] = student;
            }
            else
            {
                throw new Exception("Non ci sono più spazi per gli studenti");
            }
        }
        public int CountFailed()
        {
            int count = 0;
            foreach (Students student in students)
            {
                if (student != null && student.ToSufficentGrades() < 6)
                {
                    count++;
                }
            }
            return count;
        }
        public Students[] StudentsFailed()
        {
            Students[] failed = new Students[CountFailed()];
            for (int i = 0,j = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Result()=="failed")
                {
                    failed[j] = students[i];
                    j++;
                }
            }
            return failed;
        }
        public int CountPassed()
        {
            int count = 0;
            foreach (Students student in students)
            {
                if (student != null && student.Result() == "passed")
                {
                    count++;
                }
            }
            return count;
        }
        public Students[] StudentsPassed()
        {
            Students[] passed = new Students[CountPassed()];
            for (int i = 0, j = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Result() == "passed")
                {
                    passed[j] = students[i];
                    j++;
                }
            }
            return passed;
        }
        public int CountSuspended()
        {
            int count = 0;
            foreach (Students student in students)
            {
                if (student != null && student.Result() == "suspended")
                {
                    count++;
                }
            }
            return count;
        }
        public Students[] StudentsSuspended()
        {
            Students[] suspended = new Students[CountSuspended()];
            for (int i = 0, j = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Result() == "suspended")
                {
                    suspended[j] = students[i];
                    j++;
                }
            }
            return suspended;
        }
        public double Average()
        {
            double sum = 0;
            int count = 0;
            foreach (Students student in students)
            {
                if (student != null)
                {
                    sum += student.Average();
                    count++;
                }
            }
            return sum / count;
        }
        public double LowestAverage()
        {
            double lowest = Double.MaxValue;
            foreach (Students student in students)
            {
                if (student != null && student.Average() < lowest)
                {
                    lowest = student.Average();
                }
            }
            return lowest;
        }
        public double HighestAverage() {
            double highest = Double.MinValue;
            foreach (Students student in students)
            {
                if (student != null && student.Average() > highest)
                {
                    highest = student.Average();
                }
            }
            return highest;
        }
        public Students HigthesAverageInASpecificIndex(int index)
        {
            int i=0;
            double previus = Double.MinValue;
            for(int j = 0 ;  j < students.Length; j++)
            {
                if (students[j].Vote(index) > previus)
                {
                    previus = students[i].Vote(index);
                    i=j;
                }
            }
            return students[i];
        }
        public int StudentsWithASpecificMedia(double media)
        {
            int count = 0;
            foreach (Students student in students)
            {
                if (student != null && student.Average() == media)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
