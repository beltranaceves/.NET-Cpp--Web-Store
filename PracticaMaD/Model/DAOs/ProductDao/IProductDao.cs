using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao
{
    public interface IProductDao : IGenericDao<Product, Int64>
    {
        /// <summary>
        /// Finds all products by categoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>A list of Product</returns>

        List<Product> findByCategory(Category category);

        List<Category> findByProductNameKeyword(String keyword);

        List<Category> findByProductNameKeywordAndCategory(String keyword, Category category);
    }
}