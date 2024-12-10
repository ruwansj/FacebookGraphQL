using GraphQL.Types;
using FacebookApp.Models;

namespace FacebookApp.Graphql.Types
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Id);
            Field(x => x.Content);
            Field(x => x.CreatedAt);
            Field<UserType>("user",
                resolve: context => context.Source.User);
            Field<ListGraphType<CommentType>>("comments",
                resolve: context => context.Source.Comments);
        }
    }
}