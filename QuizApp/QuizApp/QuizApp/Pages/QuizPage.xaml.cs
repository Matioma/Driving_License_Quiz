using QuizApp.Classes;
using QuizApp.Model;
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
    public partial class QuizPage : ContentPage
    {
        private Test test;
        private int wrongAnswers = 0;
        private int rightAnswers = 0;

        private bool singleQuestion = false;

        public QuizPage()
        {
            InitializeComponent();

            BindingContext = AppManager.Instance.questionsCollections.Questions[0];
            RemoveExtraButtons();
           

        }
        public QuizPage(Test test) {
            InitializeComponent();
            this.test = test;
            BindingContext = this.test.GetCurrentQuestion();
            RemoveExtraButtons();
            UpdateStatsText();
        }
        public QuizPage(Question question)
        {
            InitializeComponent();
            //this.test = test;
            BindingContext = question;
            RemoveExtraButtons();
            singleQuestion = true;
            //UpdateStatsText();
        }

        private void MainMenu_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }




        void MakeAllButtonVisible()
        {
            foreach (Button button in Buttons.Children)
            {
                button.IsVisible = true;
            }
        }

        void RemoveExtraButtons() {
            foreach(Button button in Buttons.Children) {
                if (button.Text == "" || button.Text == null)
                {
                    button.IsVisible = false;
                }
            }
            
        }
        void TestFinished()
        {
            App.Current.MainPage = new QuizStatsPage((float)rightAnswers/test.NumberOfQuestions * 100);
        }
        void UpdateStatsText() {
            Stats.Text = test.CurrentQuestionIndex+1 + "/" + test.NumberOfQuestions;
            RightAnswers.Text = rightAnswers + "/";
            WrongAnswers.Text = wrongAnswers.ToString();
        }


        void OpenNextQuestion() {
            Question question = test.GetNextQuestion();
            if (question != null)
            {
                MakeAllButtonVisible();
                BindingContext = question;
                RemoveExtraButtons();
            }
            else {
                TestFinished();
            }
        }
        void RightOptionSelected()
        {
            rightAnswers++;
            OpenNextQuestion();
        }
        void WrongOptionSelected() {
            wrongAnswers++;
            OpenNextQuestion();
        }

        async void CheckAnswerCorrectness(int i) {
            if (singleQuestion) {
                Question question = (Question)BindingContext;
                if (question.RightAnswer == i)
                {
                    bool answer = await DisplayAlert("Raspuns corect!", "Alta intrebare?", "Da", "Nu");
                    if (answer)
                    {
                        App.Current.MainPage = new QuetionsListPage();
                    }
                    else {
                        App.Current.MainPage = new MainPage();
                    }
                }
                else {
                    bool answer = await DisplayAlert("Raspuns Incorect!", "Incercati din nou?", "Da", "Nu");
                    if (answer)
                    {
                    }
                    else {
                        App.Current.MainPage = new MainPage();
                    }
                }
                return;
            }
            if (i == test.GetCurrentQuestion().RightAnswer)
            {
                RightOptionSelected();
            }
            else
            {
                WrongOptionSelected();
            }
            UpdateStatsText();
        }

        private void Answer1_Clicked(object sender, EventArgs e)
        {
            int i = 1;
            CheckAnswerCorrectness(i);
        }
        private void Answer2_Clicked(object sender, EventArgs e)
        {
            int i = 2;
            CheckAnswerCorrectness(i);
        }
        private void Answer3_Clicked(object sender, EventArgs e)
        {
            int i = 3;
            CheckAnswerCorrectness(i);
        }
        private void Answer4_Clicked(object sender, EventArgs e)
        {
            int i = 4;
            CheckAnswerCorrectness(i);
        }
        private void Answer5_Clicked(object sender, EventArgs e)
        {
            int i = 5;
            CheckAnswerCorrectness(i);
        }
      
    }
}