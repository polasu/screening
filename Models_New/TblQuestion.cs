using System;
using System.Collections.Generic;

#nullable disable

namespace trinityScreening.Models_New
{
    public partial class TblQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public short? QuestionsOrder { get; set; }
    }
}
