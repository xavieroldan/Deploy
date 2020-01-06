using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using LoginMVC.Data;
using LoginMVC.Models;
using Microsoft.Extensions.DependencyInjection;
using LoginMVC.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace LoginMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InsertData();
            PrintData();
            CreateHostBuilder(args).Build().Run();

            static void InsertData()
            {
                using (var context = new UserMySQLContext())
                {
                    // Creates the database if not exists
                    if (!context.User.Any())
                    {
                        context.Database.EnsureCreated();

                        // Adds an element
                        var user = new User
                        {
                            Name = "Lolo",
                            Pass = "1234",
                            Role = "user"
                        };
                        context.User.Add(user);

                        // Saves changes
                        context.SaveChanges();
                    }
                }
            }

            static void PrintData()
            {
                // Gets and prints all in database
                using (var context = new UserMySQLContext())
                {
                    var users = context.User;

                    if (context.User.Any())
                    {
                        foreach (var user in users)
                        {
                            var data = new StringBuilder();
                            data.AppendLine($"Name: {user.Name} ");
                            data.AppendLine($"Password: {user.Pass} ");
                            data.AppendLine($"Role: {user.Role}");
                            Console.WriteLine(data.ToString());
                        }
                    }
                    else { Console.WriteLine("Data not found in DB"); }
                }

                
                //var host = CreateHostBuilder(args).Build().Run();

                //using (var scope = host.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;

                //    try
                //    {
                //        //SeedData.Initialize(services);
                //    }
                //    catch (Exception ex)
                //    {
                //        var logger = services.GetRequiredService<ILogger<Program>>();
                //        logger.LogError(ex, "An error occurred seeding the DB.");
                //    }
                //}

                //host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
