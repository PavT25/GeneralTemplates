using System.ComponentModel.DataAnnotations;

namespace GrapghQL_Altair_CoreWebApp.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
