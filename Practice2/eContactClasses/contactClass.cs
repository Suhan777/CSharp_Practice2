using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.eContactClasses
{
    class contactClass
    {

        // getter + setters

        public int ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNum { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string dbstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        


        //selecting data

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(dbstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql1 = "SELECT * FROM people";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Close();
            }
            return dt;

        }

        //inserting data 

        public bool Insert(contactClass c)
        {
            

            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(dbstrng);

            try
            {
                string sql = "INSERT INTO people (FirstName, LastName, ContactNo, Address, Gender) VALUES (@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNum);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }

            return isSuccess;
        }

        //updating data

        public bool Update(contactClass c)
        {

            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(dbstrng);
            // MySqlConnection conn2 = new MySqlConnection(dbstrng); //need to connect to MySQL 

            try
            {
                string sql = "UPDATE people SET FirstName=FirstName@, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNum);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }

            return isSuccess;
        }

        //delete data

        public bool Delete(contactClass c)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(dbstrng);

            try
            {

                string sql = "DELETE FROM people WHERE ContactID=@ContactID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }





            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                conn.Close();
            }

            return isSuccess;

        }



    }
}
