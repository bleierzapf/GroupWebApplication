using System;
using System.ComponentModel.DataAnnotations;

namespace GroupWebApplication.Models
{
    public class ImageModel
    {
        [Key]
        public String Date { get; set; }
        public String Explanation { get; set; }
        public String MediaType { get; set; }
        public String Title { get; set; }
        public String Url { get; set; }
        public String Hdurl { get; set; }
    }
}