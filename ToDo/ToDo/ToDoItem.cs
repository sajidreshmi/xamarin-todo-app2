using System.Collections.Generic;
using Xamarin.Forms;

namespace ToDo
{
    public class ToDoItem : BindableObject
    {
        private bool completed;

        public ToDoItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool Completed
        {
            get => completed;
            set
            {
                completed = value;
                OnPropertyChanged();
            }
        }

        public static IEnumerable<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Go to work"),
                new ToDoItem("Have a dev meeting"),
                new ToDoItem("Lunch time"),
                new ToDoItem("Go to gym"),
                new ToDoItem("Family time")
            };
        }
    }
}
