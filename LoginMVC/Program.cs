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
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
