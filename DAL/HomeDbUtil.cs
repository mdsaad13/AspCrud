using AspCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspCrud.DAL
{
    public class HomeDbUtil
    {
        /*
         * Conn = connection string of database `Login`
         */
        SqlConnection Conn = new SqlConnection("Data Source=localhost;Initial Catalog=AspCrud;Integrated Security=True");
        public int CreateStudent(StudentDetails student)
        {
            int rows = 0;
            try
            {
                /*
                 * Creating a SQL prepared statement
                 */
                string query = "INSERT INTO Student(Name,Department)" +
                        " VALUES(@name,@dept)";
                SqlCommand cmd = new SqlCommand(query, Conn);

                /*
                 * Binding the SQL prepared statement with values
                 */
                cmd.Parameters.Add(new SqlParameter("name", student.Name));
                cmd.Parameters.Add(new SqlParameter("dept", student.Department));

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
    }
}