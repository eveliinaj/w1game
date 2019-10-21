using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Quiz
{
    class FileReading
    {
        private Question[] questionlist = null;
        public FileReading(Question[] questions)
        {
            questionlist = questions;
        }
        public void ReadFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var r = new Random();

            for (int i = 0; i < questionlist.Length; i++)
            {
                var lineIndex = r.Next(lines.Length);
                while (lines[lineIndex] == null)
                {
                    lineIndex = r.Next(lines.Length);
                }
                var line = lines[lineIndex].Split(";");
                var newQuestion = new Question(line[0], bool.Parse(line[1]));

                questionlist[i] = newQuestion;
                lines[lineIndex] = null;
            }
        }

        public void ChooseFile()
        {
            var dir = new DirectoryInfo("..\\..\\..\\QuizQuestions");
            var files = dir.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                var name = files[i].Name;
                Console.WriteLine($"{i + 1}: {name.Substring(0, name.Length - 4)}");
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Choose a topic by inputting one of the numbers above and pressing enter.");
            Console.ResetColor();
            var input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice) || choice > files.Length || choice <= 0)
            {
                Console.WriteLine("Write a number from the list above!");
                input = Console.ReadLine();
            }

            ReadFromFile(files[choice - 1].FullName);
        }
    }
}
