using ClassLibrary.Database;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                throw;
            }
        }

        private void NewToDo_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToCreateToDo();
        }
    }
}
