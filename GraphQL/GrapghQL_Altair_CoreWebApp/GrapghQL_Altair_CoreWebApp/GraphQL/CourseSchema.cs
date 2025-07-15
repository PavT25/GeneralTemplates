using GraphQL.Types;
using GrapghQL_Altair_CoreWebApp.GraphQL.Queries;
using Schema = GraphQL.Types.Schema;

namespace GrapghQL_Altair_CoreWebApp.GraphQL
{
    public class CourseSchema : Schema
    {
        public CourseSchema(CourseQuery query, MutationObject mutation, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.Query = query;
            this.Mutation = mutation;
        }
    }
}
