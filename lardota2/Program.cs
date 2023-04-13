using Domain.Interfaces;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using EmoBase.Wrapper;
using Domain.Wrapper;
using Domain.Models;
using Domain;
using System.Reflection;
using System.Collections.Specialized;
using System.ComponentModel;
using Microsoft.OpenApi.Models;

namespace lardota2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EmoBaseContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmoBase;Trusted_Connection=true"));
            // Add services to the container.
            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Интернет магазин lardot",
                    Description = "Магазин dlar",
                    Contact = new OpenApiContact
                    {
                        Name = "Контакт",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Лицензия",
                        Url = new Uri("https://example.com/license")
                    }

                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

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