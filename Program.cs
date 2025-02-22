using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
using Animals_Web.Data;
using System.Net.WebSockets;
using Animals_Web.Animals.Repository;
using Animals_Web.Data;
using Animals_Web.Animals.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("animals-api", domain => domain.WithOrigins("")
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
        });


        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
                new MySqlServerVersion(new Version(8, 0, 21))));


        builder.Services.AddScoped<IAnimalRepo, AnimalRepo>();
        builder.Services.AddScoped<ICommandAnimalService, CommandAnimalService>();
        builder.Services.AddScoped<IQueryAnimalService, QueryAnimalService>();


        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
                Console.WriteLine("Migrarea s-a realizat cu succes!");
            }catch(Exception ex)
            {
                Console.WriteLine($"Eroare la migrare:");

            }
        }


        app.UseCors("animals-api");
        app.Run();
    }
}