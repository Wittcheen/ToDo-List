using Client.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Client.UserControls
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        private readonly HomeScreen_VM vm = HomeScreen_VM.Instance;

        public HomeScreen()
        {
            InitializeComponent();
            DataContext = vm;

            vm.UsersToDos.Clear();
            vm.UsersToDosCount = 0;
            vm.FillUsersToDos();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToConfirmSignOut();
        }

        private void DeleteToDo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int toDoID = Convert.ToInt32((sender as Button).Tag);
                ContentArea.NavigateToConfirmDeleteToDo(toDoID);
            }
            catch (Exception)
            {
            }
        }

        private void NewToDo_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToCreateToDo();
        }
    }
}
