using Microsoft.AspNetCore.Hosting;
using server.Repositories;
using sheltermini.server.Repositories;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           builder.Services.AddSingleton<IShelterRepository, ShelterRepositoryMongoDB>();
           builder.Services.AddSingleton<IBookingRepos, BookingRepos>();

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("policy",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyMethod()
        .AllowAnyHeader();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseCors("policy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}