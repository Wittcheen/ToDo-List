using System.Windows.Controls;

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
        public static void NavigateToConfirmSignOut() => Navigator(new Confirm(true));
        public static void NavigateToConfirmDeleteToDo(int toDoID) => Navigator(new Confirm(true, toDoID));
        public static void NavigateToCreateToDo() => Navigator(new CreateToDo());
    }
}
