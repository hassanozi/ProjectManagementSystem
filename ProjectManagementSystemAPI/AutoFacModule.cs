using Autofac;
using AutoMapper;

using ProjectManagementSystemAPI.Data;
using ProjectManagementSystemAPI.DTOs;
using ProjectManagementSystemAPI.MapperProfile;
using ProjectManagementSystemAPI.Model;

//using ProjectManagementSystemAPI.Mediators.Users;
using ProjectManagementSystemAPI.Repositories;


//using ProjectManagementSystemAPI.Services.Users;


namespace ProjectManagementSystemAPI
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UserState>().InstancePerLifetimeScope();
            builder.RegisterType<ControllereParameters>().InstancePerLifetimeScope();
            builder.RegisterType<RequestParameters>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<TaskProfile>();
                cfg.AddProfile<UserProjectProfile>();
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<RoleProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            
            //builder.RegisterAssemblyTypes(typeof(ConfirmReservationValidator).Assembly)
            //   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //   .AsImplementedInterfaces();
        }
    }
}
