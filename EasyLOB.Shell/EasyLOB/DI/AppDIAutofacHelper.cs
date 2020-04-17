using Autofac;
using AutoMapper;
using EasyLOB.Environment;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        #region Methods

        public static void Setup(ContainerBuilder containerBuilder)
        {
            SetupActivity(containerBuilder);
            SetupAuditTrail(containerBuilder);
            SetupEasyLOB(containerBuilder);
            SetupExtensions(containerBuilder);
            SetupIdentity(containerBuilder);
            SetupLog(containerBuilder);

            SetupApplication(containerBuilder); // !!!

            // DIHelper
            containerBuilder.RegisterType<EnvironmentManagerDesktop>().As<IEnvironmentManager>();
            //containerBuilder.RegisterType<EnvironmentManagerWeb>().As<IEnvironmentManager>();

            IContainer container = containerBuilder.Build();

            IMapper mapper = AppHelper.SetupMappers();

            AppHelper.SetupProfiles();

            EasyLOBHelper.DIManager = new DIManagerAutofac(container);
            EasyLOBHelper.Mapper = mapper;
        }

        #endregion Methods
    }
}