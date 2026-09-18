using ExamSystem.Classes;
using System.Diagnostics;

namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t========= Welocme to Examination Sytsem ==========\n");

            #region Create New Subject 

            Utility.ConsoleInput("Please Enter Subject Name:", out string subjectName);
            Utility.ConsoleInput("Please Enter Subject ID:", out string subjectID);

            Subject subject = new Subject(subjectID,subjectName);
            Console.WriteLine("\t== Subject is Created Successfully ==\n");
            #endregion

            Utility.ConsoleSeperator();

            #region Create Subject's Exam
            Utility.ConsoleInputChoice("Select The Type of Exam (1.Practical , 2.Final)", new int[] {1,2}, out int examType);
           
            int examTime = 0;
            do
            {
                Console.WriteLine("Please, Enter The Time for Exam (30 to 180 mins)");
                int.TryParse(Console.ReadLine(), out examTime);
            } while (examTime < 30 || examTime > 180);

            Utility.ConsoleInput("Please, Enter Number of Questions", out int numberOfQuestions);

            Exam exam = examType switch
            {
                1 => new PracticalExam(examTime, numberOfQuestions),
                2 => new FinalExam(examTime, numberOfQuestions),
            };
            subject.CreateExam(exam);

            #endregion

            #region Create Exam Questions
            switch (examType)
            {
                case 1:
                    Helper.AddPracticalExamQuestions(numberOfQuestions, exam);
                    break;
                case 2:
                    Helper.AddFinalExamQuestions(numberOfQuestions, exam);
                    break;
            }
            #endregion

            #region Start Exam
            Console.Clear();
            Utility.ConsoleInputChoice("Do You Want to Start Exam ( Y | N )", new char[] { 'Y', 'N' }, out char inputChoice);

            if (inputChoice == 'N') return;

            Stopwatch sw = Stopwatch.StartNew();
            Answer[] userAnswers = new Answer[exam.NumberOfQuestions];


            sw.Start();
                Console.WriteLine(exam.Title);
            for(int i = 0; i < exam.NumberOfQuestions; i++)
            {
                try
                {

                    Console.Write($" {exam[i]}\nQuestion {i + 1}: ");
                    exam[i].DisaplyQuestion();
                    Utility.ConsoleInputChoice("Enter your Answer ID:", new int[] { 1, 2, 3, 4 }, out int answerId);
                    userAnswers[i] = exam[i].GetAnswer(answerId);
                    Utility.ConsoleSeperator();

                } catch(NullReferenceException exception)
                {
                    Console.WriteLine("No Exam Questions");
                }
            }
            sw.Stop();
            

            #endregion

            #region Exam Result
            Console.Clear();
            exam.ShowExam(userAnswers);

            Console.WriteLine($"Your Grade is {exam.CalculateGrade(userAnswers)} out of {exam.TotalMarks}");
            Console.WriteLine($"Time: {sw.Elapsed:hh\\:mm\\:ss\\.fff}");
            Console.WriteLine("Thank You");
            #endregion

        }
    }
}
