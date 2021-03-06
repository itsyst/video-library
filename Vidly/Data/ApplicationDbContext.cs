﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Vidly.Models;
using Vidly.Dtos;


namespace Vidly.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedDatabase(modelBuilder);

            ConfigurationCustomer(modelBuilder);
 
            base.OnModelCreating(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasData(
                          new Customer { Id = 1, Name = "John Smith", IsSubscribedToNewsLetter = false, MembershipTypeId = 1 },
                          new Customer { Id = 2, Name = "Mary William", IsSubscribedToNewsLetter = true, MembershipTypeId = 2 }
                );


            modelBuilder.Entity<MembershipType>()
                .HasData(
                    new MembershipType { Id = 1, SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
                    new MembershipType { Id = 2, SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
                    new MembershipType { Id = 3, SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 },
                    new MembershipType { Id = 4, SignUpFee = 300, DurationInMonths = 12, DiscountRate = 20 }
                );

        }

        private static void ConfigurationCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
        }

        public DbSet<Vidly.Dtos.CustomerDto> CustomerDto { get; set; }

    }
}
