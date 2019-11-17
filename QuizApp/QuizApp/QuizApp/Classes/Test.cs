using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Classes
{
    public class Test
    {
        public int CurrentQuestionIndex { get;private set; } = 0;
        public int NumberOfQuestions { get;private set; }
        public List<Question> questionList = new List<Question>();
        public Test(List<Question> _questionCollection, int _questionNumber, string _catergory) {
            Random random = new Random();
            int index;
            NumberOfQuestions = _questionNumber;
            for (int i = 0; i < _questionNumber; i++) {
                do
                {
                    index = random.Next(0, _questionCollection.Count);
                } while (questionList.Contains(_questionCollection[index]) || !_questionCollection[index].category.Equals(_catergory));
                questionList.Add(_questionCollection[index]);
            }
        }


        public Question GetNextQuestion()
        {
            if (CurrentQuestionIndex + 1 < NumberOfQuestions)
            {
                CurrentQuestionIndex++;
                return questionList[CurrentQuestionIndex];
            }
            return null;
        }

        public Question GetCurrentQuestion() {
            return questionList[CurrentQuestionIndex];
        }
    }
}
