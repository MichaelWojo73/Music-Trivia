using Music_Trivia_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Trivia_2.DALs
{
    public interface IAnswerDAL
    {
        List<Answer> GetAnswers(Question question);
    }
}
