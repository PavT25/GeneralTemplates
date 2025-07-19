using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GrapghQL_Altair_CoreWebApp.Data.Repositories;
using GrapghQL_Altair_CoreWebApp.GraphQL.Types;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Queries
{
    public class CourseQuery : ObjectGraphType<object>
    {
        public CourseQuery(ICoursesRepository repository)
        {
            AddField(new FieldType
            {
                Name = "courses",
                Description = "Get all courses",
                Type = typeof(ListGraphType<CourseType>),
                Resolver = new FuncFieldResolver<object>(context => repository.GetAllCourses())
            });

            AddField(new FieldType
            {
                Name = "course",
                Description = "Get a course by ID",
                Type = typeof(CourseType),
                Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Course Id" }),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.GetCourseById(id);
                })
            });

        }
    }
}
