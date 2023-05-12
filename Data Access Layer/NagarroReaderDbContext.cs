using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Shared;


namespace Data_Access_Layer
{
    public class NagarroReaderDbContext : IdentityDbContext
    {
        public NagarroReaderDbContext(DbContextOptions<NagarroReaderDbContext> options) : base(options)
        {

        }

        public DbSet<Event> EventModels { get; set; }
        public DbSet<IdentityUser> EmailModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
