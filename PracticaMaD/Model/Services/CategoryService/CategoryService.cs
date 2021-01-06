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
    public class CategoryService : ICategoryService
    {
        [Inject]
        public ICategoryDao CategoryDao { private get; set; }

        /// <summary>
        /// Finds All Categories name.
        /// </summary>
        /// <returns> The category names </returns>

        [Transactional]
        public List<string> GetCategoryNames()
        {
            List<Category> cats = CategoryDao.GetAllElements();
            List<string> names = new List<string>();
            foreach (Category c in cats)
            {
                names.Add(c.categoryName);
            }
            return names;
        }

        [Transactional]
        public long GetCategoryId(string categoryName)
        {
            Category cat = CategoryDao.FindByCategoryName(categoryName);

            return cat.categoryId;
        }
    }
}