using SailboatsApp.Persistence;
using SailboatsApp.Repositories;
using SailboatsApp.Repositories.Abstractions;
using SailboatsApp.Services;
using SailboatsApp.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IReservationsService, ReservationsService>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
builder.Services.AddScoped<ISailboatsRepository, SailboatsRepository>();
builder.Services.AddScoped<IBoatStandardRepository, BoatStandardRepository>();
builder.Services.AddDbContext<SailboatsDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();