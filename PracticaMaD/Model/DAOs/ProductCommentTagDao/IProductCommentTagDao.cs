using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentTagDao
{
    public interface IProductCommentTagDao : IGenericDao<ProductCommentTag, Int64>
    {

        List<Product> FindByProductComment(ProductComment productComment);

    }
}
