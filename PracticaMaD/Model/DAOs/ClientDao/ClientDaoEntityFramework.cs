using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using System;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao
{
    /// <summary>
    /// Specific Operations for Client
    /// </summary>
    public class ClientDaoEntityFramework :
        GenericDaoEntityFramework<Client, Int64>, IClientDao
    {
        #region Public Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        public ClientDaoEntityFramework()
        {
        }

        #endregion Public Constructors

        #region IClientDao Members. Specific Operations

        /// <summary>
        /// Finds a Client by his clientLogiin
        /// </summary>
        /// <param name="clientLogin"></param>
        /// <returns></returns>
        /// <exception cref="InstanceNotFoundException"></exception>
        public Client FindByLogin(string clientLogin)
        {
            Client client = null;

            DbSet<Client> clients = Context.Set<Client>();

            var result =
                (from u in clients
                 where u.clientLogin == clientLogin
                 select u);

            client = result.FirstOrDefault();

            if (client == null)
                throw new InstanceNotFoundException(clientLogin,
                    typeof(Client).FullName);

            return client;
        }

        #endregion IClientDao Members. Specific Operations
    }
}