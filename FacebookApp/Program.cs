using FacebookApp.Data;
using FacebookApp.Graphql.Schema;
using FacebookApp.Graphql.Types;
using FacebookApp.Graphql.Queries;
using FacebookApp.Graphql.Mutations;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server;
using GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=facebook.db"));



// Register GraphQL services
builder.Services.AddScoped<AppSchema>();
builder.Services.AddScoped<AppQuery>();
builder.Services.AddScoped<AppMutation>();
builder.Services.AddScoped<UserType>();
builder.Services.AddScoped<PostType>();
builder.Services.AddScoped<CommentType>();

builder.Services.AddGraphQL(b => b
    .AddSystemTextJson()
    .AddSchema<AppSchema>()
    .AddGraphTypes(typeof(AppSchema).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseGraphQLPlayground("/ui/playground");
}

app.UseGraphQL<AppSchema>("/graphql");

app.Run();