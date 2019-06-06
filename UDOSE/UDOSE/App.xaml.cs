using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UDOSE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var navPage = new NavigationPage(new MainPage());
            Application.Current.MainPage = navPage;
            //  MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
