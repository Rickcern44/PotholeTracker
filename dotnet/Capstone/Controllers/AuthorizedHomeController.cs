using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Capstone.Controllers
{
    //[Authorize]
    [Route("/")]
    [ApiController]
    public class AuthorizedHomeController : ControllerBase
    {
        private IPotholeDAO potholeDAO;
        public AuthorizedHomeController(IPotholeDAO potholeDAO)
        {
            this.potholeDAO = potholeDAO;
        }
        //[Authorize(Roles = "user, admin")]
        [HttpGet("Employee")]
        public ActionResult<List<Pothole>> GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            return potholes;
        }
        //[Authorize(Roles = "user, admin")]
        [HttpPut("Update/{id}/{status}")]
        public ActionResult<string> UpdateAPothole(int id, string status)
        {
            int statusNumber = int.Parse(status);
            string message = "";
            return message = potholeDAO.UpdateAPothole(statusNumber, id);
        }
        //[Authorize(Roles = "user, admin")]
        [HttpPut("Severity/{id}/{severity}")]
        public ActionResult<string> UpdateSeverity(int id, string severity)
        {
            int severityNumber = int.Parse(severity);
            string message = "";
            return message = potholeDAO.UpdatePotholeSeverity(id, severityNumber);
        }
        //[Authorize(Roles = "admin")]
        [HttpDelete("Pothole/{id}")]
        public ActionResult<string> DeletePothole(int id)
        {
            string message = "";
            return message = potholeDAO.DeletePothole(id);
        }
        //[Authorize(Roles = "admin")]
        [HttpPut("Assign/{userId}/{potholeId}")]
        public ActionResult<string> AssignEmployee(int userId, int potholeId)
        {
            string message = "";
            return message = potholeDAO.UpdateAssignedEmployee(userId, potholeId);
        }
    }
}
