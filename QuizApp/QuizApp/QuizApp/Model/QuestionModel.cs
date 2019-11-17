using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Model
{
    public class Question
    {
        public string id { get; set; }
        public string category { get; set; }
        public string imageUrl { get; set; }
        public string questionMessage { get; set; }
        public List<string> Options { get; set; }
        public int RightAnswer { get; set; }
        public string Explanation { get; set; }
    }

    public class QuestionsList
    {
        public List<Question> Questions { get; set; }
    }
}
