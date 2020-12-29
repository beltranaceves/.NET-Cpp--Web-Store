using Ninject;
using System.Configuration;
using System.Data.Entity;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;

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

            /* ProductDao */
            kernel.Bind<IProductDao>().
                To<ProductDaoEntityFramework>();

            /* ProductService */
            kernel.Bind<IProductService>().
                To<ProductService>();

            /* CategoryDao */
            kernel.Bind<ICategoryDao>().
                To<CategoryDaoEntityFramework>();

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