using System.ComponentModel.DataAnnotations;

namespace GrapghQL_Altair_CoreWebApp.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Review { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
