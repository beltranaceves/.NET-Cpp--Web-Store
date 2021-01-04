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
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByProductNameKeyword(String keyword, int startIndex, int count);

        List<Product> FindByProductNameKeywordAndCategory(String keyword, Category category);

        Product FindByProductName(string Productname);

        /// <summary>
        /// Finds all products by tagName
        /// </summary>
        /// <param name="tagName">tagName</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByTag(string tagName, int startIndex, int count);
    }
}