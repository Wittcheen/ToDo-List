using ClassLibrary;
using ClassLibrary.Database;
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
    public class SignUp_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static SignUp_VM? instance;
        private static readonly object padlock = new();

        public static SignUp_VM Instance
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

        public SignUp_VM()
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

        public void SignUp(string password, string password1)
        {
            Username = Username == null ? string.Empty : Username.Trim();
            password = password == null ? string.Empty : password.Trim();
            password1 = password1 == null ? string.Empty : password1.Trim();

            if (Username != string.Empty)
            {
                Username = Username.ToLower();
                if (password != string.Empty && password1 != string.Empty && password == password1)
                {
                    bool validateUser = User.UserExist(Username);
                    if (validateUser == false)
                    {
                        string hashedPassword = User.HashPassword(password);
                        User user = new(Username, hashedPassword);
                        Database.Instance.InsertUser(user);
                        ContentArea.NavigateToSignIn();
                    }
                    else
                    {
                        ErrorMessage = "ERROR! USER ALREADY EXIST";
                    }

                }
                else
                {
                    ErrorMessage = "ERROR! PASSWORD ISN'T THE SAME";
                }
            }
            else
            {
                ErrorMessage = "ERROR! MISSING USERNAME";
            }
        }
    }
}
