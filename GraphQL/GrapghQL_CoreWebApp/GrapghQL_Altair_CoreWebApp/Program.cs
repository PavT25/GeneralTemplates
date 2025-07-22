
using GrapghQL_Altair_CoreWebApp.Data.Repositories;
using GrapghQL_Altair_CoreWebApp.GraphQL;
using GraphQL;
using System.Reflection;

namespace GrapghQL_Altair_CoreWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();
            builder.Services.AddSingleton<ICoursesRepository, CoursesRepository>();

            builder.Services
                .AddGraphQL(options =>
                {
                    options.AddErrorInfoProvider(ep => ep.ExposeExceptionDetails = builder.Environment.IsDevelopment());
                    options.AddSchema<CourseSchema>();
                    options.AddGraphTypes(Assembly.GetExecutingAssembly());
                    options.AddDataLoader();
                    options.AddSystemTextJson();
                });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // https://medium.com/@ozgurtaylann/exploring-graphql-with-asp-net-core-a-practical-guide-to-efficient-api-design-fc5caac9da53
            // http://localhost:port/ui/altair
            // Register GraphQL middleware and Altair UI
            app.UseGraphQL();
            app.UseGraphQLAltair();


            app.MapControllers();

            app.Run();
        }
    }
}
