using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;

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

        public ICommand AddItemCommand => new Command(() =>
        {
            AddNewItem();
        });

        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        private void MarkAsCompleted(ToDoItem obj)
        {
            obj.Completed = true;
        }

        private void AddNewItem()
        {
            Items.
               Add(new ToDoItem($"Todo Item {Items.Count + 1}"));
        }
    }
}
