using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Transactions;
using Ninject;
using Es.Udc.DotNet.PracticaMad.Model.DAOs.ClientDao

namespace Es.Udc.DotNet.PracticaMad.Model.Services.ClientService
{
    public class ClientService : IClientService
    {
        [Inject]
        public IClientDao ClientDao { private get; set; }

        /// <exception cref="DuplicateInstanceException"/>
        [Transactional]
        public long RegisterUser(string clientLogin, string clearPassword,
        ClientDetails clientDetails)
        {
            try
            {
                UserProfileDao.FindByLoginName(clientLogin);

                throw new DuplicateInstanceException(clientLogin,
                    typeof(UserProfile).FullName);
            }
            catch (InstanceNotFoundException)
            {
                String encryptedPassword = PasswordEncrypter.Crypt(clearPassword);

                UserProfile userProfile = new UserProfile();

                userProfile.clientLogin = clientLogin;
                userProfile.enPassword = encryptedPassword;
                userProfile.firstName = clientDetails.FirstName;
                userProfile.lastName = clientDetails.Lastname;
                userProfile.email = clientDetails.Email;
                userProfile.language = clientDetails.Language;
                userProfile.country = clientDetails.ClientAddress;

                UserProfileDao.Create(userProfile);

                return userProfile.usrId;
            }
        }
    }
}