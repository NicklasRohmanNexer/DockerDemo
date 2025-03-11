using DockerDemo.Service;
using DockerDemo.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbConnection>();

// Lägg till CORS-tjänsten
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:8001", "http://localhost:8002", "http://localhost:8003")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

AddServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
*/
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddServices(IServiceCollection services)
{
    services.AddScoped<IPersonService, PersonService>();
    services.AddScoped<IDbConnection, DbConnection>();
}