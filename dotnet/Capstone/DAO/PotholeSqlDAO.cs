using Capstone.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
using Microsoft.CodeAnalysis;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        //Change this update to only take an id and status
        //TODO: Fix this function to be more effeciant
        public string UpdateAPothole(int status, int id)
        {
            string sqlQuery = "UPDATE Pothole SET Status = @status  WHERE Id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);     
            }
            return $"The pothole id {id} was updated to status {status}";

        }
        //Update pothole Severity 
        public string UpdatePotholeSeverity(int id, int severity)
        {
            const string sqlQuery = "UPDATE Pothole SET Severity = @severity  WHERE Id = @id";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@severity", severity);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex); 
            }
            return $"Pothole {id} has been updated to severity {severity}";
        }
        //Update Potholes assignes employee
        public string UpdateAssignedEmployee(int userId, int potholeId)
        {
            const string sqlQuery = "UPDATE Pothole SET user_id = @userId WHERE Id = @potholeId";

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@potholeId", potholeId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return $"Pothole number {potholeId} has been assigned to employee number {userId}";
        }
        //Delete
        public string DeletePothole(int id)
        {
            string sqlQuery = "DELETE FROM Pothole WHERE Id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex); ;
            }
            return $"Pothole Numer {id} was Deleted";
        }
        //The method that convert the data from sql data types to C# Objects
        private Pothole PotholeData(SqlDataReader reader)
        {
            //Location location = ParseAddress(Convert.ToString(reader["Location"]));
            ParseAddressModel addressModel = ParseAddress(Convert.ToString(reader["Location"]));
            Pothole pothole = new Pothole();

            pothole.Id = Convert.ToInt32(reader["Id"]);
            pothole.Location = Convert.ToString(reader["Location"]);
            pothole.DateAdded = Convert.ToDateTime(reader["DateAdded"]);
            pothole.Description = Convert.ToString(reader["Description"]);
            pothole.Status = (PotholeStatus)Convert.ToInt32(reader["Status"]);
            pothole.Severity = Convert.ToInt32(reader["Severity"]);
            pothole.AddressResult = addressModel;

            

            return pothole;
        }

        private ParseAddressModel ParseAddress(string address)
        {
            string API_URL = "https://maps.googleapis.com/maps/api/geocode";
            string requestString = $"/json?address={address}&key=AIzaSyAlcsTIh-EKItsXyrIWjP2N2pYDugC_6Dc";

            RestClient client = new RestClient(API_URL);
            RestRequest rest = new RestRequest(requestString, Method.GET);
            IRestResponse<ParseAddressModel> response = client.Execute<ParseAddressModel>(rest);

            return response.Data;


        }



    }
}
