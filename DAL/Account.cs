using AspCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspCrud.DAL
{
    public class Account
    {
        /*
         * Conn = connection string of database `Login`
         */
        SqlConnection Conn = new SqlConnection("Data Source=localhost;Initial Catalog=AspCrud;Integrated Security=True");

        public int CreateAccount(UserInfo user)
        {
            int rows = 0;
            try
            {
                /*
                 * Creating a SQL prepared statement
                 */
                string query = "INSERT INTO Users(Name,Email,Password)" +
                        " VALUES(@name,@email,@password)";
                SqlCommand cmd = new SqlCommand(query, Conn);

                /*
                 * Binding the SQL prepared statement with values
                 */
                cmd.Parameters.Add(new SqlParameter("name", user.Name));
                cmd.Parameters.Add(new SqlParameter("email", user.Email));
                cmd.Parameters.Add(new SqlParameter("password", user.Passwd));

                /*
                 * Opening sql connection
                 */
                Conn.Open();

                /*
                 * @return rows = number of rows affected
                 */
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {

            }
            finally
            {
                /*
                 * Closing sql connection
                 */
                Conn.Close();
            }
            return rows;
        }

        public UserInfo Login(string Email, string password)
        {
            /*
             * Creating object of modal UserInfo to store return values
             */
            UserInfo returnobj = new UserInfo();

            /*
             * Setting variable `ID` to 0
             * 
             * If user exist then `ID` will be that perticular users `ID` 
             */
            returnobj.ID = 0;
            try
            {
                /*
                 * Creating a SQL prepared statement
                 */
                string query = "select * from Users where Email=@email and Password=@password";
                SqlCommand cmd = new SqlCommand(query, Conn);

                /*
                 * Binding the SQL prepared statement with values
                 */
                cmd.Parameters.Add(new SqlParameter("email", Email));
                cmd.Parameters.Add(new SqlParameter("password", password));

                /*
                 * Creating object of SqlDataAdapter
                 * Used to retrieve data
                 */
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                /*
                 * Creating object of DataTable
                 * Used to store retrieved data in tabular format
                 */
                DataTable dt = new DataTable();

                /*
                 * Storing the `SqlDataAdapter` data into `DataTable`
                 */
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    returnobj.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    returnobj.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    returnobj.Email = Convert.ToString(dt.Rows[0]["Email"]);
                }
            }
            catch (Exception ex)
            {
            }
            return returnobj;

        }
    }
}