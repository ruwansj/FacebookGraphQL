using GraphQL.Types;
using FacebookApp.Data;
using Microsoft.EntityFrameworkCore;
using FacebookApp.Graphql.Types;
using GraphQL;

namespace FacebookApp.Graphql.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(AppDbContext db)
        {
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context => db.Users.Include(u => u.Posts).Include(u => u.Comments).ToListAsync()
            );

            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return db.Users
                        .Include(u => u.Posts)
                        .Include(u => u.Comments)
                        .FirstOrDefaultAsync(u => u.Id == id);
                }
            );

            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context => db.Posts.Include(p => p.User).Include(p => p.Comments).ToListAsync()
            );
        }
    }
}