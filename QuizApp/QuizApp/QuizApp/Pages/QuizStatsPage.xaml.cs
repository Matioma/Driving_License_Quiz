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
    public partial class QuizStatsPage : ContentPage
    {
        double result=0;
        public QuizStatsPage()
        {
            InitializeComponent();
        }
        public QuizStatsPage(double rightPercent)
        {
            InitializeComponent();
            Result.Text = string.Format("{0:N2}%", rightPercent);
            //result = rightPercent;
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void TakeAnotherTest_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CategorySelection();
        }
    }
}