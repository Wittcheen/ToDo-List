using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.UserControls
{
    /// <summary>
    /// Interaction logic for CreateToDo.xaml
    /// </summary>
    public partial class EditToDo : UserControl
    {
        private readonly EditToDo_VM vm = EditToDo_VM.Instance;
        private int ToDoID;

        public EditToDo(int toDoID)
        {
            InitializeComponent();
            DataContext = vm;

            vm.FillToDo(toDoID);
            ToDoID = toDoID;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToHomeScreen();
        }

        private void EditToDo_Click(object sender, RoutedEventArgs e)
        {
            vm.EditToDo(ToDoID);
        }
    }
}
