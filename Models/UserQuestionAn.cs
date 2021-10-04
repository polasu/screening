using System;
using System.Collections.Generic;

#nullable disable

namespace trinityScreening.Models
{
    public partial class UserQuestionAn
    {
        public long Id { get; set; }
        public int? UserQuestion { get; set; }
        public bool? UserQuestionAns { get; set; }
    }
}
