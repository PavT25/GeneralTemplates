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

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the course. Optional for creation.");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("The name of the course.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("The description of the course.");
            Field(x => x.Review, type: typeof(IntGraphType)).Description("The review rating of the course.");
        }
    }
}
