using LoginMVC.Models;
using Pomelo.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoginMVC.Contexts
{
    public class UserMySQLContext : DbContext
    {
        public UserMySQLContext() { }
        public UserMySQLContext(DbContextOptions<UserMySQLContext> options) : base (options)
        { }

        public DbSet<User> User { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn_string = "server=127.0.0.1;database=loginmvc;uid=user1;pwd=1234;";
                optionsBuilder.UseMySql(conn_string);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Pass).IsRequired();
                entity.Property(e => e.Role);
            });
        }   
    }
}
