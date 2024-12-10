using GraphQL.Types;
using FacebookApp.Data;
using FacebookApp.Models;
using FacebookApp.Graphql.Types;
using GraphQL;

namespace FacebookApp.Graphql.Mutations
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(AppDbContext db)
        {
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }
                ),
                resolve: context =>
                {
                    var user = new User
                    {
                        Name = context.GetArgument<string>("name"),
                        Email = context.GetArgument<string>("email")
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                    return user;
                }
            );

            Field<PostType>(
                "createPost",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "content" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "userId" }
                ),
                resolve: context =>
                {
                    var post = new Post
                    {
                        Content = context.GetArgument<string>("content"),
                        UserId = context.GetArgument<int>("userId"),
                        CreatedAt = DateTime.UtcNow
                    };

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return post;
                }
            );

            Field<CommentType>(
                "createComment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "content" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "userId" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "postId" }
                ),
                resolve: context =>
                {
                    var comment = new Comment
                    {
                        Content = context.GetArgument<string>("content"),
                        UserId = context.GetArgument<int>("userId"),
                        PostId = context.GetArgument<int>("postId"),
                        CreatedAt = DateTime.UtcNow
                    };

                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return comment;
                }
            );
        }
    }
}