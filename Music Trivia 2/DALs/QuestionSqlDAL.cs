using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Trivia_2.Models;
using System.Data.SqlClient;

namespace Music_Trivia_2.DALs
{
    public class QuestionSqlDAL : IQuestionDAL
    {
        private string connectionString;

        public QuestionSqlDAL(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        public List<Question> GetQuestions()
        {

            // Create a list to return
            List<Question> output = new List<Question>();
            

            try
            {
                // Create a connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command
                    SqlCommand command = new SqlCommand("SELECT * FROM questions;", conn);


                    //Execute the command 
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Question question = ConvertSqlToQuestion(reader);
                       // question.Answers = new AnswerSqlDAL(connectionString).GetAnswers(question.QuestionId);
                        output.Add(question);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error reading Music Trivia data.");
                throw;
            }
            return output;
        }

        private static Question ConvertSqlToQuestion(SqlDataReader reader)
        {
            Question question = new Question();
            question.QuestionText = Convert.ToString(reader["text"]);
            question.QuestionId = Convert.ToInt32(reader["question_id"]);

            return question;
        }
    }
}
