using Dapper;
using TalkService.Context;
using TalkService.Model.Account;
using TalkService.Model.Request;
using TalkService.Utility;

namespace TalkService.Repository
{
    public class AccountRepository
    {
        private readonly DbContext context;
        public AccountRepository(DbContext context)
        {
            this.context = context;
        }

        public int? CreateUser(AccountData userData)
        {
            int? userId = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", userData.UserName, System.Data.DbType.String);
            parameters.Add("@Password", userData.Password, System.Data.DbType.String);
            parameters.Add("@UserRoleId", userData.UserRoleId, System.Data.DbType.Int32);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    userId = connection?.ExecuteScalar<int>(SqlContants.InsertUser, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while creating the user: {ex.Message}");
                }
            }
            return userId;
        }

        public int? CreateProfile(AccountData profileData)
        {
            int? profileId = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FirstName", profileData.FirstName, System.Data.DbType.String);
            parameters.Add("@LastName", profileData.LastName, System.Data.DbType.String);
            parameters.Add("@Email", profileData.Email, System.Data.DbType.String);
            parameters.Add("@Bio", profileData.bio, System.Data.DbType.String);
            parameters.Add("@UserId", profileData.UserId, System.Data.DbType.Int32);
            parameters.Add("@PictureId", profileData.PictureId, System.Data.DbType.Int32);
            parameters.Add("@CreatedDate", profileData.CreatedDate, System.Data.DbType.DateTime);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    profileId = connection?.ExecuteScalar<int>(SqlContants.InsertProfile, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while creating the profile: {ex.Message}");
                }
            }
            return profileId;
        }
        public int? CreatePicture(AccountData pictuteData)
        {
            int? profileId = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Image", pictuteData.Image, System.Data.DbType.Binary);
            parameters.Add("@CreatedUserId", pictuteData.CreatedUserId, System.Data.DbType.String);
            parameters.Add("@CreatedDate", pictuteData.CreatedDate, System.Data.DbType.DateTime);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    profileId = connection?.ExecuteScalar<int>(SqlContants.InsertProfile, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while creating the profile: {ex.Message}");
                }
            }
            return profileId;
        }

        public bool IsUserNameExists(AccountData userData)
        {
            bool exists = false;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", userData.UserName, System.Data.DbType.String);
            parameters.Add("@IsActive", userData.IsActive, System.Data.DbType.Boolean);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    exists = connection?.ExecuteScalar<bool>(SqlContants.CheckUserNameAvailablity, parameters, commandType: System.Data.CommandType.StoredProcedure) ?? false;
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while checking if the username exists: {ex.Message}");
                }
            }
            return exists;
        }
        public bool IsEmailExists(string email)
        {
            bool exists = false;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email", email, System.Data.DbType.String);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    exists = connection?.ExecuteScalar<bool>(SqlContants.CheckEmailAvailablity, parameters, commandType: System.Data.CommandType.StoredProcedure) ?? false;
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while checking if the email exists: {ex.Message}");
                }
            }
            return exists;
        }
        public string? GetUserNameByEmail(string email)
        {
            string? userName = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Email", email, System.Data.DbType.String);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    userName = connection?.ExecuteScalar<string>(SqlContants.GetUserNameByEmail, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while retrieving the username by email: {ex.Message}");
                }
            }
            return userName;
        }
        public int? GetUserIdByUserName(AccountData UserData)
        {
            int? userId = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", UserData.UserName, System.Data.DbType.String);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    userId = connection?.ExecuteScalar<int>(SqlContants.GetUserIdByUserName, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while retrieving the user ID: {ex.Message}");
                }
            }
            return userId;
        }
        public bool IsPasswordMatchedByUserName(AccountData userData)
        {
            bool isMatched = false;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", userData.UserName, System.Data.DbType.String);
            parameters.Add("@Password", userData.Password, System.Data.DbType.String);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    var count = connection?.ExecuteScalar<int>(SqlContants.IsPasswordMatchedByUserName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    isMatched = count > 0;
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while checking if the password matches: {ex.Message}");
                }
            }
            return isMatched;
        }
        public Profile? GetProfileById(AccountData accountData)
        {
            Profile? profile = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProfileId", accountData.ProfileId, System.Data.DbType.Int32);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    profile = connection?.QueryFirstOrDefault<Profile>(SqlContants.GetProfileById, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while retrieving the profile: {ex.Message}");
                }
            }
            return profile;
        }
        public Profile? GetProfileByUserName(AccountData accountData)
        {
            Profile? profile = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserName", accountData.UserName, System.Data.DbType.Int32);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    profile = connection?.QueryFirstOrDefault<Profile>(SqlContants.GetProfileByUserName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while retrieving the profile: {ex.Message}");
                }
            }
            return profile;
        }
        public List<Contact> GetAllContacts()
        {
            var contacts = new List<Contact>();
            using(var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    contacts = connection?.Query<Contact>(SqlContants.GetAllContacts, commandType: System.Data.CommandType.StoredProcedure).ToList() ?? new List<Contact>();
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while retrieving contacts: {ex.Message}");
                }
            }
            return contacts;
        }
        public Profile? UpdateProfile(AccountData profileData)
        {
            Profile? updatedProfile = null;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProfileId", profileData.ProfileId, System.Data.DbType.Int32);
            parameters.Add("@FirstName", profileData.FirstName, System.Data.DbType.String);
            parameters.Add("@LastName", profileData.LastName, System.Data.DbType.String);
            parameters.Add("@Email", profileData.Email, System.Data.DbType.String);
            parameters.Add("@Bio", profileData.bio, System.Data.DbType.String);
            parameters.Add("@UserId", profileData.UserId, System.Data.DbType.Int32);
            parameters.Add("@PictureId", profileData.PictureId, System.Data.DbType.Int32);
            parameters.Add("@ModifiedDate", profileData.ModifiedDate, System.Data.DbType.DateTime);
            parameters.Add("@IsActive", profileData.IsActive, System.Data.DbType.Boolean);
            using (var connection = context.GetConnection())
            {
                try
                {
                    connection?.Open();
                    updatedProfile = connection?.QueryFirstOrDefault<Profile>(SqlContants.UpdateProfile, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine($"An error occurred while updating the profile: {ex.Message}");
                }
            }
            return updatedProfile;
        }
    }
}
