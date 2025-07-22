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
        public MutationObject(ICoursesRepository courseRepository, IReviewRepository reviewRepository)
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
                    return courseRepository.AddCourse(courseInput);
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
                    return courseRepository.UpdateCourse(id, courseInput);
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
                    courseRepository.DeleteCourse(id);
                    return true; // Return true to indicate successful deletion
                })
            });

            AddField(new FieldType
            {
                Name = "addReview",
                Description = "Add a review to a course",
                Type = typeof(ReviewType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "review", Description = "Review input parameter" }
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var review = context.GetArgument<Review>("review");
                    return reviewRepository.AddReview(review);
                })
            });

            AddField(new FieldType
            {
                Name = "updateReview",
                Description = "Update an existing review",
                Type = typeof(ReviewType),
                Arguments = new QueryArguments(
                     new QueryArgument<IdGraphType> { Name = "reviewId", Description = "Id of the review to be updated" },
                    new QueryArgument<NonNullGraphType<ReviewInputType>> { Name = "review", Description = "Updated review values" }
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("reviewId");
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviewRepository.UpdateReview(id, reviewInput);
                })
            });

            AddField(new FieldType
            {
                Name = "deleteReview",
                Description = "Delete a review by ID",
                Type = typeof(BooleanGraphType),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "reviewId", Description = "Id of the review to be deleted" }
                ),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("reviewId");
                    reviewRepository.DeleteReview(id);
                    return true; // Return true to indicate successful deletion
                })
            });
        }
    }
}
