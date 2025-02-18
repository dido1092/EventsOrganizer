using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOrganizer.Data.Models
{
    public class RepeatWord
    {
        public RepeatWord()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public string EnWord { get; set; }

        public string BgWord { get; set; }

        public int Minutes { get; set; }

        public bool Repeat { get; set; }

        public DateTime DateTime { get; set; }
    }
}
