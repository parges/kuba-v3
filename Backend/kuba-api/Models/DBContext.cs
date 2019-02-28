using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace kubaapi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Document> Documents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            addPatients(modelBuilder);
            addDocuments(modelBuilder);

        }

        private static void addPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                Firstname = "Kleiner",
                Lastname = "Hase",
                Birthday = new DateTime(1988, 8, 11),
                Tele = "0177123456"
            });
        }

        private void addDocuments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasData(new Document()
                {
                    Id = 1,
                    Name = "Anamnese",
                }, 
                new Document()
                {
                    Id = 2,
                    Name ="Testung"
                },
                new Document()
                {
                    Id = 3,
                    Name = "Report"
                });
        }
    }
}
