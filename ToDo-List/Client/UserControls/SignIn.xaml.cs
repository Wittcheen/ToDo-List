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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        private readonly SignIn_VM vm = SignIn_VM.Instance;

        public SignIn()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToSignUp();
        }

        public void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string password = Box_Password.Password.ToString();
            vm.SignIn(password);
        }
    }
}
