using Xamarin.Forms;

namespace ToDo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToDoView())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.FromHex("#1b1091")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
