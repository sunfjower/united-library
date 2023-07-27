using Microsoft.EntityFrameworkCore;
using UnitedLibraryAPI.Data;
using UnitedLibraryAPI.Repository;
using Microsoft.Data.SqlClient;
using System.Reflection;
using UnitedLibraryAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<INovelRepository, NovelRepository>();
builder.Services.AddScoped<IWriterRepository, WriterRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UnitedLibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnitedLibraryDatabase"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
