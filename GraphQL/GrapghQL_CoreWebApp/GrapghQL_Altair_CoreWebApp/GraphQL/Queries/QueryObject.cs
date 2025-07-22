using GraphQL;
using GraphQL.Resolvers;
using GraphQL.Types;
using GrapghQL_Altair_CoreWebApp.Data.Repositories;
using GrapghQL_Altair_CoreWebApp.GraphQL.Types;

namespace GrapghQL_Altair_CoreWebApp.GraphQL.Queries
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(ICoursesRepository courseRepository, IReviewRepository reviewRepository)
        {
            AddField(new FieldType
            {
                Name = "getCourses",
                Description = "Get all courses",
                Type = typeof(ListGraphType<CourseType>),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var courses = courseRepository.GetAllCourses();
                    foreach (var course in courses)
                    {
                        var reviewsForCourse = reviewRepository.GetReviewsOfTheCourse(course.Id);
                        course.Reviews = reviewsForCourse;
                    }
                    return courses;
                })
            });

            AddField(new FieldType
            {
                Name = "getCourse",
                Description = "Get a course by ID",
                Type = typeof(CourseType),
                Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Course Id" }),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return courseRepository.GetCourseById(id);
                })
            });

            AddField(new FieldType
            {
                Name = "getReviews",
                Description = "Get all reviews",
                Type = typeof(ListGraphType<ReviewType>),
                Resolver = new FuncFieldResolver<object>(context => reviewRepository.GetAllReviews())
            });

            AddField(new FieldType
            {
                Name = "getReview",
                Description = "Get a review by ID",
                Type = typeof(ReviewType),
                Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Review Id" }),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return reviewRepository.GetReviewById(id);
                })
            });

            AddField(new FieldType
            {
                Name = "getReviewsOfCourse",
                Description = "Get all reviews of a course by course ID",
                Type = typeof(ListGraphType<ReviewType>),
                Arguments = new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "courseId", Description = "Course Id" }),
                Resolver = new FuncFieldResolver<object>(context =>
                {
                    var courseId = context.GetArgument<int>("courseId");
                    return reviewRepository.GetReviewsOfTheCourse(courseId);
                })
            });

        }
    }
}
