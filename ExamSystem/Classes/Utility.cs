using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Classes
{
    internal static class Utility
    {
        public static void ConsoleInput(string inputMessage,out string input)
        {
            do
            {
                Console.WriteLine(inputMessage);
                input = Console.ReadLine()!;

            }while(string.IsNullOrWhiteSpace(input)|| input.Length == 0 || input.Length<4);


        }
        public static void ConsoleInput(string inputMessage,out int input)
        {
            do
            {
                Console.WriteLine(inputMessage);
                 int.TryParse(Console.ReadLine(),out input);
               

            }while(!(input>0));


        }

        public static void ConsoleSeperator()
        {
            Console.WriteLine("\t===============================================\n");
        }

        public static void ConsoleInputChoice(string inpuMessage, int[] choices,out int inputChoice)
        {
            do
            {
                Console.WriteLine(inpuMessage);
                int.TryParse(Console.ReadLine(), out inputChoice);

            } while (!choices.Contains(inputChoice));
        }
        public static void ConsoleInputChoice(string inpuMessage, char[] choices,out char inputChoice)
        {
            do
            {
                Console.WriteLine(inpuMessage);
                char.TryParse(Console.ReadLine(), out inputChoice);
               inputChoice=Convert.ToChar(inputChoice.ToString().ToUpper());

            } while (!choices.Contains(inputChoice));
        }
    }
}
