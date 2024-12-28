using BlogPost.Api.Extensions;
using BlogPost.Application;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly, includeInternalTypes: true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();