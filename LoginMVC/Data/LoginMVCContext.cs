using LoginMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Data
{
    public class LoginMVCContext : DbContext
    {
            public LoginMVCContext(DbContextOptions<LoginMVCContext> options)
                : base(options)
            {
            }

            public DbSet<User> User { get; set; }
    }
}
