using GraphQL.Types;
using GrapghQL_Altair_CoreWebApp.Data.Models;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Types
{
    public sealed class CourseInputType : InputObjectGraphType<Course>
    {
        public CourseInputType()
        {
            Name = "CourseInput";
            Description = "Input type for creating or updating a course";

            Field<StringGraphType>("Name");
            Field<StringGraphType>("Description");
            Field<IntGraphType>("Review");
        }
    }
}
