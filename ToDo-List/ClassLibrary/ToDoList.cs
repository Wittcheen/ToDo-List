using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ClassLibrary
{
    public class ToDoList
    {
        public static ObservableCollection<User> Users = new();

        public static ObservableCollection<ToDo> ToDos = new();
    }
}
