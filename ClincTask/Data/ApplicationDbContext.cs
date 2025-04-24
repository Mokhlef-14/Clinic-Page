using ClincTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ClincTask.Data
{
    public class ApplicationDbContext : DbContext
    {

            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Appointment> Appointments { get; set; }
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                optionsBuilder.UseSqlServer(connectionString: "Data Source =. ; Initial Catalog=ClincTask; Integrated Security = True; TrustServerCertificate = True");
            }

        }
    }

