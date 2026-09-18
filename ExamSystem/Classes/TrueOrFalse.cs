using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class TrueOrFalse:Question
    {
        #region Constructor
        public TrueOrFalse(string body, int mark, Answer rightAnswer) : base(body, mark, rightAnswer) {
            Header = "True or False";
        }

        #endregion

        #region MyRegion
        public override void DisaplyQuestion()
        {

            Console.WriteLine($"{Body}\n1-True\n2-False");

        }

        public override Answer GetAnswer(int answerId)
        {
            return answerId == 1 ? new Answer(1, "True") : new Answer(2, "False");
        }
        #endregion
    }
}
