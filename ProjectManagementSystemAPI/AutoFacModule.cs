using Autofac;
using AutoMapper;

using ProjectManagementSystemAPI.Data;
using ProjectManagementSystemAPI.MapperProfile;
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


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<TaskProfile>();
                cfg.AddProfile<ProjectProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            
            //builder.RegisterAssemblyTypes(typeof(ConfirmReservationValidator).Assembly)
            //   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //   .AsImplementedInterfaces();
        }
    }
}
