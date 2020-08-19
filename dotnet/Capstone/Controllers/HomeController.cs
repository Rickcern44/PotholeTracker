using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IPotholeDAO potholeDAO;
        public HomeController(IPotholeDAO potholeDAO)
        {
            this.potholeDAO = potholeDAO;
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<Pothole>> GetAllPotholes()
        {
            List<Pothole> potholes = potholeDAO.GetAllPotholes();
            return potholes;

        }
        //TODO 1: Find a way to test this method
        [AllowAnonymous]
        [HttpPost("Report")]
        public ActionResult ReportPothole(Pothole pothole)
        {
            //Create an array to hold the address
            string[] addressSplit;
            //Split the address
            addressSplit = pothole.Location.Split(" ");
            //Check the array to make sure the info is in the format that is wanted
            if (addressSplit[0] == "" || addressSplit[1] == "" || addressSplit[2] == "" || addressSplit[3] == "" || addressSplit[4] == "" || addressSplit[5] == "" || pothole.Description == "")
            {
                return Forbid();
            }
            else
            {
                Pothole pothole1 = potholeDAO.ReportApothole(pothole);
                return Ok();
            }
        }

    }
}
