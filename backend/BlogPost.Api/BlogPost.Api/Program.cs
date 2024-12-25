using BlogPost.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("BlogDbConnection")));

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();