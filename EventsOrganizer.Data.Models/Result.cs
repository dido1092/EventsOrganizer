using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOrganizer.Data.Models
{
    public class Result
    {
        public Result()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string EnWord { get; set; }

        [Required]
        public string BgWord { get; set; }

        [Required]
        public string WritingWord { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        public bool Hint { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
