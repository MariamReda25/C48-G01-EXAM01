using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal static class Helper
    {
        public static void AddPracticalExamQuestions(int numberOfQuestions,Exam exam)
        {
            for(int i = 0; i < numberOfQuestions; i++)
            {
                exam.AddQuestion(CreateMCQ());
            }
        }
        public static void AddFinalExamQuestions(int numberOfQuestions,Exam exam)
        {
            
            for(int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Utility.ConsoleInputChoice($"Choose Question {i + 1} type (1.MCQ  2.T/F)", new int[] { 1, 2 }, out int questionType);
                switch (questionType)
                {
                    case 1:
                    exam.AddQuestion(CreateMCQ());
                        break;
                    case 2:
                        exam.AddQuestion(CreateTrueOrFalse());
                        break;

                }

            }
        }

        public static MCQ CreateMCQ()
        {
            Console.Clear();
            Utility.ConsoleInput("Please, Enter the Question Body:", out string questionBody);
            Utility.ConsoleInput("Please, Enter the Question Mark:", out int questionMark);

            Console.WriteLine("Choices of Question:");
            Answer[] answers = new Answer[MCQ.NumberOfChoices];
           for (int i = 0; i < answers.Length; i++)
            {
                Utility.ConsoleInput($"Please, Enter Choice Number {i+1}:", out string choice);
                answers[i] = new Answer(i+1, choice);
            }
           Utility.ConsoleInputChoice("Please, Enter the ID of The correct Answer(1 to 4):",new int[] { 1, 2, 3, 4 }, out int rightAnswer);
            return new MCQ(questionBody, questionMark, answers[rightAnswer - 1],answers);
        }

        public static TrueOrFalse CreateTrueOrFalse()
        {
            Console.Clear();
            Utility.ConsoleInput("Please, Enter the Question Body:", out string questionBody);
            Utility.ConsoleInput("Please, Enter the Question Mark:", out int questionMark);
            
            Utility.ConsoleInputChoice("Please, Enter the ID of The correct Answer(1.True  2.False):",new int[] { 1, 2}, out int rightAnswer);
            string answer = rightAnswer == 1 ? "True" : "False";
            return new TrueOrFalse(questionBody, questionMark, new Answer(rightAnswer, answer));
        }
    }
}
