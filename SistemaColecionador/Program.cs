using Microsoft.Extensions.Options;
using SistemaColecionador.Api.Settings;
using SistemaColecionador.Domain.Interfaces;
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
            option.AddPolicy(name: "_myOrigins",
                               policy =>
                               {
                                   policy.WithOrigins("*");
                               });
        });

        builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
        builder.Services.AddSingleton<IMongoSettings>(s => s.GetRequiredService<IOptions<MongoSettings>>().Value);
        builder.Services.AddSingleton<IBookRepository, BookRepository>();
        builder.Services.AddSingleton<IBookService, BookService>();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("_myOrigins");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}