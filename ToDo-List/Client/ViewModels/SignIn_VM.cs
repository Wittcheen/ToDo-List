using Client.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class SignIn_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static SignIn_VM? instance;
        private static readonly object padlock = new();

        public static SignIn_VM Instance
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

        public SignIn_VM()
        {
            Username = string.Empty;
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

        public string Username { get; set; }

        public void SignIn(string password)
        {
            Username = Username == null ? string.Empty : Username.Trim();
            password = password == null ? string.Empty : password.Trim();
            if (Username != string.Empty)
            {
                Username = Username.ToLower();
                if (password != string.Empty)
                {
                    bool validateLogin = ClassLibrary.User.ValidateLogin(Username, password);
                    if (validateLogin == true)
                    {
                    }
                    else
                    {
                        ErrorMessage = "ERROR! WRONG USERNAME OR PASSWORD";
                    }
                }
                else
                {
                    ErrorMessage = "ERROR! MISSING PASSWORD";
                }
            }
            else
            {
                ErrorMessage = "ERROR! MISSING USERNAME";
            }
        }
    }
}