using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ProductCommentTagDao
{
    public interface IProductCommentTagDao : IGenericDao<ProductCommentTag, Int64>
    {

        List<ProductCommentTag> FindByProductCommentId(long productCommentId);

        Boolean ExistsByProductCommentIdAndTagId(long productCommentId, long tagId);
    }
}
