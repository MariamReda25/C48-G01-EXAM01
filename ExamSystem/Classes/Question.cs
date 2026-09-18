using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal abstract class Question
    {
        #region Constructor
        public Question(string body,int mark,Answer rightAnswer)
        {
            Body = body;
            Mark = mark;
            RightAnswer = rightAnswer;
        }
        #endregion

        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer RightAnswer { get; set; }
        #endregion

        #region Methods

        public abstract void DisaplyQuestion();
        public abstract Answer GetAnswer(int answerId);
       

        public override string ToString()
        {
            return $"{Header}:\tMark {Mark}";
        }
        
        #endregion
    }
}
