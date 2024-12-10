using GraphQL.Types;
using FacebookApp.Models;

namespace FacebookApp.Graphql.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PostType>>("posts",
                resolve: context => context.Source.Posts);
            Field<ListGraphType<CommentType>>("comments",
                resolve: context => context.Source.Comments);
        }
    }
}