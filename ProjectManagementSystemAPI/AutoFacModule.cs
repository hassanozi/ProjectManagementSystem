using Autofac;
using AutoMapper;

using ProjectManagementSystemAPI.Data;

using ProjectManagementSystemAPI.Mediators.Users;
using ProjectManagementSystemAPI.Repositories;


using ProjectManagementSystemAPI.Services.Users;


namespace ProjectManagementSystemAPI
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
           

            //builder.RegisterType<UserMediator>().As<IUserMediator>().InstancePerLifetimeScope();
           

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<UserProfile>();
                //cfg.AddProfile<RoomProfile>();
                //cfg.AddProfile<FeedbackProfile>();
                //cfg.AddProfile<FacilityProfile>();
                //cfg.AddProfile<PictureProfile>();
                //cfg.AddProfile<ReservationProfile>();
                //cfg.AddProfile<RoomReservationProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            
            //builder.RegisterAssemblyTypes(typeof(ConfirmReservationValidator).Assembly)
            //   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //   .AsImplementedInterfaces();
        }
    }
}
