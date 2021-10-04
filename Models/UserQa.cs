using System;
using System.Collections.Generic;

#nullable disable

namespace trinityScreening.Models
{
    public partial class UserQa
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? UserQaId { get; set; }
    }
}
