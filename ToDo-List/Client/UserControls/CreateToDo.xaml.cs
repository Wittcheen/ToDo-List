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
