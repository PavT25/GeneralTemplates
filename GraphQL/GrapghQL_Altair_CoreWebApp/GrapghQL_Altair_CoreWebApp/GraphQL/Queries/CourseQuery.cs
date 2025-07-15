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

            // AddField(new FieldType
            // {
            //     Name = "addCourse",
            //     Description = "Add a new course",
            //     Type = typeof(CourseType),
            //     Arguments = new QueryArguments(new QueryArgument<CourseType> { Name = "course" }),
            //     Resolver = new FuncFieldResolver<object>(context =>
            //     {
            //         var courseInput = context.GetArgument<Data.Models.Course>("course");
            //         return repository.AddCourse(courseInput);
            //     })
            // });

            // AddField(new FieldType
            // {
            //     Name = "updateCourse",
            //     Description = "Update an existing course",
            //     Type = typeof(CourseType),
            //     Arguments = new QueryArguments(
            //         new QueryArgument<IdGraphType> { Name = "id" },
            //         new QueryArgument<NonNullGraphType<CourseType>> { Name = "course" }
            //     ),
            //     Resolver = new FuncFieldResolver<object>(context =>
            //     {
            //         var id = context.GetArgument<int>("id");
            //         var courseInput = context.GetArgument<Data.Models.Course>("course");
            //         return repository.UpdateCourse(id, courseInput);
            //     })
            // });

            // AddField(new FieldType
            // {
            //     Name = "deleteCourse",
            //     Description = "Delete a course by ID",
            //     Type = typeof(BooleanGraphType),
            //     Arguments = new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
            //     Resolver = new FuncFieldResolver<object>(context =>
            //     {
            //         var id = context.GetArgument<int>("id");
            //         repository.DeleteCourse(id);
            //         return true; // Return true to indicate successful deletion
            //     })
            // });
        }
    }
}
