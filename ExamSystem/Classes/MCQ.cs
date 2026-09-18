using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class MCQ:Question
    {
        #region Constructor
        public MCQ(string body, int mark, Answer rightAnswer, Answer[] answers) : base(body, mark, rightAnswer){
            _answers = answers;
            Header = "MCQ Question";
        }
        #endregion


        #region Attributes
        public static int NumberOfChoices = 4;
        private Answer[] _answers = new Answer[NumberOfChoices];
        #endregion


        #region Method

        public override void DisaplyQuestion()
        {
            
            Console.WriteLine($"{Body}");
            foreach (Answer answer in _answers)
            {
                Console.WriteLine($"{answer.AnswerID}- {answer.AnswerText}");
            }
        }

        public override Answer GetAnswer(int answerId)
        {
            return _answers[answerId-1];
        }
       
        #endregion
    }
}
