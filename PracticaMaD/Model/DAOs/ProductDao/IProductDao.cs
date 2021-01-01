using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System.Collections.Generic;
using System;
using Es.Udc.DotNet.PracticaMad.Model.Services.ProductService;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao
{
    public interface IProductDao : IGenericDao<Product, Int64>
    {
        /// <summary>
        /// Finds all products by categoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByCategory(Category category);

        /// <summary>
        /// Count all products by  keyword
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <returns>Number of products</returns>
        int CountByProductNameKeywordAndCategory(String keyword);

        /// <summary>
        /// Finds all products by keyword
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <param name="page">page</param>
        /// <param name="size">size</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByProductNameKeyword(String keyword, int page, int size);

        List<Product> FindByProductNameKeywordAndCategory(String keyword, Category category);

        Product FindByProductName(string Productname);
    }
}