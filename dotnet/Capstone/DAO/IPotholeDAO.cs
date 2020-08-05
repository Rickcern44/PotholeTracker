using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPotholeDAO
    {
        List<Pothole> GetAllPotholes();
        Pothole ReportApothole(Pothole pothole);
        Pothole UpdateAPothole(Pothole pothole,int status, int id);
    }
}