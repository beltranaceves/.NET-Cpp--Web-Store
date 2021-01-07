using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMad.Model.Objetos;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ProductService
{
    public class ProductService : IProductService
    {
        private MemoryCache _Cache = new MemoryCache("cache");
        public MemoryCache Cache { get => _Cache; }

        [Inject]
        public IProductDao ProductDao { private get; set; }

        [Inject]
        public ICategoryDao CategoryDao { private get; set; }

        #region IProductService Members

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails FindProductDetails(long productId)
        {
            Product product = ProductDao.Find(productId);
            Category category = CategoryDao.Find(product.categoryId);


            ProductDetails productDetails;
            if (product is Books)
            {
                Books bk = product as Books;
                productDetails = new BooksDetails(productId, product.productName, product.price, product.registerDate, product.stock, category.categoryName,
                    bk.author, bk.pages, bk.ISBN, bk.editorial);
            }
            else if (product is Films)
            {
                Films fm = product as Films;
                productDetails = new FilmsDetails(productId, product.productName, product.price, product.registerDate, product.stock, category.categoryName,
                    fm.director, fm.filmYear, fm.duration, fm.genere);
            }
            else if (product is Music)
            {
                Music m = product as Music;
                productDetails = new MusicDetails(productId, product.productName, product.price, product.registerDate, product.stock, category.categoryName,
                    m.artist, m.genere, m.type);
            }
            else
                productDetails = new ProductDetails(productId, product.productName, product.price, product.registerDate, product.stock, category.categoryName);

            return productDetails;
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails UpdateProduct(long productId, ProductDetails updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);
            Category category = CategoryDao.FindByCategoryName(updatedProduct.CategoryName);

            if (product == null || category == null)
            {
                throw new InstanceNotFoundException(product, "Product not correct");
            }
            product.productName = updatedProduct.ProductName;
            product.price = updatedProduct.Price;
            product.registerDate = updatedProduct.RegisterDate;
            product.stock = updatedProduct.Stock;
            product.categoryId = category.categoryId;

            ProductDao.Update(product);

            return new ProductDetails(product.productId, product.productName, product.price, product.registerDate, product.stock, updatedProduct.CategoryName);
        }



        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails UpdateBooks(long productId, BooksDetails updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);
            Category category = CategoryDao.FindByCategoryName(updatedProduct.CategoryName);

            Books bk = product as Books;

            if (product == null || category == null)
            {
                throw new InstanceNotFoundException(product, "Product not correct");
            }

            bk.productName = updatedProduct.ProductName;
            bk.price = updatedProduct.Price;
            bk.registerDate = updatedProduct.RegisterDate;
            bk.stock = updatedProduct.Stock;
            bk.categoryId = category.categoryId;

            bk.author = updatedProduct.Author;
            bk.pages = updatedProduct.Pages;
            bk.ISBN = updatedProduct.ISBN;
            bk.editorial = updatedProduct.Editorial;


            ProductDao.Update(product);

            return new BooksDetails(bk.productId, bk.productName, bk.price, bk.registerDate, bk.stock, updatedProduct.CategoryName,
                    bk.author, bk.pages, bk.ISBN, bk.editorial);
        }


        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails UpdateFilms(long productId, FilmsDetails updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);
            Category category = CategoryDao.FindByCategoryName(updatedProduct.CategoryName);

            Films f = product as Films;

            if (product == null || category == null)
            {
                throw new InstanceNotFoundException(product, "Product not correct");
            }

            f.productName = updatedProduct.ProductName;
            f.price = updatedProduct.Price;
            f.registerDate = updatedProduct.RegisterDate;
            f.stock = updatedProduct.Stock;
            f.categoryId = category.categoryId;

            f.director = updatedProduct.Director;
            f.filmYear = updatedProduct.FilmYear;
            f.duration = updatedProduct.Duration;
            f.genere = updatedProduct.Genere;


            ProductDao.Update(product);

            return new FilmsDetails(f.productId, f.productName, f.price, f.registerDate, f.stock, updatedProduct.CategoryName,
                    f.director, f.filmYear, f.duration, f.genere);
        }


        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ProductDetails UpdateMusic(long productId, MusicDetails updatedProduct)
        {
            Product product =
                ProductDao.Find(productId);
            Category category = CategoryDao.FindByCategoryName(updatedProduct.CategoryName);

            Music m = product as Music;

            if (product == null || category == null)
            {
                throw new InstanceNotFoundException(product, "Product not correct");
            }

            m.productName = updatedProduct.ProductName;
            m.price = updatedProduct.Price;
            m.registerDate = updatedProduct.RegisterDate;
            m.stock = updatedProduct.Stock;
            m.categoryId = category.categoryId;

            m.artist = updatedProduct.Artist;
            m.genere = updatedProduct.Genere;
            m.type = updatedProduct.Type;


            ProductDao.Update(product);

            return new MusicDetails(m.productId, m.productName, m.price, m.registerDate, m.stock, updatedProduct.CategoryName,
                    m.artist, m.genere, m.type);
        }

        [Transactional]
        public ProductBlock FindProductByProductNameKeyword(string keyword, int startIndex, int count)
        {
            ProductBlock prod;
            Search newSearch = new Search(keyword, null, startIndex, count);
            List<Search> lastSearches;
            lastSearches = (List<Search>)Cache["lastSearches"];

            if (lastSearches != null)
            {
                if (lastSearches.Contains(newSearch))
                {
                    prod = (ProductBlock)_Cache.Get(keyword);
                    lastSearches.Remove(newSearch);
                }
                else
                {
                    List<Product> products = ProductDao.FindByProductNameKeyword(keyword, startIndex, count + 1);

                    List<ProductDetails> productsDetails = new List<ProductDetails>();
                    bool existMoreProducts = (products.Count == count + 1);
                    foreach (Product p in products)
                    {
                        Category category = CategoryDao.Find(p.categoryId);
                        productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                    }
                    if (existMoreProducts)
                        products.RemoveAt(count);
                    prod = new ProductBlock(productsDetails, existMoreProducts);

                    /* We only save 5 searches */
                    if (lastSearches.Count() == 5)
                    {
                        lastSearches.RemoveAt(0);
                    }
                }
                lastSearches.Add(newSearch);
            }
            else
            {
                List<Product> products = ProductDao.FindByProductNameKeyword(keyword, startIndex, count + 1);

                List<ProductDetails> productsDetails = new List<ProductDetails>();
                bool existMoreProducts = (products.Count == count + 1);
                foreach (Product p in products)
                {
                    Category category = CategoryDao.Find(p.categoryId);
                    productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                }
                if (existMoreProducts)
                    products.RemoveAt(count);
                prod = new ProductBlock(productsDetails, existMoreProducts);
                lastSearches = new List<Search>();
                lastSearches.Add(newSearch);
            }

            var item = new CacheItem("lastSearches", lastSearches);
            var policy = new CacheItemPolicy();
            _Cache.Add(item, policy);

            var item2 = new CacheItem(keyword, prod);
            var policy2 = new CacheItemPolicy();
            _Cache.Add(item2, policy2);

            return prod;
        }

        [Transactional]
        public ProductBlock FindProductByProductNameKeywordAndCategory(String keyword, long categoryId, int startIndex, int count)
        {
            Category category = CategoryDao.Find(categoryId);
            ProductBlock prod;
            Search newSearch = new Search(keyword, categoryId, startIndex, count);
            List<Search> lastSearches;
            lastSearches = (List<Search>)Cache["lastSearches"];

            if (lastSearches != null)
            {
                if (lastSearches.Contains(newSearch))
                {
                    prod = (ProductBlock)_Cache.Get(keyword + categoryId.ToString());
                    lastSearches.Remove(newSearch);
                }
                else
                {
                    List<Product> products = ProductDao.FindByProductNameKeywordAndCategory(keyword, category, startIndex, count + 1);

                    List<ProductDetails> productsDetails = new List<ProductDetails>();
                    bool existMoreProducts = (products.Count == count + 1);
                    foreach (Product p in products)
                    {
                        productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                    }
                    if (existMoreProducts)
                        products.RemoveAt(count);
                    prod = new ProductBlock(productsDetails, existMoreProducts);
                    lastSearches = new List<Search>();
                }
                lastSearches.Add(newSearch);
            }
            else
            {
                List<Product> products = ProductDao.FindByProductNameKeywordAndCategory(keyword, category, startIndex, count + 1);
                List<ProductDetails> productsDetails = new List<ProductDetails>();
                bool existMoreProducts = (products.Count == count + 1);
                foreach (Product p in products)
                {
                    productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                }
                if (existMoreProducts)
                    products.RemoveAt(count);
                prod = new ProductBlock(productsDetails, existMoreProducts);
                lastSearches = new List<Search>();
            }

            var item = new CacheItem("lastSearches", lastSearches);
            var policy = new CacheItemPolicy();
            _Cache.Add(item, policy);

            var item2 = new CacheItem(keyword + categoryId.ToString(), prod);
            var policy2 = new CacheItemPolicy();
            _Cache.Add(item2, policy2);

            return prod;
        }

        [Transactional]
        public ProductBlock FindProductByCategory(long categoryId, int startIndex, int count)
        {
            Category category = CategoryDao.Find(categoryId);

            ProductBlock prod;
            Search newSearch = new Search("", categoryId, startIndex, count);
            List<Search> lastSearches;
            lastSearches = (List<Search>)Cache["lastSearches"];

            if (lastSearches != null)
            {
                if (lastSearches.Contains(newSearch))
                {
                    prod = (ProductBlock)_Cache.Get(categoryId.ToString());
                    lastSearches.Remove(newSearch);
                }
                else
                {
                    List<Product> products = ProductDao.FindByCategory(category, startIndex, count + 1);

                    List<ProductDetails> productsDetails = new List<ProductDetails>();
                    bool existMoreProducts = (products.Count == count + 1);
                    foreach (Product p in products)
                    {
                        productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                    }
                    if (existMoreProducts)
                        products.RemoveAt(count);
                    if (existMoreProducts)
                        products.RemoveAt(count);
                    prod = new ProductBlock(productsDetails, existMoreProducts);

                    /* We only save 5 searches */
                    if (lastSearches.Count() == 5)
                    {
                        lastSearches.RemoveAt(0);
                    }
                }
                lastSearches.Add(newSearch);
            }
            else
            {
                List<Product> products = ProductDao.FindByCategory(category, startIndex, count + 1);

                List<ProductDetails> productsDetails = new List<ProductDetails>();
                bool existMoreProducts = (products.Count == count + 1);
                foreach (Product p in products)
                {
                    productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
                }

                if (existMoreProducts)
                    products.RemoveAt(count);
                prod = new ProductBlock(productsDetails, existMoreProducts);
                lastSearches = new List<Search>();
                lastSearches.Add(newSearch);
            }

            var item = new CacheItem("lastSearches", lastSearches);
            var policy = new CacheItemPolicy();
            _Cache.Add(item, policy);

            var item2 = new CacheItem(categoryId.ToString(), prod);
            var policy2 = new CacheItemPolicy();
            _Cache.Add(item2, policy2);

            return prod;
        }

        [Transactional]
        public ProductBlock FindProductByTag(string tagName, int startIndex, int count)
        {
            List<Product> products = ProductDao.FindByTag(tagName, startIndex, count);
            var item = new CacheItem(tagName, products.ToString());
            var policy = new CacheItemPolicy();
            Cache.Add(item, policy);

            List<ProductDetails> productsDetails = new List<ProductDetails>();
            foreach (Product p in products)
            {
                Category category = CategoryDao.Find(p.categoryId);
                productsDetails.Add(new ProductDetails(p.productId, p.productName, p.price, p.registerDate, p.stock, category.categoryName));
            }
            bool existMoreProducts = (products.Count == count + 1);
            if (existMoreProducts)
                products.RemoveAt(count);
            ProductBlock prod = new ProductBlock(productsDetails, existMoreProducts);
            return prod;
        }

        [Transactional]
        public Product ProductByName(string productName)
        {
            Product p = ProductDao.FindByProductName(productName);
            return p;
        }

        #endregion IProductService Members
    }
}