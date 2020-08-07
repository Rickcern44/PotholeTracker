using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPotholeDAO
    {
        string DeletePothole(int id);
        List<Pothole> GetAllPotholes();
        Pothole ReportApothole(Pothole pothole);
        string UpdateAPothole(int status, int id);
        string UpdateAssignedEmployee(int userId, int potholeId);
        string UpdatePotholeSeverity(int id, int severity);
    }
}