using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenGenerator tokenGenerator;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserDAO userDAO;

        public LoginController(ITokenGenerator _tokenGenerator, IPasswordHasher _passwordHasher, IUserDAO _userDAO)
        {
            tokenGenerator = _tokenGenerator;
            passwordHasher = _passwordHasher;
            userDAO = _userDAO;
        }
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult<List<ReturnUser>> GetAllUsers()
        {
            List<ReturnUser> users = userDAO.GetAllUsers();

            return users;
        }
        //[Authorize(Roles = "admin")]

        //[Authorize(Roles = "admin")]
        //[HttpPut("Update/id={id}&lastname={lastName}")]
        //public ActionResult<string> UpdateUserLastName(int id, string lastName)
        //{
        //    string message = "";
        //    message = userDAO.UpdateLastName(id, lastName);
        //    return message;
        //}
        [HttpPut("Update/{id}")]
        public ActionResult UpdateEmployee(int id, User user)
        {
            userDAO.UpdateEmployee(user);
            return Ok();
        }
        ////[Authorize(Roles = "admin")]
        //[HttpPut("Update/id={id}&email={email}")]
        //public ActionResult<string> UpdateUserEmail(int id, string email)
        //{
        //    string message = "";
        //    message = userDAO.UpdateEmail(id, email);
        //    return message;
        //}
        ////[Authorize(Roles = "admin")]
        //[HttpPut("Update/id={id}&phone={phone}")]
        //public ActionResult<string> UpdateUserPhone(int id, string phone)
        //{
        //    string message = "";
        //    message = userDAO.UpdatePhoneNumber(id, phone);
        //    return message;
        //}
        [HttpPost]
        public IActionResult Authenticate(LoginUser userParam)
        {
            // Default to bad username/password message
            IActionResult result = Unauthorized(new { message = "Username or password is incorrect" });

            // Get the user by username
            User user = userDAO.GetUser(userParam.Username);

            // If we found a user and the password hash matches
            if (user != null && passwordHasher.VerifyHashMatch(user.PasswordHash, userParam.Password, user.Salt))
            {
                // Create an authentication token
                string token = tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role);

                // Create a ReturnUser object to return to the client
                LoginResponse retUser = new LoginResponse() { User = new ReturnUser() { UserId = user.UserId, Username = user.Username, Role = user.Role, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, PhoneNumber = user.PhoneNumber }, Token = token };

                // Switch to 200 OK
                result = Ok(retUser);
            }

            return result;
        }

        [HttpPost("/register")]
        public IActionResult Register(RegisterUser userParam)
        {
            IActionResult result;

            User existingUser = userDAO.GetUser(userParam.Username);
            if (existingUser != null)
            {
                return Conflict(new { message = "Username already taken. Please choose a different username." });
            }

            User user = userDAO.AddUser(userParam.Username, userParam.Password, userParam.Role);
            if (user != null)
            {
                result = Created(user.Username, null); //values aren't read on client
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and user was not created." });
            }

            return result;
        }
    }
}
