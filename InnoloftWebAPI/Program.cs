using InnofoltDataAccess;
using InnofoltDataAccess.Abstract;
using InnoloftWebAPI.Business.Abstract;
using InnoloftWebAPI.Business.Concrete;
using InnoloftWebAPI.DataAccess.Abstract;
using InnoloftWebAPI.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InnofoltDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("WebApiDatabase"));
});
builder.Services.AddScoped<IEventDal, EfEventDal>();
builder.Services.AddScoped<IParticipantDal, EfParticipantDal>();
builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InnofoltDbContext>();
    db.Database.Migrate();
}

app.MapControllers();

app.Run();
