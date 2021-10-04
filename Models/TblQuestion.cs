using System;
using System.Collections.Generic;

namespace trinityScreening.Models
{
    public partial class TblQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public short? QuestionsOrder { get; set; }
    }
}
