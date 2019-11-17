
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Classes;
using QuizApp.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            BindingContext = AppManager.Instance;
            //LanguageSelection.SelectedIndex = 0;
                InitializeComponent();
        }

        private void TakeTest_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CategorySelection();
        }
        private void Practice_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new QuetionsListPage();
        }
    }
}