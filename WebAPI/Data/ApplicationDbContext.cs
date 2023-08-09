﻿using Microsoft.EntityFrameworkCore;
using Model.DbEntities;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Patient>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Patient>().HasData(AddPatients());
        }

        private List<Patient> AddPatients()
        {
            return new List<Patient>
            {
                new Patient
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    FileNo = 1001,
                    CitizenId = "123456789",
                    BirthDate = new DateTime(1985, 5, 10),
                    Gender = 0, // 0 for Male, 1 for Female
                    Nationality = "USA",
                    PhoneNumber = "123-456-7890",
                    Email = "john.doe@example.com",
                    Country = "United States",
                    City = "New York",
                    Street = "123 Main Street",
                    Address1 = "Apartment 4A",
                    Address2 = "Building XYZ",
                    ContactPerson = "Jane Smith",
                    ContactRelation = "Spouse",
                    ContactPhone = "987-654-3210",
                    FirstVisitDate = new DateTime(2022, 3, 15),
                    RecordCreationDate = DateTime.Now
                },
                new Patient
                {
                    Id = Guid.NewGuid(),
                    Name = "Jane Smith",
                    FileNo = 1002,
                    CitizenId = "987654321",
                    BirthDate = new DateTime(1990, 8, 22),
                    Gender = 1, // 0 for Male, 1 for Female
                    Nationality = "Canada",
                    PhoneNumber = "555-123-4567",
                    Email = "jane.smith@example.com",
                    Country = "Canada",
                    City = "Toronto",
                    Street = "456 Elm Street",
                    Address1 = "Suite 8B",
                    Address2 = "Tower ABC",
                    ContactPerson = "John Doe",
                    ContactRelation = "Sibling",
                    ContactPhone = "444-789-1234",
                    FirstVisitDate = new DateTime(2021, 6, 10),
                    RecordCreationDate = DateTime.Now
                }
            };
        }
    }
}