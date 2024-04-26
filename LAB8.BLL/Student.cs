using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8.BLL
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public int Index { get; set; }
        public IList<double> Grades { get; set; }
        public string GradesAsString 
        { 
            get
            { 
                if(Grades != null) 
                    return string.Join(", ", Grades);

                return "No Grades";
            } 
        }
        public Student(string FName, string LName, string fac, int id)
        {
            FirstName = FName;
            LastName = LName;
            Faculty = fac;
            Index = id;
            Grades = new List<double>();
        }
        public Student() { }
    }
}
