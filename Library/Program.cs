using System.Text.Json.Serialization;
using Library.Database;
using Library.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddTransient<ILoanRepo, LoanRepo>();

builder.Services.AddDbContext<LibraryContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DbPopulator.PopulateDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
