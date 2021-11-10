using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlockChain.Models
{
    public partial class PubBook
    {
        [Key]
        public int Id { get; set; }
        public int? IdUser1 { get; set; }
        public int? IdUser2 { get; set; }
        public string HashCode { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string HashFinal { get; set; }
    }
}
