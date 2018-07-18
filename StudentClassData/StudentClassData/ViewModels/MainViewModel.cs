using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace StudentClassData
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        private RelayCommand addStudentCommand;

        public RelayCommand AddStudentCommand
        {
            get { return addStudentCommand; }
            set { addStudentCommand = value; }
        }

        private RelayCommand removeStudentCommand;

        public RelayCommand RemoveStudentCommand
        {
            get { return removeStudentCommand; }
            set { removeStudentCommand = value; }
        }

        private RelayCommand commitStudentCommand;

        public RelayCommand CommitStudentCommand
        {
            get { return commitStudentCommand; }
            set { commitStudentCommand = value; }
        }

        private RelayCommand addClassCommand;

        public RelayCommand AddClassCommand
        {
            get { return addClassCommand; }
            set { addClassCommand = value; }
        }

        private RelayCommand removeClassCommand;

        public RelayCommand RemoveClassCommand
        {
            get { return removeClassCommand; }
            set { removeClassCommand = value; }
        }

        private RelayCommand commitClassCommand;

        public RelayCommand CommitClassCommand
        {
            get { return commitClassCommand; }
            set { commitClassCommand = value; }
        }

        private StudentData selectedStudent;

        public StudentData SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private ClassData selectedClass;

        public ClassData SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                OnPropertyChanged("SelectedClass");
            }
        }


        #endregion

        public MainViewModel()
        {
            AddStudentCommand = new RelayCommand(o => { addStudent(); }, o => { return true; });
            RemoveStudentCommand = new RelayCommand(o => { removeStudent(); }, o => { return true; });
            CommitStudentCommand = new RelayCommand(o => { commitStudent(); }, o => { return true; });

            AddClassCommand = new RelayCommand(o => { addClass(); }, o => { return true; });
            RemoveClassCommand = new RelayCommand(o => { removeClass(); }, o => { return true; });
            CommitClassCommand = new RelayCommand(o => { commitClass(); }, o => { return true; });

            StudentCollection = new ObservableCollection<StudentData>();
            ClassCollection = new ObservableCollection<ClassData>();

            var thomas = new StudentData(123456, "Thomas Behan", "Male", 18);
            var sebastian = new StudentData(654321, "Sebastian Sanchez", "Male", 17);
           

            var calc = new ClassData(101, true, "Calculus BC AP", 231);
            var gov = new ClassData(321, false, "U.S. Government and Politics", 105);

            StudentCollection.Add(thomas);
            StudentCollection.Add(sebastian);
            

            ClassCollection.Add(calc);
            ClassCollection.Add(gov);
            

        }


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

        private ObservableCollection<ClassData> classCollection;

        public ObservableCollection<ClassData> ClassCollection
        {
            get { return classCollection; }
            set
            {
                classCollection = value;
                OnPropertyChanged("ClassCollection");
            }
        }

        #region Add/Remove/Commit
        public void addStudent()
        {
            var tate = new StudentData(000072, "Tate Bourgeois", "Male", 17);
            StudentCollection.Add(tate);
        }

        public void removeStudent()
        {
            StudentCollection.RemoveAt(StudentCollection.Count()-1);
        }

        public void commitStudent()
        {

        }

        public void addClass()
        {
            var chem = new ClassData(421, true, "Chemistry II AP", 141);
            ClassCollection.Add(chem);
        }

        public void removeClass()
        {
            ClassCollection.RemoveAt(ClassCollection.Count() - 1);
        }

        public void commitClass()
        {

        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
