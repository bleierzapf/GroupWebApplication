using System;
using System.ComponentModel.DataAnnotations;

namespace GroupWebApplication.Models
{
    public class VoteModel
    {
        [Key]
        public String ImageID { get; set; } //ImageID = Date Value
        public int Votes { get; set; }
    }
}