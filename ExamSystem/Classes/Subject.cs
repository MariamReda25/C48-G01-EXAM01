using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal class Subject
    {
        #region Constructor
        public Subject(string subjectID, string name)
        {
            SubjectID = subjectID;
            Name = name;

        } 
        #endregion

        #region Properties
        public string SubjectID { get; set; }
        public string Name { get; set; }

        public Exam Exam { get; private set; }
        #endregion


        #region Methods
        public void CreateExam(Exam exam)
        {
            if (exam is not null)
                Exam = exam;
        } 
        #endregion
    }
}
