using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ToDo
{
    public class ToDoViewModel : BindableObject
    {
        public event EventHandler<double> UpdateProgressBar;

        private IDialogMessage _dialogMessage;

        public ToDoViewModel(IDialogMessage dialogMessage)
        {
            _dialogMessage = dialogMessage;
            Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            CalculateCompletedHeader();
        }

        public ObservableCollection<ToDoItem> Items { get; set; }
        public string PageTitle { get; set; }

        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public ToDoItem SelectedTodo
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }

        public string CompletedHeader
        {
            get => _completedHeader;
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }

        public double CompletedProgress
        {
            get => _completedProgress; 
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddItemCommand => new Command(async () => { await AddNewItem(); });

        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        private async Task AddNewItem()
        {
            string newItem = await _dialogMessage.DisplayPrompt("New Task", "Please enter a new task name");
            Items.Add(new ToDoItem(newItem));
        }

        private void MarkAsCompleted(ToDoItem item)
        {
            item.Completed = true;
            Items.Remove(item);
            Items.Add(item);
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            CompletedHeader = $"Completed {Items.Count(x => x.Completed)}/{Items.Count}";
            CompletedProgress = (double)Items.Count(x => x.Completed)/(double)Items.Count;
            UpdateProgressBar?.Invoke(this, CompletedProgress);
        }
    }
}
