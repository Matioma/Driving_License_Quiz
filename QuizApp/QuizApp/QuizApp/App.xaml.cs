
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizApp.Pages;
using QuizApp.Classes;

namespace QuizApp
{
    public partial class App : Application
    {
        public AppManager appManger;

        public App()
        {
            InitializeComponent();
            appManger = AppManager.Instance;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            appManger.Initialize();

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
