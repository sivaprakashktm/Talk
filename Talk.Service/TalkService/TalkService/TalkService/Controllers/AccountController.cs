using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalkService.Model.Account;
using TalkService.Model.Request;
using TalkService.Model.Response;
using TalkService.Services;

namespace TalkService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Provate Fields
        private AccountService accountService;
        #endregion
        #region Constructor
        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }
        #endregion

        #region Actions
        [HttpPost("register")]
        public ResponseDetail<int?> Register(AccountData registerRequest)
        {
            ResponseDetail<int?> response = new();
            try
            {
                response.Data = accountService.Register(registerRequest);
                response.TalkStatusCode = 200;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured";
                response.Eception = ex.Message;
            }
            return response;
        }
        [HttpPost("login")]
        public ResponseDetail<Profile> Login(AccountData loginRequest)
        {
            ResponseDetail<Profile> response = new();
            try
            {
                response.Data = accountService.Login(loginRequest);
                response.TalkStatusCode = 200;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured";
                response.Eception = ex.Message;
            }
            return response;
        }

        [HttpPost("GetProfileById")]
        public ResponseDetail<Profile> GetProfileById(AccountData accountData)
        {
            ResponseDetail<Profile> response = new();

            try
            {
                response.Data = accountService.GetProfileById(accountData);
                response.TalkStatusCode = 200;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured";
                response.Eception = ex.Message;
            }
            return response;
        }
        [HttpPost("UpdateProfile")]
        public ResponseDetail<Profile> UpdateProfile(AccountData accountData)
        {
            ResponseDetail<Profile> response = new();
            try
            {
                //response.Data = accountService.UpdateProfile(AccountData);
                response.TalkStatusCode = 200;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured";
                response.Eception = ex.Message;
            }
            return response;
        }
        [HttpGet("GetAllContacts")]
        public ResponseDetailList<Contact> GetAllContacts()
        {
            ResponseDetailList<Contact> response = new();
            try
            {
                response.Data = accountService.GetAllContacts();
                response.TalkStatusCode = 200;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured";
                response.Eception = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
