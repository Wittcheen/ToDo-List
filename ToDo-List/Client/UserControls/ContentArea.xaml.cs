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
    /// Interaction logic for ContentArea.xaml
    /// </summary>
    public partial class ContentArea : UserControl
    {
        private static ContentArea? Instance;

        public ContentArea()
        {
            InitializeComponent();
            Instance ??= this;
        }

        private static void Navigator(UserControl control) => Instance.Content = control;

        public static void NavigateToSignIn() => Navigator(new SignIn());
        public static void NavigateToSignUp() => Navigator(new SignUp());
        public static void NavigateToHomeScreen() => Navigator(new HomeScreen());
    }
}
