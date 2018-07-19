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

        private StudentViewModel selectedStudent;

        public StudentViewModel SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                EditableStudent = SelectedStudent.Clone();
                OnPropertyChanged("SelectedStudent");
            }
        }
        private StudentViewModel editableStudent;

        public StudentViewModel EditableStudent
        {
            get { return editableStudent; }
            set
            {
                editableStudent = value;
                OnPropertyChanged("EditableStudent");
            }
        }


        private ClassViewModel selectedClass;

        public ClassViewModel SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                EditableClass = SelectedClass.Clone();
                OnPropertyChanged("SelectedClass");
            }
        }

        private ClassViewModel editableClass;

        public ClassViewModel EditableClass
        {
            get { return editableClass; }
            set
            {
                editableClass = value;
                OnPropertyChanged("EditableClass");
            }
        }

        private StudentViewModel newStudent;

        public StudentViewModel NewStudent
        {
            get { return newStudent; }
            set
            {
                newStudent = value;
                OnPropertyChanged("NewStudent");
            }
        }

        private ClassViewModel newClass;

        public ClassViewModel NewClass
        {
            get { return newClass; }
            set
            {
                newClass = value;
                OnPropertyChanged("NewClass");
            }
        }


        #endregion



        public MainViewModel()
        {
            AddStudentCommand = new RelayCommand(o => { AddStudent(); }, o => { return true; });
            RemoveStudentCommand = new RelayCommand(o => { RemoveStudent(); }, o => { return true; });
            CommitStudentCommand = new RelayCommand(o => { CommitStudent(); }, o => { return true; });

            AddClassCommand = new RelayCommand(o => { AddClass(); }, o => { return true; });
            RemoveClassCommand = new RelayCommand(o => { RemoveClass(); }, o => { return true; });
            CommitClassCommand = new RelayCommand(o => { CommitClass(); }, o => { return true; });

            StudentCollection = new ObservableCollection<StudentViewModel>();
            ClassCollection = new ObservableCollection<ClassViewModel>();

            var thomas = new StudentViewModel(123456, "Thomas Behan", "Male", 18);
            var sebastian = new StudentViewModel(654321, "Sebastian Sanchez", "Male", 17);
           

            var cal = new ClassViewModel(101, true, "Calculus BC AP", 231);
            var gov = new ClassViewModel(321, false, "U.S. Government and Politics", 105);


            StudentCollection.Add(thomas);
            StudentCollection.Add(sebastian);
            

            ClassCollection.Add(cal);
            ClassCollection.Add(gov);
            

        }


        private ObservableCollection<StudentViewModel> studentCollection;

        public ObservableCollection<StudentViewModel> StudentCollection
        {
            get { return studentCollection; }
            set
            {
                studentCollection = value;
                OnPropertyChanged("StudentCollection");
            }
        }

        private ObservableCollection<ClassViewModel> classCollection;

        public ObservableCollection<ClassViewModel> ClassCollection
        {
            get { return classCollection; }
            set
            {
                classCollection = value;
                OnPropertyChanged("ClassCollection");
            }
        }

        #region Add/Remove/Commit
        public void AddStudent()
        {
            NewStudent = new StudentViewModel("New Student");
            StudentCollection.Add(NewStudent);
        }

        public void RemoveStudent()
        {
            StudentCollection.Remove(SelectedStudent);
        }

        public void CommitStudent()
        {
            if(EditableStudent != null)
                EditableStudent.CopyTo(SelectedStudent);
        }

        public void AddClass()
        {
            var NewClass = new ClassViewModel("New Class");
            ClassCollection.Add(NewClass);

        }

        public void RemoveClass()
        {
            ClassCollection.Remove(SelectedClass);
        }

        public void CommitClass()
        {
            if (EditableClass != null)
                EditableClass.CopyTo(SelectedClass);
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
