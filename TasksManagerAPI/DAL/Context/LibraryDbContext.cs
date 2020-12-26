using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class LibraryDbContext : DbContext
    {
        DbSet<DocumentModel> DocumentModels { get; set; }
        DbSet<UserModel> UserModels { get; set; }

        public LibraryDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasMany(p => p.Documents).WithOne(x => x.UserModel).HasForeignKey(p => p.UserModelId);     
        }
    }
}
