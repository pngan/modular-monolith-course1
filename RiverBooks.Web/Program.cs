
using RiverBooks.Books;
using Microsoft.AspNetCore.Builder;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();


// Add Module services
builder.Services.AddBookServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.Run();
