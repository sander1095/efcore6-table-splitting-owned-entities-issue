using efcore6_table_splitting_owned_entities_issue;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(opts =>
    opts.UseSqlServer("Data Source=.;database=TempDb;Trusted_Connection=true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/efcore", (MyDbContext dbContext) => dbContext.AbstractEntities);

app.Run();