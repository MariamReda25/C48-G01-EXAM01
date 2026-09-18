using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class Answer
    {
        #region Constructor
        public Answer(int answerID, string answerText)
        {
            AnswerID = answerID;
            AnswerText = answerText;
        } 
        #endregion

        #region Properties
        public int AnswerID { get; set; }
        public string AnswerText { get; set; } 
        #endregion


        
    }
}
