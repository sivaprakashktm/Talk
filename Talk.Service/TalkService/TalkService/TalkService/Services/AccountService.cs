using TalkService.Model.Account;
using TalkService.Model.Request;
using TalkService.Repository;

namespace TalkService.Services
{
    public class AccountService
    {
        #region Private Fields
        private readonly AccountRepository accountRepository;
        #endregion

        #region Constructor
        public AccountService(AccountRepository accountRepository) 
        {
            this.accountRepository = accountRepository;
        }
        #endregion

        #region Public Methods
        public int? Register(Model.Request.AccountData registerRequest)
        {
            DateTime currentDateTime = DateTime.UtcNow;
            
            ValidateRegisterRequest(registerRequest);

            var userId = accountRepository.CreateUser(registerRequest);
            if (userId == null)
            {
                throw new Exception("Unable to create user");
            }
            registerRequest.UserId = userId;
            registerRequest.CreatedUserId = userId;
            registerRequest.CreatedDate = currentDateTime;
            int? pictureId = null;
            if (registerRequest.Image?.Length > 0)
            {
                 pictureId = accountRepository.CreatePicture(registerRequest);
            }
            var profileId = accountRepository.CreateProfile(registerRequest);
            return profileId;
        }
        public Profile? Login(AccountData loginData)
        {
            if (string.IsNullOrEmpty(loginData.UserName) || string.IsNullOrEmpty(loginData.Password))
            {
                throw new Exception("UserName and Password are required");
            }
            loginData.IsActive = true;
            bool isValidUser = accountRepository.IsUserNameExists(loginData);
            if (!isValidUser)
            {
                throw new Exception("UserName does not exists");
            }
            if (String.IsNullOrEmpty(loginData.UserName) && !String.IsNullOrEmpty(loginData.Email))
            {
                loginData.UserName = accountRepository.GetUserNameByEmail(loginData.Email);
                if (String.IsNullOrEmpty(loginData.UserName))
                {
                    throw new Exception("Email does not exists");
                }
            }
            if (!accountRepository.IsPasswordMatchedByUserName(loginData))
            {
                throw new Exception("Invalid password");
            }
            var profile = accountRepository.GetProfileByUserName(loginData);
            return profile;
        }

        public Profile? GetProfileById(AccountData profileData)
        {
            var profile = accountRepository.GetProfileById(profileData);
            return profile;
        }
        public List<Contact> GetAllContacts()
        {
            var contacts = accountRepository.GetAllContacts();
            return contacts;
        }
        #endregion

        #region Private Methods
        #region Validation
        private void ValidateRegisterRequest(Model.Request.AccountData registerRequest)
        {
            if (string.IsNullOrEmpty(registerRequest.Email))
            {
                throw new Exception("Email is required");
            }
            if (string.IsNullOrEmpty(registerRequest.UserName))
            {
                throw new Exception("UserName is required");
            }
            if (string.IsNullOrEmpty(registerRequest.Password))
            {
                throw new Exception("Password is required");
            }
            if (string.IsNullOrEmpty(registerRequest.FirstName))
            {
                throw new Exception("FirstName is required");
            }
            if (string.IsNullOrEmpty(registerRequest.LastName))
            {
                throw new Exception("LastName is required");
            }
            if (accountRepository.IsUserNameExists(registerRequest))
            {
                throw new Exception("UserName already taken");
            }
            if (accountRepository.IsEmailExists(registerRequest.Email))
            {
                throw new Exception("Email already in use");
            }
        }
        
        #endregion
        #endregion
    }
}
