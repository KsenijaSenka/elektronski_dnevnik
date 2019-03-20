using Elektronski_Dnevnik.Converters;
using Elektronski_Dnevnik.Infrastructure;
using Elektronski_Dnevnik.Models.DTOs;
using Elektronski_Dnevnik.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Elektronski_Dnevnik.Models
{
    public class InitializeWithDefaultValues : DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            manager.Create(new IdentityRole("administrator"));
            manager.Create(new IdentityRole("teacher"));
            manager.Create(new IdentityRole("parent"));
            manager.Create(new IdentityRole("pupil"));

            var userStore = new UserStore<Pupil>(context);
            var userManager = new UserManager<Pupil>(userStore);

            Pupil pupil = new Pupil();
            
            pupil.Email = "ucenik@skola.com";
            pupil.UserName = "Ivanvasiljevic";
            pupil.FirstName = "Ivan";
            pupil.LastName = "Vasiljevic";
            pupil.Grade = 1;
                        
                        userManager.Create(pupil, "mijosvolemoskolu");
            userManager.AddToRole(pupil.Id, "pupil");
            Pupil pupil1 = new Pupil();
            
            pupil1.Email = "ucenik1@skola.com";
            pupil1.UserName = "Goranvasiljevic";
            pupil1.FirstName = "Goran";
            pupil1.LastName = "Vasiljevic";
            pupil1.Grade = 2;
            
            userManager.Create(pupil1, "nevoleskolu");
            userManager.AddToRole(pupil1.Id, "pupil");
            var userStore1 = new UserStore<AdminUser>(context);
            var userManager1 = new UserManager<AdminUser>(userStore1);
            AdminUser admin1 = new AdminUser();
            admin1.Email = "admin1@skola.com";
            
            admin1.UserName = "ksenijasenka";
            admin1.FirstName = "Ksenija";
            admin1.LastName = "Lazor";
            admin1.ShortName = "admin1";
            

            userManager1.Create(admin1, "Admin0202");
            userManager1.AddToRole(admin1.Id, "administrator");

            AdminUser admin2 = new AdminUser();
            admin2.Email = "admin2@skola.com";
           
            admin2.UserName = "banelaki";
            admin2.FirstName = "Branislav";
            admin2.LastName = "Lazor";
            admin2.ShortName = "admin2";

            userManager1.Create(admin2, "Admin2202");
            userManager1.AddToRole(admin2.Id, "administrator");

            var userStore2 = new UserStore<Teacher>(context);
            var userManager2 = new UserManager<Teacher>(userStore2);

            

            Teacher teacher1 = new Teacher();
            
            teacher1.Email = "matematicar@skola.com";
            teacher1.UserName = "matematicar";
            teacher1.FirstName = "Matija";
            teacher1.LastName = "Djokic";
            
              
            userManager2.Create(teacher1, "Bernuli");
            userManager2.AddToRole(teacher1.Id, "teacher");

            Teacher teacher2 = new Teacher();
            
            teacher2.Email = "fizicar@skola.com";
            teacher2.UserName = "fizicar";
            teacher2.FirstName = "Aleksa";
            teacher2.LastName = "Aleksic";


            userManager2.Create(teacher2, "Nastfiz");
            userManager2.AddToRole(teacher2.Id, "teacher");

            Teacher teacher3 = new Teacher();
           
            teacher3.Email = "englez@skola.com";
            teacher3.UserName = "engleZ";
            teacher3.FirstName = "Aleksandar";
            teacher3.LastName = "Aleksic";
            
            userManager2.Create(teacher3, "EngleZ");
            userManager2.AddToRole(teacher3.Id, "teacher");
            Teacher teacher4 = new Teacher();
            
            teacher4.Email = "engleskinja@skola.com";
            teacher4.UserName = "engleskinjA";
            teacher4.FirstName = "Aleksandra";
            teacher4.LastName = "Aleksic";
            
            
            
            userManager2.Create(teacher4, "Engleskinja");
            userManager2.AddToRole(teacher4.Id, "teacher");

            var userStore3 = new UserStore<Parent>(context);
            var userManager3 = new UserManager<Parent>(userStore3);

            Parent parent = new Parent();
            parent.Email = "tatamata@skola.com";
            parent.UserName = "tatica";
            parent.FirstName = "Marko";
            parent.LastName = "Jankovski";

            userManager3.Create(parent, "Tatamj");
            userManager3.AddToRole(parent.Id, "parent");
            Parent parent1 = new Parent();
            parent1.Email = "tataa@skola.com";
            parent1.UserName = "tataneki";
            parent1.FirstName = "Milan";
            parent1.LastName = "Crnjanski";

            userManager3.Create(parent1, "Tataneki");
            userManager3.AddToRole(parent1.Id, "parent");
            Parent parent2 = new Parent();
            parent2.Email = "majka@skola.com";
            parent2.UserName = "Marica";
            parent2.FirstName = "Marijana";
            parent2.LastName = "Glavaški";
            IList<Pupil> pupils = new List<Pupil>();
            pupils.Add(new Pupil() { LastName = "Glavaški", FirstName = "Filip", UserName = "glavonja", Grade = 3, Email = "nestoglav@gmail.com" });
            pupils.Add(new Pupil() { LastName = "Glavaški", FirstName = "Fiona", UserName = "glavonjinasestra", Grade = 4, Email = "glav@gmail.com" });
            parent2.Pupils = pupils;
            userManager3.Create(parent2, "GlavMar");
            userManager3.AddToRole(parent2.Id, "parent");

            Parent parent3 = new Parent();
            parent3.Email = "majka2@skola.com";
            parent3.UserName = "Marija";
            parent3.FirstName = "Marijana";
            parent3.LastName = "Grozdanić";
            IList<Pupil>students=new List<Pupil>();
            students.Add(new Pupil() { LastName = "Grozdanić", FirstName = "Filip", UserName = "fickog", Grade = 3, Email = "nesto@gmail.com" });
            parent3.Pupils = students;
            userManager3.Create(parent3, "GroMari");
            userManager3.AddToRole(parent3.Id, "parent");



            IList<Subject> subjects = new List<Subject>();

            subjects.Add(new Subject() { SubjectID=1, SubjectName = "Matematika_1", ClassesPerWeek = 3 });
            subjects.Add(new Subject() { SubjectID=2,SubjectName = "Matematika_2", ClassesPerWeek = 4 });
            subjects.Add(new Subject() {SubjectID=3, SubjectName = "Matematika_3", ClassesPerWeek = 4 });
            subjects.Add(new Subject() { SubjectID = 4, SubjectName = "Fizika_6", ClassesPerWeek = 2 });
            subjects.Add(new Subject() { SubjectID = 5, SubjectName = "Srpski_jezik_3", ClassesPerWeek = 4 });
            subjects.Add(new Subject() { SubjectID = 6, SubjectName = "Hemija_8", ClassesPerWeek = 2 });
            subjects.Add(new Subject() { SubjectID = 7, SubjectName = "Fizičko_vaspitanje_7", ClassesPerWeek = 4 });
            subjects.Add(new Subject() { SubjectID = 8, SubjectName = "Engleski_jezik_5", ClassesPerWeek = 2 });
            subjects.Add(new Subject() { SubjectID = 9, SubjectName = "Svet_oko_nas_4", ClassesPerWeek = 3 });
            subjects.Add(new Subject() { SubjectID = 10, SubjectName = "Engleski_jezik_6", ClassesPerWeek = 2 });

            
            context.Subjects.AddRange(subjects);
            Subject subject11 = new Subject();
            subject11.SubjectID = 11;
            subject11.SubjectName = "Engleski_jezik_7";
            subject11.ClassesPerWeek = 2; 
            
            context.Subjects.Add(subject11);
            IList<StudentClass> classes = new List<StudentClass>();

            classes.Add(new StudentClass() { ClassID = 1, No=1, Grade=1 });
            classes.Add(new StudentClass() { ClassID = 2, No = 2, Grade = 1 });
            classes.Add(new StudentClass() { ClassID = 3, No = 1, Grade = 2 });
            classes.Add(new StudentClass() { ClassID = 4, No = 3, Grade = 3 });
            classes.Add(new StudentClass() { ClassID = 5, No = 4, Grade = 4 });
            classes.Add(new StudentClass() { ClassID = 6, No = 1, Grade = 5 });
            classes.Add(new StudentClass() { ClassID = 7, No = 6, Grade = 6 });
            classes.Add(new StudentClass() { ClassID = 8, No = 3, Grade = 7 });
            classes.Add(new StudentClass() { ClassID = 9, No = 1, Grade = 8 });


            context.StudentClass.AddRange(classes);
            base.Seed(context);


            
        }
    }
}

    
    
