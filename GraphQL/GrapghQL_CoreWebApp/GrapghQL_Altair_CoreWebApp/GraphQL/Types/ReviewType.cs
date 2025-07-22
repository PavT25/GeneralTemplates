using GrapghQL_Altair_CoreWebApp.Data.Models;
using GraphQL.Types;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Name = "Review";
            Description = "A review object";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the review.");
            Field(x => x.Rating, type: typeof(IntGraphType)).Description("The rating of the review.");
            Field(x => x.Comment, type: typeof(StringGraphType)).Description("The comment of the review.");
            // Field(x => x.CourseId, type: typeof(IntGraphType)).Description("The course id.");
        }
    }
}
