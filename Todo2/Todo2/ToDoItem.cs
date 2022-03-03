using System;
using System.Collections.Generic;
using System.Text;

namespace Todo2
{
    internal class ToDoItem
    {
        public ToDoItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public bool Completed { get; set; }

        public static IEnumerable<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Go to work"),
                new ToDoItem("Have a dev meeting"),
                new ToDoItem("Lunch Item"),
                new ToDoItem("Go to Gym"),
                new ToDoItem("Family time")
            };
        }
    }
}
