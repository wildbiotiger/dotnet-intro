using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassData
{
    [Serializable]
    public class ClassData
    {
        private List<StudentData> studentDataList;

        public List<StudentData> StudentDataList
        {
            get { return studentDataList; }
            set { studentDataList = value; }
        }


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
