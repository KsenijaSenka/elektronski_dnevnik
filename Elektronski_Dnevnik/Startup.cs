using Elektronski_Dnevnik.Infrastructure;
using Elektronski_Dnevnik.Models;
using Elektronski_Dnevnik.Providers;
using Elektronski_Dnevnik.Repositories;
using Elektronski_Dnevnik.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using Elektronski_Dnevnik.Services;

[assembly: OwinStartup(typeof(Elektronski_Dnevnik.Startup))]
namespace Elektronski_Dnevnik
{
    public class Startup
    { 
    public void Configuration(IAppBuilder app)
    {
        var container = SetupUnity();
        ConfigureOAuth(app, container);

        HttpConfiguration config = new HttpConfiguration();
        config.DependencyResolver = new UnityDependencyResolver(container);

        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        WebApiConfig.Register(config);
        app.UseWebApi(config);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.
                SerializerSettings.DateFormatString = "dd-MM-yyyy hh: mm: ss";
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            GlobalConfiguration.Configuration.EnsureInitialized();
        }

    public void ConfigureOAuth(IAppBuilder app, UnityContainer container)
    {
        OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        {
            AllowInsecureHttp = true,
            TokenEndpointPath = new PathString("/token"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            Provider = new SimpleAuthorizationServerProvider(container)
        };

        // Token Generation
        app.UseOAuthAuthorizationServer(OAuthServerOptions);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

    }

    private UnityContainer SetupUnity()
    {
        var container = new UnityContainer();

        // register all your components with the container here
        // it is NOT necessary to register your controllers

        // e.g. container.RegisterType<ITestService, TestService>();
        container.RegisterType<DbContext, AuthContext>(new HierarchicalLifetimeManager());
        container.RegisterType<IUnitOfWork, UnitOfWork>();
        container.RegisterType<IGenericRepository<ApplicationUser>, GenericRepository<ApplicationUser>>();
        container.RegisterType<IAuthRepository, AuthRepository>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Marks>, GenericRepository<Marks>>();
           
            container.RegisterType<IGenericRepository<StudentClass>, GenericRepository<StudentClass>>();
            container.RegisterType<IClassService, ClassService>();
            container.RegisterType<ISubjectService, SubjectService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IMarkService, MarkService>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<ITeacherService, TeacherService>();
            container.RegisterType<IGenericRepository<Pupil>, GenericRepository<Pupil>>();
            container.RegisterType<IPupilService, PupilService>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IParentService, ParentService>();
            container.RegisterType<IGenericRepository<TeacherSubjectClass>, GenericRepository<TeacherSubjectClass>>();
            container.RegisterType<IGenericRepository<TeacherSubject>, GenericRepository<TeacherSubject>>();
            container.RegisterType<IPnoService, PnoService>();
            return container;
    }
        
        

}



}