using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trinityScreening.Models
{
    public class UserQuestionAnswers
    {
        
        public List<TblQuestion> QuestionsList { get; set; }
        public bool SelectedAnswer { get; set; }
       
    }
}
