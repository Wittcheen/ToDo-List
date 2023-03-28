using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client.UserControls
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        private readonly SignUp_VM vm = SignUp_VM.Instance;

        public SignUp()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string password = Box_Password.Password.ToString();
            string password1 = Box_Password1.Password.ToString();
            vm.SignUp(password, password1);
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToSignIn();
        }
    }
}
