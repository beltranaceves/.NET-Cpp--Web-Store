using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao
{
    public interface ICategoryDao : IGenericDao<Category, Int64>
    {
        /// <summary>
        /// Finds a Category by categoryName
        /// </summary>
        /// <param name="categoryName">The category name</param>
        /// <returns>The Category</returns>
        /// <exception cref="InstanceNotFoundException"/>
        Category FindByCategoryName(string categoryName);
    }
}