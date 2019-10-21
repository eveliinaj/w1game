using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQuestions = 10;
            Question[] questions = new Question[numberOfQuestions];
            int score = 0;
            int correctAnswers = 0;

            var f = new FileReading(questions);
            f.ChooseFile();

            string name = AskForUserName();

            var questionNumber = 1;
            foreach (var question in questions)
            {
                Console.Clear();
                Console.WriteLine($"Points: {score}");
                Console.WriteLine($"Question {questionNumber}/{numberOfQuestions}");
                Console.WriteLine(question.Questionstring);
                bool answer = CheckInput();
                question.UserAnswer = answer;
                if (answer == question.CorrectAnswer)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Correct!");
                    Console.ResetColor();
                    score++;
                    correctAnswers++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Incorrect!");
                    Console.ResetColor();
                    if (score > 0)
                    {
                        score--;
                    }
                }
                questionNumber++;
                Thread.Sleep(500);
            }
            Console.Clear(); 
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
            if (correctAnswers > numberOfQuestions / 4 * 3)
            {
                Console.WriteLine($"Well done {name}! Your total points are {score} and number of correct answers is {correctAnswers}.");
            }
            else if (correctAnswers > numberOfQuestions / 2)
            {
                Console.WriteLine($"Pretty good {name}, but could be better! Your total points are {score} and number of correct answers is {correctAnswers}.");
            }
            else
            {
                Console.WriteLine($"Better luck next time {name}! Your total points are {score} and number of correct answers is {correctAnswers}.");
            }
            Console.WriteLine();
                Console.ResetColor();


            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Would you like to see how you did with individual answers?");
            Console.ResetColor();
            bool showAnswers = CheckInput();
            if (showAnswers)
            {
                Console.WriteLine();
                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine($"Question #{i + 1}: {questions[i].Questionstring}");
                    var correctAnswer = questions[i].CorrectAnswer ? "yes" : "no";
                    var userAnswer = questions[i].UserAnswer ? "yes" : "no";
                    if (correctAnswer == userAnswer)
                    {
                        Console.WriteLine("Your answer was correct!");
                    }
                    else
                    {
                        Console.WriteLine("Your answer was wrong!");
                    }
                    
                    Console.WriteLine("Incorrect!");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Correct answer was {correctAnswer.ToUpper()} and you answered {userAnswer.ToUpper()}.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Come back soon to see the new quizzes added to our service!");
            Console.ResetColor();
        }

        static string AskForUserName()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("What is your name?");
            Console.ResetColor();
            var name = Console.ReadLine();
            while (name.Length <= 1)
            {
                Console.WriteLine("Please enter a name with more than one character.");
                name = AskForUserName();
            }
            return name;
        }

        static bool CheckInput()
        {
            var input = Console.ReadKey(true);
            bool output = false;

            switch (input.Key)
            {
                case ConsoleKey.Y:
                case ConsoleKey.K:
                case ConsoleKey.T:
                    output = true;
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("You found the easter egg!");
                    break;
                case ConsoleKey.N:
                case ConsoleKey.E:
                case ConsoleKey.F:
                    output = false;
                    break;
                default:
                    Console.WriteLine("Just write Y or N!");
                    CheckInput();
                    break;
            }
            return output;
        }


    }
}
