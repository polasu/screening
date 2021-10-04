using System;
using System.Collections.Generic;

#nullable disable

namespace trinityScreening.Models_New
{
    public partial class TblUser
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Confirmpwd { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
