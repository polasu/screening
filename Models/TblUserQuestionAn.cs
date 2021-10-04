using System;
using System.Collections.Generic;

#nullable disable

namespace trinityScreening.Models
{
    public partial class TblUserQuestionAn
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public int QuestionId { get; set; }
        public bool? UserQuestionAns { get; set; }
    }
}
