using RestSRV.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy  .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            ;  //set the allowed origin  
        });
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

Utils.CheckDB(app.Configuration);

app.Run();
