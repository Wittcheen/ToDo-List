using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }

        public ToDo(string username, string description)
        {
            Username = username;
            Description = description;
        }

        public override string ToString()
        {
            return $"{ID}: {Description}";
        }

        public string ToDoString
        {
            get { return ToString(); }
            private set { }
        }
    }
}
