using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassData
{
    public class StudentData
    {

        public StudentData(int studentID, string fullName, string gender, int age)
        {
            StudentID = studentID;
            FullName = fullName;
            Gender = gender;
            Age = age;
        }

        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

      
    }
}
