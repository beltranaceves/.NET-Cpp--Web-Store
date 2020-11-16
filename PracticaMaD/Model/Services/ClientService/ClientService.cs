using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao;
using Es.Udc.DotNet.PracticaMad.Model.Services.Common;

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    public class ClientService : IClientService
    {
        [Inject]
        public IClientDao ClientDao { private get; set; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long RegisterClient(string clientLogin, string clearPassword,
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
                string encryptedPassword = PasswordEncrypter.Crypt(clearPassword);

                Client client = new Client();

                client.clientLogin = clientLogin;
                client.clientPassword = encryptedPassword;
                client.clientName = clientDetails.ClientName;
                client.firstName = clientDetails.FirstName;
                client.lastName = clientDetails.Lastname;
                client.email = clientDetails.Email;
                client.clientLanguage = clientDetails.ClientLanguage;
                client.clientAddress = clientDetails.ClientAddress;

                ClientDao.Create(client);

                return client.clientId;
            }
        }
    }
}