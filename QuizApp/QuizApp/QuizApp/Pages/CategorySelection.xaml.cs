using QuizApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategorySelection : ContentPage
    {
        public CategorySelection()
        {
            InitializeComponent();
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
        private void AB_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new QuizPage(AppManager.Instance.CreateTest("AB"));
        }
        private void C_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new QuizPage(AppManager.Instance.CreateTest("C"));
        }
        private void D_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new QuizPage(AppManager.Instance.CreateTest("D"));
        }
        private void E_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new QuizPage(AppManager.Instance.CreateTest("E"));
        }
    }
}