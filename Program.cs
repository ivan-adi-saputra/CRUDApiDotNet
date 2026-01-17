using CRUDApiDotNet.src.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ProductList"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
