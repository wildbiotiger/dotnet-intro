using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project
{
    public class MainViewModel : INotifyPropertyChanged

    {
        public MainViewModel() {

            myVar = 1;
            Name = "2";
            components = new ObservableCollection<string>();

            components.Add("loot");
            components.Add("drops");
            components.Add("aggro");
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                OnPropertyChanged("MyProperty");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        private ObservableCollection<String> components;

        public ObservableCollection<String> Components
        {
            get { return components; }
            set { components = value; OnPropertyChanged("Components"); }
        }

        private string selectedComponent;

        public string SelectedComponent
        {
            get { return selectedComponent; }
            set { selectedComponent = value; OnPropertyChanged("SelectedComponent"); }
        }


        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
