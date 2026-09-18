using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class PracticalExam:Exam
    {
        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions) {
            Title = "Practical Exam";
        }

        

        
    }
}
