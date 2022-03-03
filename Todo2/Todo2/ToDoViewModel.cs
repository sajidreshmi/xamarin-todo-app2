using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Todo2
{
    internal class ToDoViewModel: BindableObject
    {
        private ToDoItem _selectedItem;
        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
        }

        public ObservableCollection<ToDoItem> Items { get; set; }

        public String PageTitle { get; set; }

        public ToDoItem SelectedItem { get => _selectedItem;
            set {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            } 
        }
    }
}
