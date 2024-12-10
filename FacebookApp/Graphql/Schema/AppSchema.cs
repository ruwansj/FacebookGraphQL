using FacebookApp.Graphql.Mutations;
using FacebookApp.Graphql.Queries;
using GraphQL.Types;  // Make sure this using statement is present

namespace FacebookApp.Graphql.Schema
{
    public class AppSchema : GraphQL.Types.Schema  // Fully qualified name
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQuery>();
            Mutation = serviceProvider.GetRequiredService<AppMutation>();
        }
    }
}