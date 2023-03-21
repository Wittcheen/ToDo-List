using ClassLibrary;
using ClassLibrary.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class HomeScreen_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static HomeScreen_VM? instance;
        private static readonly object padlock = new();

        public static HomeScreen_VM Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new();
                    return instance;
                }
            }
        }

        public HomeScreen_VM()
        {
            UsersToDos = new ObservableCollection<ToDo>();
        }

        public string Username
        {
            get { return SignIn_VM.Instance.Username; }
            set { }
        }

        private ObservableCollection<ToDo> _usersToDos;
        public ObservableCollection<ToDo> UsersToDos
        {
            get { return _usersToDos; }
            set
            {
                _usersToDos = value;
                OnPropertyChanged(nameof(UsersToDos));
            }
        }

        public void FillUsersToDos()
        {
            foreach (var todo in Database.Instance.ImportUsersToDos(Username))
            {
                UsersToDos.Add(todo);
            }
        }
    }
}
