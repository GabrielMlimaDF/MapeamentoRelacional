using Microsoft.EntityFrameworkCore;
using Models.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("Banco");
builder.Services.AddDbContext<ContextApp>(op => op.UseSqlServer(connectionString));
var app = builder.Build();

app.MapControllers();

app.Run();