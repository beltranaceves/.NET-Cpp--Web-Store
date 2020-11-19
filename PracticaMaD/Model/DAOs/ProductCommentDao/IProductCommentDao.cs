using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentDao
{
    public interface IProductCommentDao : IGenericDao<ProductComment, Int64>
    {

        List<Product> FindByProduct(Product product);
    }
}