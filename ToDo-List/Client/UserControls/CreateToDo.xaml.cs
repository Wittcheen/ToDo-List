using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.UserControls
{
    /// <summary>
    /// Interaction logic for CreateToDo.xaml
    /// </summary>
    public partial class CreateToDo : UserControl
    {
        private readonly CreateToDo_VM vm = CreateToDo_VM.Instance;

        public CreateToDo()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToHomeScreen();
        }

        private void CreateToDo_Click(object sender, RoutedEventArgs e)
        {
            vm.CreateToDo();
        }
    }
}
