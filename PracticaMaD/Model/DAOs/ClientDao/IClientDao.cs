using System;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao
{
    public interface IClientDao : IGenericDao<IClientDao, Int64>
    {
        /* <summary>
         * See if the client exists
         * </summary>
         * <param name ="clientLogin">clientLogin</param>
         * <returns> A boolean </returns>
         */

        Boolean existsLogin(String clientLogin);
    }
}