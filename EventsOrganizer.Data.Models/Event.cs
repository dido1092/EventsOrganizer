
using System.ComponentModel.DataAnnotations;

namespace EventsOrganizer.Data.Models
{
    public class Event
    {
        public Event()
        {

        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string eventName { get; set; }

        public bool enable { get; set; }

        [Required]
        public DateTime dateTimeNow { get; set; }

        public DateTime remindDateTime { get; set; }

        [Required] 
        public int RemainingDays { get; set; }

        [Required]
        public string State { get; set; }
    }
}
