using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using QuizApp.Model;

namespace QuizApp.Classes
{
    public static class DataLoader{
        public static QuestionsList LoadJsonData(string jsonFileName)
        {
            jsonFileName = "Questions.json";
            QuestionsList ObjContactList = new QuestionsList();
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Converting JSON Array Objects into generic list    
                ObjContactList = JsonConvert.DeserializeObject<QuestionsList>(jsonString);
            }
            return ObjContactList;
            //BindingContext = ObjContactList.contacts[1];
        }
        

        public static void WriteJsonData(QuestionsList list)
        {

        }
    }
}
