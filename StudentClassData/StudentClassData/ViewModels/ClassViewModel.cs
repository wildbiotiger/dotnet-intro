using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace StudentClassData
{
    public class ClassViewModel : INotifyPropertyChanged
    {
        private List<StudentData> studentList;

        public List<StudentData> StudentList
        {
            get { return studentList; }
            set { studentList = value; }
        }

        private ObservableCollection<StudentData> studentDataCollection;

        public ObservableCollection<StudentData> StudentDataCollection
        {
            get { return studentDataCollection; }
            set
            {
                studentDataCollection = value;
                OnPropertyChanged("StudentCollection");
            }
        }

        private ObservableCollection<StudentViewModel> studentVMCollection;

        public ObservableCollection<StudentViewModel> StudentVMCollection
        {
            get { return studentVMCollection; }
            set
            {
                studentVMCollection = value;
                OnPropertyChanged("StudentVMCollection");
            }
        }


        public ClassViewModel()
        {
            ClassData classData = new ClassData();
            StudentVMCollection = new ObservableCollection<StudentViewModel>();
        }

        public ClassViewModel(int ClassID, bool IsHonors, string Name, int RoomNumber)
        {
            this.ClassID = ClassID;
            this.IsHonors = IsHonors;
            this.Name = Name;
            this.RoomNumber = RoomNumber;
            StudentVMCollection = new ObservableCollection<StudentViewModel>();
        }

        public ClassViewModel(string name)
        {
            Name = name;
            StudentVMCollection = new ObservableCollection<StudentViewModel>();
        }

        public ClassViewModel(ClassData classData)
        {
            ClassID = classData.ClassID;
            IsHonors = classData.IsHonors;
            Name = classData.Name;
            RoomNumber = classData.RoomNumber;
            StudentVMCollection = new ObservableCollection<StudentViewModel>();

        }

        public ClassData ToModel()
        {
            return new ClassData(ClassID, IsHonors, Name, RoomNumber);
        }

        public ClassViewModel Clone()
        {
            return (ClassViewModel)this.MemberwiseClone();
        }

        private int classID;
        public int ClassID
        {
            get { return classID; }
            set
            {
                classID = value;
                OnPropertyChanged("ClassID");
            }
        }

        private bool isHonors;
        public bool IsHonors
        {
            get { return isHonors; }
            set
            {
                isHonors = value;
                OnPropertyChanged("IsHonors");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int roomNumber;
        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void CopyTo(ClassViewModel des)
        {
            des.ClassID = ClassID;
            des.IsHonors = IsHonors;
            des.Name = Name;
            des.RoomNumber = RoomNumber;
        }
    }
}
