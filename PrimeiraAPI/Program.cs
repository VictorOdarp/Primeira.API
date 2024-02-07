using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.DataContext;
using PrimeiraAPI.Services.FuncionarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var DefaultConnection = "server=localhost;userid=root;password=895smigol;database=bancoAPI;";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection));
});

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

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
