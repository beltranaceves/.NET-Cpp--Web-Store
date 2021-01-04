using Ninject;
using System.Configuration;
using System.Data.Entity;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;
using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMad.Model.Services.CreditCardService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CreditCardDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductCommentService;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.TagDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.ClientOrderService;
using Es.Udc.DotNet.PracticaMad.Model.Services.TagService;

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

            /* ClientOrderService */
            kernel.Bind<IClientOrderService>().
                To<ClientOrderService>();

            /* CreditCardService */
            kernel.Bind<ICreditCardService>().
                To<CreditCardService>();

            /* TagService */
            kernel.Bind<ITagService>().
                To<TagService>();

            /* ClientOrderDao */
            kernel.Bind<IClientOrderDao>().
                To<ClientOrderDaoEntityFramework>();

            /* ProductComment Service */
            kernel.Bind<IProductCommentService>().
                To<ProductCommentService>();

            /* ProductCommentDao */
            kernel.Bind<IProductCommentDao>().
                To<ProductCommentDaoEntityFramework>();

            /* TagDao */
            kernel.Bind<ITagDao>().
                To<TagDaoEntityFramework>();

            /* ClientOrderLineDao */
            kernel.Bind<IClientOrderLineDao>().
                To<ClientOrderLineDaoEntityFramework>();

            /* CategoryDao */
            kernel.Bind<ICategoryDao>().
                To<CategoryDaoEntityFramework>();

            /* CreditCardDao */
            kernel.Bind<ICreditCardDao>().
                To<CreditCardDaoEntityFramework>();

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