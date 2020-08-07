﻿using System;
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

        [HttpGet("Employee")]
        public ActionResult<List<Pothole>> GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            return potholes;
        }
        [HttpPut("Update")]
        public ActionResult<Pothole> UpdateAPothole(Pothole pothole, int status, int id)
        {
            Pothole updatedPothole = potholeDAO.UpdateAPothole(pothole, status, id);
            return updatedPothole;
        }
        [HttpPut("Severity/{id}/{severity}")]
        public ActionResult<string> UpdateSeverity(int id, string severity)
        {
            int severityNumber = int.Parse(severity);
            string message = "";
            return message = potholeDAO.UpdatePotholeSeverity(id, severityNumber);
        }
        [HttpDelete("Pothole/{id}")]
        public ActionResult<string> DeletePothole(int id)
        {
            string message = "";
            return message = potholeDAO.DeletePothole(id);
        }
        [HttpPut("Assign/{userId}/{potholeId}")]
        public ActionResult<string> AssignEmployee(int userId, int potholeId)
        {
            string message = "";
            return message = potholeDAO.UpdateAssignedEmployee(userId, potholeId);
        }
    }
}
