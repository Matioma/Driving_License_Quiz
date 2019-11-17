using QuizApp.Classes;
using QuizApp.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuetionsListPage : ContentPage
    {
        public ObservableCollection<Question> Items { get; set; }
        //public ObservableCollection<string> Items { get; set; }

        public QuetionsListPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<Question>();

            foreach (var question in AppManager.Instance.questionsCollections.Questions) {
                Items.Add(question);
            }

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            App.Current.MainPage = new QuizPage((Question)((ListView)sender).SelectedItem);

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
