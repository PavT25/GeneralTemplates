using GraphQL.Types;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Types
{
    public class CourseType : ObjectGraphType<Data.Models.Course>
    {
        public CourseType()
        {
            Name = "Course";
            Description = "A course object";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the course.");
            Field(x => x.Name, type: typeof(StringGraphType)).Description("The name of the course.");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("The description of the course.");
            Field(x => x.Review, type: typeof(IntGraphType)).Description("The review rating of the course.");
            Field(x => x.DateCreated, type: typeof(DateTimeGraphType)).Description("The date when the course was created.");
            Field(x => x.DateUpdated, type: typeof(DateTimeGraphType)).Description("The date when the course was last updated.");
        }
    }
}
