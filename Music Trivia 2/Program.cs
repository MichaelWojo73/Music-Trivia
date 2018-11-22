using Music_Trivia_2.DALs;
using Music_Trivia_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Trivia_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string DatabaseConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=MusicTrivia;Integrated Security=True";
            IQuestionDAL questionDAL = new QuestionSqlDAL(DatabaseConnectionString);
            List<Question> questions = questionDAL.GetQuestions();
            AnswerSqlDAL stuff = new AnswerSqlDAL(DatabaseConnectionString);
            Dictionary<int, string> insults = new Dictionary<int, string>()
            {
                {1 , "Wooooooooowwwwwwwwww"},
                {2 , "I remember my first time doing music trivia..." },
                {3 , "You must be a Katy Perry fan" },
                {4 , "I'd enter Q if I was you"},
                {5 , "Honestly, this is getting painful" },
                {6 , "I'm not mad... just disappointed" },
                {7 , "Everyone at Music Trivia headquarters is laughing at you" },
                {8 , "I'd call you terrible but that would be too nice" }
                

            };

            int correctCount = 0;
            int incorrectCount = 0;

            Console.WriteLine("WELCOME TO MUSIC TRIVIA!!!!!");
            Console.WriteLine("enter Q to quit");
            Console.WriteLine();

            for (int i = 0; i < questions.Count; i++)
            {

                Console.WriteLine($" {questions[i].QuestionText}");
                Console.WriteLine();
                IList<Answer> answers = stuff.GetAnswers(questions[i]);
                for (int j = 0; j < answers.Count; j++)
                {
                    Console.WriteLine($"{j + 1}.{answers[j].Text}");
                }
                Console.WriteLine();
                string a = Console.ReadLine();
                if (a == "q" || a == "Q") 
                {
                    Console.WriteLine("".PadRight(11) + "FINAL SCORE");
                    Console.WriteLine($"Correct answers: {correctCount} Incorrect answers: {incorrectCount}");
                    break;
                }
                int answerNum = int.Parse(a);
                answerNum--;


                if (answers[answerNum].CorrectAnswer == 1)
                {
                    correctCount += 1;
                    Console.WriteLine("CORRECT!");
                    Console.WriteLine($"Correct answers: {correctCount} Incorrect answers: {incorrectCount}");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    incorrectCount += 1;
                    Random rnd = new Random();
                    int burnNum = rnd.Next(1, 5);
                    Console.WriteLine($"INCORRECT!   {insults[burnNum]}");
;
                    Console.WriteLine();

                    Console.WriteLine($"Correct answers:".PadRight(18) + $"{correctCount}".PadRight(4) + "Incorrect answers:".PadRight(20) + $"{incorrectCount}");
                    Console.ReadLine();
                    Console.Clear();
                }
            }




        }
    }
}
