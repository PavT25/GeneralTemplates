namespace GrapghQL_Altair_CoreWebApp.Data.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public required string Comment { get; set; }

        // relation
        public int CourseId { get; set; }
    }
}
