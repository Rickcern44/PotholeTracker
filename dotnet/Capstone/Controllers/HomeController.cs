using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IPotholeDAO potholeDAO;
        public HomeController( IPotholeDAO potholeDAO)
        {
            this.potholeDAO = potholeDAO;
        }

        [HttpGet]
        public ActionResult<List<Pothole>> GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            return potholes;
        }
    }
}
