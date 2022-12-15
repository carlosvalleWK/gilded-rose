
using GildedRose.API;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace GildedRoseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddHostedService<GildedRoseBackgroundService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

          


            app.MapGet("/getProducts", () =>
            {
                return Results.Ok(Constants.ITEMS);
            })
            .WithName("GetProducts")
            .WithOpenApi();

            app.Run();
        }
    }
}