using GraphQL.Types;
using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Types
{
    public sealed class ReviewInputType : InputObjectGraphType<Review>
    {
        public ReviewInputType()
        {
            Name = "ReviewInput";
            Description = "Input type for creating or updating a review";

            Field<IntGraphType>("Rating");
            Field<StringGraphType>("Comment");

            Field<IntGraphType>("CourseId");
        }
    }
}
