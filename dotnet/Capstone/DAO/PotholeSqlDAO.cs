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
            const string sqlQuery = "SELECT * FROM Pothole";

            //const string testQuery = "SELECT * FROM Pothole Join PotholeStatus ps on ps.id = Pothole.id";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
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
            pothole.Status = (PotholeStatus)Convert.ToInt32(reader["Status"]);

            return pothole;
        }

    }
}
