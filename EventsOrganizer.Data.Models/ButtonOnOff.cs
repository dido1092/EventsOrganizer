using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsOrganizer.Data.Models
{
    public class ButtonOnOff
    {
        public ButtonOnOff()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string State { get; set; }
    }
}
