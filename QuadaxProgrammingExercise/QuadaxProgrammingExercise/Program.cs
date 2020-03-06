//Jake Thornberry
//Quadax Mastermind Programming Exercise
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadaxProgrammingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            String guess = "";
            String answer = "";
            int count=0;
            bool isCorrect = false;
            int wrongPosition = 0;
            int rightPosition = 0;
            Random random = new Random();

            //generate random answer
            for (int i = 0; i < 4; i++)
            {
                answer += random.Next(1, 7).ToString();
            }

            //display introduction
            Console.WriteLine("Rules: You have 10 attempts to guess a 4 digit number with digits ranging from 1 to 6.\n" +
                "After every attempt you will get a minus sign for every correct digit in the wrong position and\n" +
                "a plus sign for every correct digit in the correct position.\n");

            while (!isCorrect && count < 10)
            {
                
                Console.Write("Enter your guess:");
                guess = Console.ReadLine();

                //validates guess string
                if (guess.Length < 4)
                {
                    Console.WriteLine("You have entered too few digits. Please enter 4 digits");
                    continue;
                }

                if (guess.Length > 4)
                {
                    guess = guess.Substring(0, 4);
                }

                bool invalidChar = false;
                for(int i = 0; i < 4; i++)
                {
                    if (!Char.IsDigit(guess[i]))
                    {
                        Console.WriteLine("You have entered an invalid character. Please only enter numbers.");
                        invalidChar = true;
                        break;
                    }
                }
                if (invalidChar) { continue; }

                //checks if the answer is correct
                if (String.Equals(guess, answer))
                {
                    isCorrect = true;
                    continue;
                }

                //checks for correct digit in the wrong position(s)
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] != answer[i] && guess.Contains(answer[i]))
                    {
                        wrongPosition++;
                    }
                }
                
                //checks for correct digit in the right position(s)
                for(int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                    {
                        rightPosition++;
                    }
                }

                //prints corresponding characters for digits in the wrong and right positions respectively
                for(int i = 0; i < wrongPosition; i++)
                {
                    Console.Write("-");
                }
                for(int i = 0; i < rightPosition; i++)
                {
                    Console.Write("+");
                }
                Console.WriteLine();

                rightPosition = 0;
                wrongPosition = 0;

                count++;
            }
            //displays winning or losing message
            if (isCorrect)
            {
                Console.WriteLine("Congratulations! You have won!");
            }
            else
            {
                Console.WriteLine("You have lost. The correct answer is " + answer + " Better luck next time!");
            }
            Console.ReadLine();
        }
    }
}
