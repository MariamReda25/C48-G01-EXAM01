using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class FinalExam:Exam
    {
        public FinalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) {
            Title = "Final Exam";

        }

        public override void ShowExam(Answer[] userAnswers)
        {
            Console.WriteLine($" {Title} Results");

            for (int i=0;i<NumberOfQuestions;i++ )
            {
                Console.WriteLine($"Question {i+1}: {_questions[i].Body}");
                _questions[i].DisaplyQuestion();
                Console.WriteLine($"Your Answer => {userAnswers[i].AnswerText}");
                Console.WriteLine($"Correct Answer => {_questions[i].RightAnswer.AnswerText}");
                Utility.ConsoleSeperator();
            }
        }
      
    }
}
