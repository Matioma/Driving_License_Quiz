
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using QuizApp.Model;

namespace QuizApp.Classes
{
    public class AppManager
    {
        private static AppManager instance = null;
        public static AppManager Instance {
            get
            {
                if (instance == null)
                {
                    instance = new AppManager();
                    //instance.Initialize();
                }
                return instance;
            } private set {
                instance = value;
            }
        }

        public QuestionsList questionsCollections;
        private static List<string> availableLanguages = new List<string> {
            "Ro",
            "Ru"
        };

        private string language = availableLanguages[0];
        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                int indexOption = Int32.Parse(value);
                language = availableLanguages[indexOption];
                //language = value;
                OnLanguageChange();
            }
        }

        private AppManager()
        {
        }

        public void Initialize() {
            questionsCollections = DataLoader.LoadJsonData(Language + "Questions.json");
        }


        public Test CreateTest(string _catergory) {
            return new Test(questionsCollections.Questions, 20, _catergory);
        }

        void OnLanguageChange() {
            DataLoader.LoadJsonData(Language + "Questions.json");
            //Console.WriteLine(Language);
        }

    }
}
