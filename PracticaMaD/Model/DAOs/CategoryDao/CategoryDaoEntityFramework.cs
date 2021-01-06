using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao
{
    /// <summary>
    /// Specific Operations for Category
    /// </summary>
    public class CategoryDaoEntityFramework : GenericDaoEntityFramework<Category, Int64>, ICategoryDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public CategoryDaoEntityFramework()
        {
        }

        #endregion Public Constructors

        #region ICategoryDao Members. Specific Operations

        /// <summary>
        /// Finds a Category by categoryName
        /// </summary>
        /// <param name="categoryName">The category name</param>
        /// <returns>The Category</returns>
        /// <exception cref="InstanceNotFoundException"/>
        public Category FindByCategoryName(string categoryName)
        {
            Category cat = null;

            DbSet<Category> category = Context.Set<Category>();

            var result =
                (from c in category
                 where c.categoryName == categoryName
                 select c);

            cat = result.FirstOrDefault();

            if (cat == null)
                throw new InstanceNotFoundException(categoryName,
                    typeof(Category).FullName);

            return cat;
        }

        #endregion ICategoryDao Members. Specific Operations
    }
}