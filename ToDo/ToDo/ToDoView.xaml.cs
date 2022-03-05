using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoView : ContentPage
    {
        public ToDoView()
        {
            InitializeComponent();
            ToDoViewModel toDoViewModel = new ToDoViewModel(new DialogMessage());
            BindingContext = toDoViewModel;
            toDoViewModel.UpdateProgressBar += ToDoViewModel_UpdateProgressBar;
        }

        private async void ToDoViewModel_UpdateProgressBar(object sender, double e)
        {
            await progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}
