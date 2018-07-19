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
        private ObservableCollection<StudentData> studentCollection;

        public ObservableCollection<StudentData> StudentCollection
        {
            get { return studentCollection; }
            set
            {
                studentCollection = value;
                OnPropertyChanged("StudentCollection");
            }
        }

        public ClassViewModel()
        {
            ClassData classData = new ClassData();
            StudentCollection = new ObservableCollection<StudentData>(classData.StudentList);
        }

        public ClassViewModel(int ClassID, bool IsHonors, string Name, int RoomNumber)
        {
            this.ClassID = ClassID;
            this.IsHonors = IsHonors;
            this.Name = Name;
            this.RoomNumber = RoomNumber;
            
        }


        public ClassViewModel(string name)
        {
            Name = name;
        }

        public ClassViewModel(ClassData classData)
        {
            ClassID = classData.ClassID;
            IsHonors = classData.IsHonors;
            Name = classData.Name;
            RoomNumber = classData.RoomNumber;
            StudentCollection = new ObservableCollection<StudentData>(classData.StudentList);

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
                name = value; }
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

        internal void CopyTo(ClassViewModel dest)
        {
            dest.ClassID = ClassID;
            dest.IsHonors = IsHonors;
            dest.Name = Name;
            dest.RoomNumber = RoomNumber;
        }
    }
}
