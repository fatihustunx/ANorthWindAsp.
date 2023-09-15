
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstracts;
using Business.Conceretes;
using Business.DependencyResolver.Autofac;
using DataAccess.Abstracts;
using DataAccess.Conceretes.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // Call ConfigureContainer on the Host sub property
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

            // Add services to the container.

            builder.Services.AddControllers();

            // Autofac, Ninject, CastleWindsor...
            // StructureMap, LightInject, DryInject --> IoC
            //builder.Services.AddSingleton<IProductService,ProductManager>();
            //builder.Services.AddSingleton<IProductDal,EfProductDal>();

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


            app.MapControllers();

            app.Run();
        }
    }
}