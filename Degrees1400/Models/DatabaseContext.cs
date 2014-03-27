using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Degrees1400.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }

        public DatabaseContext() : base("1400Degrees") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().Property(p => p.EmailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}