using MissionTen_Thatcher.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BowlerContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BowlerConnection"]);
});
builder.Services.AddScoped<IBowlerRepository, EFBowlerRepository>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

