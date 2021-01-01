using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;
using System;
using Es.Udc.DotNet.PracticaMad.Model.Services.Exceptions;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    public class ClientService : IClientService
    {
        [Inject]
        public IClientDao ClientDao { private get; set; }

        #region IClientService Members

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long RegisterClient(String clientLogin, String clientPassword,
        ClientDetails clientDetails)
        {
            try
            {
                ClientDao.FindByLogin(clientLogin);

                throw new DuplicateInstanceException(clientLogin,
                    typeof(Client).FullName);
            }
            catch (InstanceNotFoundException)
            {
                string encryptedPassword = PasswordEncrypter.Crypt(clientPassword);

                Client client = new Client();

                client.clientLogin = clientLogin;
                client.clientPassword = encryptedPassword;
                client.firstName = clientDetails.FirstName;
                client.firstSurname = clientDetails.FirstSurname;
                client.lastSurname = clientDetails.LastSurname;
                client.email = clientDetails.Email;
                client.clientLanguage = clientDetails.ClientLanguage;
                client.clientAddress = clientDetails.ClientAddress;
                client.country = clientDetails.Country;
                client.rol = "USER";
                ClientDao.Create(client);

                return client.clientId;
            }
        }

        /// <exception cref="IncorrectPasswordException"/>
        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void ChangePassword(long clientId, string oldClearPassword,
            string newClearPassword)
        {
            Client client = ClientDao.Find(clientId);
            String storedPassword = client.clientPassword;

            if (!PasswordEncrypter.IsClearPasswordCorrect(oldClearPassword,
                 storedPassword))
            {
                throw new IncorrectPasswordException(client.clientLogin);
            }

            client.clientPassword =
            PasswordEncrypter.Crypt(newClearPassword);

            ClientDao.Update(client);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public ClientDetails FindClientDetails(long clientId)
        {
            Client client = ClientDao.Find(clientId);

            ClientDetails clientDetails =
                new ClientDetails(client.firstName,
                    client.firstSurname, client.lastSurname,
                    client.email, client.clientLanguage,
                    client.clientAddress, client.country, client.rol);

            return clientDetails;
        }

        /// <exception cref="InstanceNotFoundException"/>
        /// <exception cref="IncorrectPasswordException"/>
        [Transactional]
        public LoginResult Login(string clientLogin, string password, bool passwordIsEncrypted)
        {
            Client client =
                ClientDao.FindByLogin(clientLogin);

            String storedPassword = client.clientPassword;

            if (passwordIsEncrypted)
            {
                if (!password.Equals(storedPassword))
                {
                    throw new IncorrectPasswordException(clientLogin);
                }
            }
            else
            {
                if (!PasswordEncrypter.IsClearPasswordCorrect(password,
                        storedPassword))
                {
                    throw new IncorrectPasswordException(clientLogin);
                }
            }

            return new LoginResult(client.clientId, client.firstName,
                storedPassword, client.clientLanguage, client.clientAddress, client.country);
        }

        /// <exception cref="InstanceNotFoundException"/>
        [Transactional]
        public void UpdateClientDetails(long clientId,
            ClientDetails clientDetails)
        {
            Client client =
                ClientDao.Find(clientId);

            client.firstName = clientDetails.FirstName;
            client.firstSurname = clientDetails.FirstSurname;
            client.lastSurname = clientDetails.LastSurname;
            client.email = clientDetails.Email;
            client.clientLanguage = clientDetails.ClientLanguage;
            client.clientAddress = clientDetails.ClientAddress;
            client.country = clientDetails.Country;
            client.rol = clientDetails.Rol;
            ClientDao.Update(client);
        }

        public bool ClientExists(string clientLogin)
        {
            try
            {
                Client client = ClientDao.FindByLogin(clientLogin);
            }
            catch (InstanceNotFoundException)
            {
                return false;
            }

            return true;
        }

        #endregion IClientService Members
    }
}