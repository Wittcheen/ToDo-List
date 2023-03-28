using ClassLibrary;
using ClassLibrary.Database;
using Client.UserControls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModels
{
    public class CreateToDo_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static CreateToDo_VM? instance;
        private static readonly object padlock = new();

        public static CreateToDo_VM Instance
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

        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private string _toDo = string.Empty;
        public string ToDo
        {
            get { return _toDo; }
            set
            {
                _toDo = value;
                OnPropertyChanged(nameof(ToDo));
            }
        }

        public void CreateToDo()
        {
            ToDo = ToDo == null ? string.Empty : ToDo.TrimStart();
            ToDo = ToDo.TrimEnd();

            if (ToDo != string.Empty)
            {
                ToDo todo = new(SignIn_VM.Instance.Username, ToDo);
                Database.Instance.CreateToDo(todo);
                ContentArea.NavigateToHomeScreen();
                ToDo = string.Empty;
                ErrorMessage = string.Empty;
            }
            else
            {
                ErrorMessage = "ERROR! MISSING TO-DO";
            }
        }
    }
}
