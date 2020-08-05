using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Authorize]
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

    }
}
