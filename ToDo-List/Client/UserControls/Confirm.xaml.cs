using ClassLibrary;
using ClassLibrary.Database;
using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.UserControls
{
    /// <summary>
    /// Interaction logic for Confirm.xaml
    /// </summary>
    public partial class Confirm : UserControl
    {
        private readonly Confirm_VM vm = Confirm_VM.Instance;
        private bool SignOut;
        private bool EditToDo;
        private bool DeleteToDo;
        private ToDo ToDo;
        private int ToDoID;

        public Confirm(bool signOut)
        {
            InitializeComponent();
            DataContext = vm;

            SignOut = signOut;
            if (signOut == true)
            {
                vm.ConfirmMessage = "Are you sure, you wan't to sign out?";
            }
            else
            {
                vm.ConfirmMessage = "ERROR!";
            }
        }

        public Confirm(bool editToDo, ToDo toDo, int toDoID)
        {
            InitializeComponent();
            DataContext = vm;

            EditToDo = editToDo;
            ToDoID = toDoID;
            ToDo = toDo;
            if (editToDo == true)
            {
                vm.ConfirmMessage = $"Are you sure, you wan't to edit to-do {toDoID}?";
            }
            else
            {
                vm.ConfirmMessage = "ERROR!";
            }
        }

        public Confirm(bool deleteToDo, int toDoID)
        {
            InitializeComponent();
            DataContext = vm;

            DeleteToDo = deleteToDo;
            ToDoID = toDoID;
            if (deleteToDo == true)
            {
                vm.ConfirmMessage = $"Are you sure, you wan't to delete to-do {toDoID}?";
            }
            else
            {
                vm.ConfirmMessage = "ERROR!";
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (SignOut == true)
            {
                ContentArea.NavigateToSignIn();
            }
            if (EditToDo == true)
            {
                Database.Instance.EditToDo(ToDo, ToDoID);
                ContentArea.NavigateToHomeScreen();
            }
            if (DeleteToDo == true)
            {
                Database.Instance.DeleteToDo(ToDoID);
                ContentArea.NavigateToHomeScreen();
            }
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToHomeScreen();
        }
    }
}
