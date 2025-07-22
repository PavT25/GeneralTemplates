using GrapghQL_Altair_CoreWebApp.Data.Models;
using GrapghQL_Altair_CoreWebApp.Data.Repositories;
using GrapghQL_Altair_CoreWebApp.GraphQL.Types;
using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Mutations
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(ICoursesRepository repository)
        {
            Name = "Mutation";
            Description = "Mutation operations for courses";

            AddField(new FieldType
            {
                Name = "addCourse",
                Description = "Add a new course",
                Type = typeof(CourseType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course", Description = "Course input parameter"}
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var courseInput = context.GetArgument<Course>("course");
                    return repository.AddCourse(courseInput);
                })
            });

            AddField(new FieldType
            {
                Name = "updateCourse",
                Description = "Update an existing course",
                Type = typeof(CourseType),
                Arguments = new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "Id of the course to be updated"},
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course", Description = "Updated course values"}
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var courseInput = context.GetArgument<Course>("course");
                    return repository.UpdateCourse(id, courseInput);
                })
            });

            AddField(new FieldType
            {
                Name = "deleteCourse",
                Description = "Delete a course by ID",
                Type = typeof(BooleanGraphType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Id of the course to be deleted"}
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("id");
                    repository.DeleteCourse(id);
                    return true; // Return true to indicate successful deletion
                })
            });
        }
    }
}
