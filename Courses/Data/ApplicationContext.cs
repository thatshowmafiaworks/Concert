using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Courses.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Courses.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Poster> Posters { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(u => u.Concert)
                .WithMany(c => c.Tickets)
                .HasForeignKey(u => u.ConcertId);
        }
    }
}
