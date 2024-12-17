
using MediSez.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using MediSez.Data.Services;
using MediSez.Data.Interfaces;
using Serilog;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace MediSez.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Information("Application Init Started");

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            //builder.Services.AddCors();
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            // Add services to the container.
            builder.Services.AddAuthorization();
            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddTransient<ExceptionMiddleware>();
            builder.Services.AddSingleton<ISearch, SearchService>();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.User.Identity.Name ?? httpContext.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 10,
                            Window = TimeSpan.FromMinutes(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 2
                        }));
            });
            Log.Information("Application Init Completed");


            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();  
                builder.AllowAnyMethod();
            });
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}