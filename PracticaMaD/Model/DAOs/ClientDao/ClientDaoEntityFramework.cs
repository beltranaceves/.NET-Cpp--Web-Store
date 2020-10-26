using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMAD.Model.DAOs.ClientDao
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
        public Boolean existsLogin(string clientLogin)
        {
            client client = null;

            //Connection using Linq
            DbSet<Client> client = Context.Set<Client>();

            var result =
                (from c in client
                 where c.clientLogin == clientLogin
                 select c).Any();

            return result;
        }
    }
}