using dviraciu_nuoma_backend.Repository;
using dviraciu_nuoma_backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NsqlConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IKelioneRepository, KelioneRepository>();
builder.Services.AddScoped<IDviratisRepository, DviratisRepository>();

builder.Services.AddScoped<IDviratisService, DviratisService>();
builder.Services.AddScoped<IKelioneService, KelioneService>();
builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
