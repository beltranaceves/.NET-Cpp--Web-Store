using System;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao
{
    public interface IClientDao : IGenericDao<Client, Int64>
    {
        /// <summary>
        /// Finds a Client by clientLogin
        /// </summary>
        /// <param name="clientLogin">clientLogin</param>
        /// <returns>The Client</returns>
        /// <exception cref="InstanceNotFoundException"/>
        Client FindByLogin(String clientLogin);
    }
}