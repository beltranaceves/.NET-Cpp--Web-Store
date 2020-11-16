using Es.Udc.DotNet.ModelUtil.Transactions;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Ninject;
using System;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    public interface IClientService
    {
        [Inject]
        IClientDao ClientDao { set; }

        /// <summary>
        /// Registers a new client.
        /// </summary>
        /// <param name="clientLogin"> Name of the login. </param>
        /// <param name="clearPassword"> The clear password. </param>
        /// <param name="clientDetails"> The client profile details. </param>
        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        long RegisterClient(string clientLogin, string clearPassword,
            ClientDetails clientDetails);

        //    /// <summary>
        //    /// Changes the password.
        //    /// </summary>
        //    /// <param name="clientId"> The client profile id. </param>
        //    /// <param name="oldClientPassword"> The old clear password. </param>
        //    /// <param name="newClientPassword"> The new clear password. </param>
        //    /// <exception cref="IncorrectPasswordException"/>
        //    /// <exception cref="InstanceNotFoundException"/>
        //    void ChangePassword(long clientId, String oldClientPassword,
        //        String newClientPassword);

        //    /// <summary>
        //    /// Finds the client  details.
        //    /// </summary>
        //    /// <param name="clientId"> The client id. </param>
        //    /// <returns> The client details </returns>
        //    /// <exception cref="InstanceNotFoundException"/>
        //    [Transactional]
        //    ClientDetails FindClientDetails(long clientId);

        //    /// <summary>
        //    /// Logins the specified login name.
        //    /// </summary>
        //    /// <param name="clientLogin"> Name of the login. </param>
        //    /// <param name="password"> The password. </param>
        //    /// <param name="passwordIsEncrypted"> if set to <c> true </c> [password is encrypted]. </param>
        //    /// <returns> LoginResult </returns>
        //    /// <exception cref="InstanceNotFoundException"/>
        //    /// <exception cref="IncorrectPasswordException"/>
        //    [Transactional]
        //    LoginResult Login(string clientLogin, string password,

        //        Boolean passwordIsEncrypted);

        //    /// <summary>
        //    /// Updates the client details.
        //    /// </summary>
        //    /// <param name="clientId"> The client id. </param>
        //    /// <param name="clientDetails"> The client details. </param>
        //    /// <exception cref="InstanceNotFoundException"/>
        //    [Transactional]
        //    void UpdateUserProfileDetails(long clientId,
        //        ClientDetails clientDetails);

        //    /// <summary>
        //    /// Checks if the specified clientLogin corresponds to a valid client.
        //    /// </summary>
        //    /// <param name="clientLogin"> client login name. </param>
        //    /// <returns> Boolean to indicate if the clientLogin exists </returns>
        //    bool ClientExists(string clientLogin);
    }
}