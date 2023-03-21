using ClassLibrary.Database;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Client.UserControls;

namespace Client.ViewModels
{
    public class Confirm_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static Confirm_VM? instance;
        private static readonly object padlock = new();

        public static Confirm_VM Instance
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

        public Confirm_VM()
        {
        }

        public string Username
        {
            get { return SignIn_VM.Instance.Username; }
            set { }
        }

        private string _confirmMessage = string.Empty;
        public string ConfirmMessage
        {
            get { return _confirmMessage; }
            set
            {
                _confirmMessage = value;
                OnPropertyChanged(nameof(ConfirmMessage));
            }
        }
    }
}
