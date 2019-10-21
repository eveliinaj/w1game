using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class Question
    {

        public string Questionstring { get; set; }
        public bool CorrectAnswer { get; set; }

        public bool UserAnswer { get; set; }


        public Question(string question1, bool truefalse1)
        {
            Questionstring = question1;
            CorrectAnswer = truefalse1;

        }





    }
}
