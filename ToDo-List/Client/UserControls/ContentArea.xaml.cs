using ClassLibrary;
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
        public static void NavigateToConfirmEditToDo(int toDoID, ToDo toDo) => Navigator(new Confirm(true, toDo, toDoID));
        public static void NavigateToConfirmDeleteToDo(int toDoID) => Navigator(new Confirm(true, toDoID));
        public static void NavigateToCreateToDo() => Navigator(new CreateToDo());
        public static void NavigateToEditToDo(int toDoID) => Navigator(new EditToDo(toDoID));
    }
}
