using Microsoft.Extensions.Options;
using SistemaColecionador.Api.Settings;
using SistemaColecionador.Domain.Interfaces;
using SistemaColecionador.Domain.Interfaces.Repositories;
using SistemaColecionador.Domain.Interfaces.Services;
using SistemaColecionador.Domain.Services;
using SistemaColecionador.Infra.Mongo;

namespace SistemaColecionador;

public sealed class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
        builder.Services.AddSingleton<IMongoSettings>(s => s.GetRequiredService<IOptions<MongoSettings>>().Value);
        builder.Services.AddSingleton<IBookRepository, BookRepository>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IBookService, BookService>();
        builder.Services.AddSingleton<IUserService, UserService>();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowAll");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}