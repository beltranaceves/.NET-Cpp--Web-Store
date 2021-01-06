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
        /// Finds all products by category
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByCategory(Category category, int startIndex, int count);

        /// <summary>
        /// Finds all products by keyword
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByProductNameKeyword(String keyword, int startIndex, int count);

        /// <summary>
        /// Finds all products by keyword
        /// </summary>
        /// <param name="keyword">keyword</param>
        /// <param name="category">keyword</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<Product> FindByProductNameKeywordAndCategory(String keyword, Category category, int startIndex, int count);

        /// <summary>
        /// Finds all products by name
        /// </summary>
        /// <param name="Productname">name</param>
        /// <returns>A Product</returns>
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