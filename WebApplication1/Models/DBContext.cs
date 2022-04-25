using LCM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCM.DBContext
{
    public class DBContext : DbContext
    {
        public DbSet<FixedFSEs> FixedFSE { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        public DBContext(DbContextOptions<DBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<FixedFSEs>().ToTable("FixedFSEs");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserGroup>().ToTable("UserGroups");

            // Configure Primary Keys  
            modelBuilder.Entity<FixedFSEs>().HasKey(ug => ug.ID).HasName("PK_FixedFSE");
            modelBuilder.Entity<UserGroup>().HasKey(ug => ug.ID).HasName("PK_UserGroups");
            modelBuilder.Entity<User>().HasKey(u => u.ID).HasName("PK_User");

            // Configure indexes  
            modelBuilder.Entity<FixedFSEs>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
            modelBuilder.Entity<UserGroup>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_GroupName");
            modelBuilder.Entity<User>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<User>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");

            // Configure columns  
            modelBuilder.Entity<FixedFSEs>().Property(ug => ug.ID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<FixedFSEs>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<FixedFSEs>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<FixedFSEs>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<User>().Property(u => u.ID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.UserGroupId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            modelBuilder.Entity<UserGroup>().Property(ug => ug.ID).HasColumnType("int").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UserGroup>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

            // Configure relationships  
            modelBuilder.Entity<User>().HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.ID).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
        }

}
}