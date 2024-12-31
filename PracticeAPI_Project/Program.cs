using DapperApiDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the EmployeeRepository with DI

string connectionString = "Server=DESKTOP-U2OA7SU\\MSSQLSERVER1;Database=DapperApiDemoDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;";
builder.Services.AddSingleton(new DapperApiDemo.Repositories.EmployeeRepository(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
