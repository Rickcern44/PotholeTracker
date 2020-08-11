using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role);
        List<ReturnUser> GetAllUsers();
        string UpdateFirstName(int id, string firstName);
        string UpdateLastName(int id, string lastName);
        string UpdateEmail(int id, string email);
        string UpdatePhoneNumber(int id, string phone);
    }
}
