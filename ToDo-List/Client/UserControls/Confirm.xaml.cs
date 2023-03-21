﻿using ClassLibrary.Database;
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
    /// Interaction logic for Confirm.xaml
    /// </summary>
    public partial class Confirm : UserControl
    {
        private readonly Confirm_VM vm = Confirm_VM.Instance;
        private bool SignOut;
        private bool DeleteToDo;
        private int ToDoID;

        public Confirm(bool signOut)
        {
            InitializeComponent();
            DataContext = vm;

            SignOut = signOut;
            if (signOut == true)
            {
                vm.ConfirmMessage = "Are you sure, you wan't to sign out?";
            }
        }

        public Confirm(bool deleteToDo, int toDoID)
        {
            InitializeComponent();
            DataContext = vm;

            DeleteToDo = deleteToDo;
            ToDoID = toDoID;
            if (deleteToDo == true)
            {
                vm.ConfirmMessage = $"Are you sure, you wan't to delete to-do {toDoID}?";
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (SignOut == true)
            {
                ContentArea.NavigateToSignIn();
            }
            if (DeleteToDo == true)
            {
                Database.Instance.DeleteToDo(ToDoID);
                ContentArea.NavigateToHomeScreen();
            }
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.NavigateToHomeScreen();
        }
    }
}
