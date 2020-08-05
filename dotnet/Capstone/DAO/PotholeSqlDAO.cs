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
        public Pothole ReportApothole(Pothole pothole)
        {
            //TODO: Fix the format of the date time
            pothole.Status = (PotholeStatus)1;
            pothole.DateAdded = DateTime.Now;
            string sqlQuery = "INSERT INTO Pothole([Location], DateAdded, [Description], Status) VALUES(@location, @dateAdded, @description, @status) SELECT @@IDENTITY";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    //Add all the params
                    cmd.Parameters.AddWithValue("@location", pothole.Location);
                    //cmd.Parameters.AddWithValue("@dateAdded", pothole.DateAdded);
                    cmd.Parameters.AddWithValue("@dateAdded", pothole.DateAdded);
                    cmd.Parameters.AddWithValue("@description", pothole.Description);
                    cmd.Parameters.AddWithValue("@status", pothole.Status);

                    pothole.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return pothole;
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
