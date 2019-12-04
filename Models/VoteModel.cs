using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupWebApplication.Models
{
    public class VoteModel
    {
        [Key]
        public String Date { get; set; } //ImageID = Date Value
        public int Votes { get; set; }
    }
}
