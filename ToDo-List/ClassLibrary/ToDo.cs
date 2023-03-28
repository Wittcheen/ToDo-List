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
    }
}
