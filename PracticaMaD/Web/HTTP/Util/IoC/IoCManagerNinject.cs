using Ninject;
using System.Configuration;
using System.Data.Entity;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderService;
using Es.Udc.DotNet.PracticaMaD.Model.Service.ClientOrderLineService;

namespace Es.Udc.DotNet.PracticaMad.Web.HTTP.Util.IoC
{
    internal class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;

        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

            /* ClientDao */
            kernel.Bind<IClientDao>().
                To<ClientDaoEntityFramework>();

            /* ClientService */
            kernel.Bind<IClientService>().
                To<ClientService>();

            /* ClientOrderService */
            kernel.Bind<IClientOrderService>().
                To<ClientOrderService>();

            /* ClientOrderLineService */
            kernel.Bind<IClientOrderLineService>().
                To<ClientOrderLineService>();


            /* DbContext */
            string connectionString =
                ConfigurationManager.ConnectionStrings["PracticaMADEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}