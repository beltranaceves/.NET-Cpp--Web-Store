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
        /// Finds the product details.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <returns> The product details </returns>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        ProductDetails FindProduct(long productId);

        /// <summary>
        /// Updates the product details.
        /// </summary>
        /// <param name="productId"> The product id. </param>
        /// <param name="updatedProduct"> The updatedProduct data. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        void UpdateProduct(long productId, Product updatedProduct);

        /// <summary>
        /// Finds products by name keyword.
        /// </summary>
        /// <param name="keyword"> The product name keyword. </param>
        [Transactional]
        List<Product> FindProductByProductNameKeyword(String keyword);

        /// <summary>
        /// Finds products by name keyword and category.
        /// </summary>
        /// <param name="keyword"> The product name keyword. </param>
        /// <param name="category"> The product category. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<Product> FindProductByProductNameKeywordAndCategory(String keyword, long categoryId);

        /// <summary>
        /// Finds products by category.
        /// </summary>
        /// <param name="category"> The product category. </param>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        List<Product> FindProductByCategory(long categoryId);
    }
}