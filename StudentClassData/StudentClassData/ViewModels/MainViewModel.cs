﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;


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

            FromModel(ReadXML());
        }

        public MainViewModel(MainData mainData)
        {
            var studentList = mainData.StudentDataList;
            var classList = mainData.ClassDataList;
            AddStudentCommand = new RelayCommand(o => { AddStudent(); }, o => { return true; });
            RemoveStudentCommand = new RelayCommand(o => { RemoveStudent(); }, o => { return true; });
            CommitStudentCommand = new RelayCommand(o => { CommitStudent(); }, o => { return true; });

            AddClassCommand = new RelayCommand(o => { AddClass(); }, o => { return true; });
            RemoveClassCommand = new RelayCommand(o => { RemoveClass(); }, o => { return true; });
            CommitClassCommand = new RelayCommand(o => { CommitClass(); }, o => { return true; });

            List<StudentViewModel> StudentVMList = new List<StudentViewModel>(studentList.Capacity);
            for(int i = 0; i < studentList.Capacity;i++)
            {
                StudentVMList[i] = new StudentViewModel(studentList[i]);
            }
            StudentCollection = new ObservableCollection<StudentViewModel>(StudentVMList);

            List<ClassViewModel> ClassVMList = new List<ClassViewModel>(classList.Capacity);
            for (int i = 0; i < studentList.Capacity; i++)
            {
                ClassVMList[i] = new ClassViewModel(classList[i]);
            }
            ClassCollection = new ObservableCollection<ClassViewModel>(ClassVMList);
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
            WriteXML(ToModel());
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
            WriteXML(ToModel());
        }
        #endregion

        public MainData ToModel()
        {
            var StudentVMList = new ObservableCollection<StudentViewModel>(StudentCollection);
            var StudentList = new List<StudentData>();
            foreach(var item in StudentVMList)
            {
                StudentList.Add(item.ToModel());
            }
            var ClassVMList = new ObservableCollection<ClassViewModel>(ClassCollection);
            var ClassList = new List<ClassData>();
            foreach (var item in ClassVMList)
            {
                ClassList.Add(item.ToModel());
            }
            return new MainData(StudentList, ClassList);
        }

        public void FromModel(MainData mainData)
        {
            var studentList = mainData.StudentDataList;
            var classList = mainData.ClassDataList;
            List<StudentViewModel> StudentVMList = new List<StudentViewModel>();
            foreach(var item in studentList)
            {
                StudentVMList.Add(new StudentViewModel(item));
            }
            StudentCollection = new ObservableCollection<StudentViewModel>(StudentVMList);

            List<ClassViewModel> ClassVMList = new List<ClassViewModel>(classList.Capacity);
            foreach(var item in classList)
            {
                ClassVMList.Add(new ClassViewModel(item));
            }
            ClassCollection = new ObservableCollection<ClassViewModel>(ClassVMList);
        }

        public void WriteXML(MainData mainData)
        {
            XmlSerializer writer = new XmlSerializer(typeof(MainData));

            var path = Directory.GetCurrentDirectory();
            FileStream file = File.Create(Path.Combine(path, @"Objects\SaveFile.xml"));

            writer.Serialize(file, mainData);
            file.Close();
            SaveFileDialog dlg = new SaveFileDialog();
        }

        public MainData ReadXML()
        {
            XmlSerializer reader = new XmlSerializer(typeof(MainData));
            var path = Directory.GetCurrentDirectory();
            StreamReader file = new StreamReader(Path.Combine(path, @"Objects\SaveFile.xml"));
            MainData data = (MainData)reader.Deserialize(file);
            file.Close();
            return data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
