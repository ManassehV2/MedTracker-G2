using MedAdvisor.DataAccess.MySql;
using MedAdvisor.DataAccess.MySql.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();

builder.Services.AddScoped<IUserVaccineRepository, UserVaccineRepository>();
builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();
builder.Services.AddScoped<IUserAllergyRepository, UserAllergyRepository>();
builder.Services.AddScoped<IUserDiagnosisRepository, UserDiagnosisRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MedTrackerContext>(options => options.UseSqlServer("Data Source=Natnael-PC;Initial Catalog=MedTracker;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", b => b.MigrationsAssembly("MedAdvisor.Api")));



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
