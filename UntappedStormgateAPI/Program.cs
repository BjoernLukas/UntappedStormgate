using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UntappedAPI.DatabaseContext;
using UntappedAPI.Service;

namespace UntappedAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Logging
            builder.Logging.ClearProviders();
            builder.Logging.AddDebug(); // Sends to Output -> Debug window
            builder.Logging.AddConsole();

            builder.Logging.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.None);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // custom Services
            builder.Services.AddScoped<UntappedApiService>();
            builder.Services.AddScoped<PlayerDiscoveryService>();
            builder.Services.AddSingleton<CountService>();


            // Register the DbContext with dependency injection  
            builder.Services.AddDbContext<UntappedDbContext>(options =>
            {
                options
                .UseSqlServer(builder.Configuration["ConnectionStrings:BLKDbContextConnection"]);
            });

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
        }
    }
}
