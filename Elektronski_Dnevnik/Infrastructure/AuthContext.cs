using Elektronski_Dnevnik.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static Elektronski_Dnevnik.Models.Teacher;

namespace Elektronski_Dnevnik.Infrastructure
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext() : base("UserManagementContext71")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AuthContext>());
            Database.SetInitializer<AuthContext>(new InitializeWithDefaultValues());
        }
        public DbSet<Subject> Subjects { get; set; }
       
    
        public DbSet<Marks> Marks { get; set; }
        
        public DbSet<StudentClass> StudentClass { get; set; }
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pupil>().ToTable("Pupils");
            modelBuilder.Entity<AdminUser>().ToTable("Administrators");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Parent>().ToTable("Parents");
            modelBuilder.Entity<Marks>().ToTable("Marks");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            
            modelBuilder.Entity<StudentClass>().ToTable("StudentClasses");
            modelBuilder.Entity<TeacherSubject>().ToTable("TeacherSubjects");
            modelBuilder.Entity<TeacherSubjectClass>().ToTable("TeacherSubjectClasses");
          
        }

       
    }
    }

    



        
    
