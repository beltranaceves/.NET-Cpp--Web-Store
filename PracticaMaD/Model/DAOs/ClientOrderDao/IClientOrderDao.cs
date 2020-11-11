using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMAD.Model.DAOs.ClientDao
{

    public interface ICLientOrderDAO : ICLientOrderDAO<ClientOrder, Int64>
    {
        /// <summary>
        /// Returns a list of account operations relative to a given account
        /// made between two dates. If the account has no operations, a list
        /// of zero elements is returned.
        /// </summary>
        /// <param name="clientId">The account identifier.</param>
        /// returned (including this date).</param>
        /// <param name="startIndex">The index of the first object to return
        /// (starting in 0).</param>
        /// <param name="count">The maximum number of objects to return.

        List<ClientOrder> getAllOrders(long clientId, int startIndex, int count);
    }
}