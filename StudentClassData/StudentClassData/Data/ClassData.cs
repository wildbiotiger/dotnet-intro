using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassData
{
    public class ClassData
    {
        public List<StudentData> StudentList = new List<StudentData>();

        public ClassData()
        {
               
        }

        public ClassData(string className)
        {
            Name = className;
        }

        public ClassData(int classID, bool isHonors, string name, int roomNumber)
        {
            ClassID = classID;
            IsHonors = isHonors;
            Name = name;
            RoomNumber = roomNumber;
        }

        public int ClassID { get; set; }
        public bool IsHonors { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
    }
}
