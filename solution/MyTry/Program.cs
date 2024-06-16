using MyTry.Contexts;
using MyTry.Repositories;
using MyTry.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();
builder.Services.AddDbContext<S27049DbContext>();


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();