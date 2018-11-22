using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Trivia_2.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }
        
        public List<Answer> Answers { get; set; }
    }
}
