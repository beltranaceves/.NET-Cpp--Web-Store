using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.CategoryService
{
    public interface ICategoryService
    {
        [Inject]
        ICategoryDao CategoryDao { set; }

        /// <summary>
        /// Finds All Categories name.
        /// </summary>
        /// <returns> The category names </returns>

        [Transactional]
        List<string> GetCategoryNames();

        /// <summary>
        /// Finds All Categories name.
        /// </summary>
        /// <param name="categoryName"> the category name</param>
        /// <returns> The category ID </returns>

        [Transactional]
        long GetCategoryId(string categoryName);
    }
}