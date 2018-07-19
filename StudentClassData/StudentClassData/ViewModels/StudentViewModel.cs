using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace StudentClassData
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public StudentViewModel()
        {

        }
        
        public StudentViewModel(StudentData studentData)
        {
            StudentID = studentData.StudentID;
            FullName = studentData.FullName;
            Gender = studentData.Gender;
            Age = studentData.Age;
        }

        public StudentViewModel(int StudentID, string FullName, string Gender, int Age)
        {
            this.StudentID = StudentID;
            this.FullName = FullName;
            this.Gender = Gender;
            this.Age = Age;
        }

        public StudentViewModel(string FullName)
        {
            this.FullName = FullName;
        }

        public StudentData ToModel()
        {
            return new StudentData(studentID, fullName, gender, age);
        }

        private int studentID;

        public int StudentID
        {
            get { return studentID; }
            set
            {
                studentID = value;
                OnPropertyChanged("StudentID");
            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public StudentViewModel Clone()
        {
            return (StudentViewModel) this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void CopyTo(StudentViewModel dest)
        {
            dest.StudentID = StudentID;
            dest.FullName = FullName;
            dest.Gender = Gender;
            dest.Age = Age;
            
        }
    }
}
