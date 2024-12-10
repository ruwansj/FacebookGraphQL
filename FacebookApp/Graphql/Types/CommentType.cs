using GraphQL.Types;
using FacebookApp.Models;

namespace FacebookApp.Graphql.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Id);
            Field(x => x.Content);
            Field(x => x.CreatedAt);
            Field<UserType>("user",
                resolve: context => context.Source.User);
            Field<PostType>("post",
                resolve: context => context.Source.Post);
        }
    }
}
