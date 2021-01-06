using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientOrderLineDao
{
    public interface IClientOrderLineDao : IGenericDao<ClientOrderLine, Int64>
    {
        /// <summary>
        /// Finds all the lines of an order
        /// </summary>
        /// <param name="orderId">keyword</param>
        /// <param name="startIndex">startIndex</param>
        /// <param name="count">count</param>
        /// <returns>A list of Product</returns>
        List<ClientOrderLine> FindOrderLines(long orderId);
    }
}