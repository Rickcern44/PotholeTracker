using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PotholeSqlDAO : IPotholeDAO
    {
        
        private string connectionString;

        public PotholeSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Pothole> GetAllPotholes()
        {
            List<Pothole> potholes = new List<Pothole>();
            const string sqlQuery = "select pothole.id, [Location], DateAdded, [Description], ph.InProgress, ph.Repaired, ph.Reported  from Pothole" +
                                    "join PotholeStatus as ph on Pothole.id = ph.Id ";
            const string testQuery = "SELECT * FROM Pothole";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(testQuery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        potholes.Add(PotholeData(reader));
                    }
                }
            }
            catch
            {

            }
            return potholes;
        }
        //The method that convert the data from sql data types to C# Objects
        private Pothole PotholeData(SqlDataReader reader)
        {
            Pothole pothole = new Pothole();

            pothole.Id = Convert.ToInt32(reader["Id"]);
            pothole.Location = Convert.ToString(reader["Location"]);
            pothole.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
            pothole.Description = Convert.ToString(reader["Description"]);
            pothole.Status.Reported = Convert.ToBoolean(reader["Reported"]);
            pothole.Status.InProgress = Convert.ToBoolean(reader["InProgress"]);
            pothole.Status.Repaired = Convert.ToBoolean(reader["Repaired"]);

            return pothole;
        }

    }
}
