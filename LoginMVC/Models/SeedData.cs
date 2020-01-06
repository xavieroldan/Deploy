using LoginMVC.Contexts;
using LoginMVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Models
{
    public class SeedData
    {

        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    using (var context = new UserMySQLContext())
        //    {
        //        context.Database.EnsureCreated();
        //        // Look for any users.
        //        if (context.User.Any())
        //        {
        //            return;   // DB has been seeded
        //        }

        //        context.User.AddRange(
        //            new User
        //            {
        //                Name = "Lolo",
        //                Pass = "1234",
        //                Role = "user"

        //            },

        //            new User
        //            {
        //                Name = "Xavi",
        //                Pass = "4567",
        //                Role = "admin"

        //            },

        //            new User
        //            {
        //                Name = "Root",
        //                Pass = "toor",
        //                Role = "root"

        //            },

        //            new User
        //            {
        //                Name = "user",
        //                Pass = "user",
        //                Role = "test"
        //            }
        //        );
        //        context.SaveChanges();
        //    }
        //}
    }
}
