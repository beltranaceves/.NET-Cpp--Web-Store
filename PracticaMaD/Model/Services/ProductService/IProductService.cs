using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Ninject;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public interface IProductService
    {
        [Inject]
        IProductDao ProductDao { set; }

        [Inject]
        ICategoryDao CategoryDao { set; }

        /// <summary>
        /// Count all the products of the search.
        /// </summary>
        /// <param name="keyword">The product name keyword. </param>
        /// <returns> The number of products </returns>
        [Transactional]
        int NumberOfProductsSearched(string keyword);

        /// <summary>
        /// Finds the product details.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <returns> The product details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails FindProductDetails(long productId);

        /// <summary>
        /// Updates the product details.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <param name="updatedProduct"> The updatedProduct data. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails UpdateProduct(long productId, ProductDetails updatedProduct);

        /// <summary>
        /// Finds products by name keyword.
        /// </summary>
        /// <param name="keyword"> The product name keyword. </param>
        /// <param name="startIndex"> the index (starting from 0) of the first
        /// object to return.</param>
        /// <param name="count">The maximum number of objects to return.</param>
        [Transactional]
        List<ProductDetails> FindProductByProductNameKeyword(string keyword, int startIndex, int count);

        /// <summary>
        /// Finds products by name keyword and category.
        /// </summary>
        /// <param name="keyword"> The product name keyword. </param>
        /// <param name="categoryId"> The product category. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<ProductDetails> FindProductByProductNameKeywordAndCategory(String keyword, long categoryId);

        /// <summary>
        /// Finds products by category.
        /// </summary>
        /// <param name="categoryId"> The product category. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<ProductDetails> FindProductByCategory(long categoryId);

        /// <summary>
        /// Finds products by tag.
        /// </summary>
        /// <param name="tagName"> The tag Name. </param>
        /// <param name="startIndex"> the index (starting from 0) of the first
        /// object to return.</param>
        /// <param name="count">The maximum number of objects to return.</param>
        [Transactional]
        List<ProductDetails> FindProductByTag(string tagName, int startIndex, int count);
    }
}