using Client.UserControls;
using MahApps.Metro.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : MetroWindow
    {
        public StartWindow()
        {
            InitializeComponent();
            ContentArea.NavigateToSignIn();
        }
    }
}
