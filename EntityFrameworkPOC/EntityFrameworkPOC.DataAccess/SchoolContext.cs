using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPOC.DataAccess
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=AlaskaDbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Migrations.Configuration>("AlaskaDbConnection"));
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<StudentAddress> StudentAddresss { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("dbo");
            //Mapping entity to table
            //modelBuilder.Entity<Student>().ToTable("StudentMaster");

            //Mapping single entity to different table

            //modelBuilder.Entity<Student>()
            //    .Map(m =>
            //    {
            //        m.Properties(p => new { p.StudentKey, p.StudentName });
            //        m.ToTable("StudentMaster");
            //    })
            //    .Map(m =>
            //    {
            //        m.Properties(p => new { p.StudentKey, p.DateOfBirth, p.Height, p.Weight, p.Photo });

            //        //m.Property(p => new { p.StudentID });
            //        m.ToTable("StudentDetails");
            //    });
            //modelBuilder.Entity<Standard>().ToTable("StandardMaster");


            //Setting Primary Key
            modelBuilder.Entity<Student>().HasKey<int>(p => p.StudentKey);

            //Property Mapping

            //Not Null Column
            modelBuilder.Entity<Student>()
                .Property(p => p.DateOfBirth)
                .HasColumnName("DOB")
                .HasColumnOrder(3)
                .HasColumnType("datetime2")
                .IsRequired();

            //Nullable column
            modelBuilder.Entity<Student>()
                .Property(p => p.Photo)
                .HasColumnOrder(4)
                .HasColumnName("Picture")
                .IsOptional();

            //Max length and convert data type from nvarchar to nchar using Isfixedlength
            modelBuilder.Entity<Student>()
                .Property(p => p.StudentName)
                .HasMaxLength(50)
                .IsFixedLength();

            //Set size decimal(2,2)
            modelBuilder.Entity<Student>()
                .Property(p => p.Height)
                .HasPrecision(2, 2);

            //Setting a property as Cancellation token i.e. this column will always be included in update and delete
            //request
            //modelBuilder.Entity<Student>()
            //    .Property(p => p.StudentName)
            //    .IsConcurrencyToken();
            //To make a byte property of the entity class as concurency token we can use IsRowversion method.
            //modelBuilder.Entity<Student>()
            //    .Property(p => p.Photo)
            //    .IsRowVersion();

            /*-----------------------------Relationship Mapping---------------------------------*/

            //One to zero or One relationship

            //*Uncomment the StudentAddressId property in StudentAddress class to use the below code.
            //1. If the entity follows the code first convention for primary key in StudentAddress i.e. if it 
            //has StudentAddressID property then we can make the relationship as below
            // Configure Student & StudentAddress entity

            //modelBuilder.Entity<Student>()
            //            .HasOptional(s => s.Address) // Mark Address property optional in Student entity
            //            .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student

            //2. If entity does not follow the convention
            //Set the StudentID property in the StudentAddress entity as PK for StudentAddress
            modelBuilder.Entity<StudentAddress>()
                .HasKey(p => p.StudentId);
            //Set the one to one relationship
            modelBuilder.Entity<Student>()
                .HasOptional(e => e.Address)
                .WithRequired(ad => ad.Student);
            //One to Many Relationship

            modelBuilder.Entity<Student>()
                    .HasRequired<Standard>(s => s.Standard)
                    .WithMany(s => s.Students)
                    .HasForeignKey(s => s.StdId);

            //Many to many relationship

            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRefId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });
        }
    }
}
