using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentClassData
{
    [Serializable]
    public class MainData
    {

        public MainData()
        {
            StudentDataList = new List<StudentData>();
            ClassDataList = new List<ClassData>();
        }

        public MainData(List<StudentData> studentList, List<ClassData> classList)
        {
            StudentDataList = studentList;
            ClassDataList = classList;
        }

        private List<StudentData> studentDataList;

        public List<StudentData> StudentDataList
        {
            get { return studentDataList; }
            set { studentDataList = value; }
        }

        private List<ClassData> classDataList;

        public List<ClassData> ClassDataList
        {
            get { return classDataList; }
            set { classDataList = value; }
        }

    }
}
