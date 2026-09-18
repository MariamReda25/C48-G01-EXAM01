using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal abstract class Exam
    {
        #region Attributes
        protected Question[] _questions;

        private int _count = 0;
        #endregion

        #region Properties
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public string Title { get; set; }

        public int TotalMarks {
            get
            {
                int marks = 0;
                foreach (Question question in _questions)
                    marks += question.Mark;
                return marks;
            }

        }

        public Question this[int index]
        {
            get
            {
                if (index >= _questions.Length || _questions is null)
                    return null!;
                else return _questions[index];
            }
        }
        #endregion

        #region Constructor
        public Exam(int time,int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            _questions = new Question[NumberOfQuestions];
        }
        #endregion

        #region Methods
       

        public void AddQuestion(Question question)
        {
            if(_questions is not null && _count < _questions.Length)
            {
                _questions[_count++] = question;
            }

        }

        public int CalculateGrade(Answer[] userAnswers)
        {
            int grade = 0;
            for(int i = 0; i < NumberOfQuestions; i++)
            {
                if (userAnswers[i].AnswerID == _questions[i].RightAnswer.AnswerID)
                    grade += _questions[i].Mark;
            }

            return grade;
        }

        public virtual void ShowExam(Answer[] userAnswers){
            Console.WriteLine($" {Title} Results");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Question {i + 1}: {_questions[i].Body}");
                Console.WriteLine($"Your Answer => {userAnswers[i].AnswerText}");
                Console.WriteLine($"Correct Answer => {_questions[i].RightAnswer.AnswerText}");
                Utility.ConsoleSeperator();
            }
        }
        #endregion


    }
}
