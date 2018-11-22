using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Trivia_2.Models;
using System.Data.SqlClient;

namespace Music_Trivia_2.DALs
{
    public class AnswerSqlDAL : IAnswerDAL
    {
        private string connectionString;

        public AnswerSqlDAL(string databaseConnectionString)
        {
            this.connectionString = databaseConnectionString;
        }

        public List<Answer> GetAnswers(Question question)
        {
            // Create a list to return
            List<Answer> output = new List<Answer>();

            try
            {
                // Create a connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    // Create a command
                    SqlCommand command = new SqlCommand("SELECT * from answers WHERE question_id = @questionid" , conn);
                    command.Parameters.AddWithValue("@questionid", question.QuestionId);

                    //Execute the command 
                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Answer answer = ConvertStringToAnswer(reader);

                        output.Add(answer);
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

        private static Answer ConvertStringToAnswer(SqlDataReader reader)
        {
            Answer answer = new Answer();
            answer.AnswerID = Convert.ToInt32(reader["answer_id"]);
            answer.QuestionId = Convert.ToInt32(reader["question_id"]);
            answer.CorrectAnswer = Convert.ToInt32(reader["isCorrect"]);
            answer.Text = Convert.ToString(reader["value"]);
            

            return answer;
        }
    }
}
