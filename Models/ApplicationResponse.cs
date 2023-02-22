using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission8.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        //foreign key
        [Required(ErrorMessage = "Please select a Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }

    }
}
