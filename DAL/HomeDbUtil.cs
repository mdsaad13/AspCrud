using AspCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<StudentDetails> GetAllStudents()
        {
            DataTable td = new DataTable();
            List<StudentDetails> list = new List<StudentDetails>();
            try
            {
                string sqlquery = "SELECT * FROM Student ORDER BY Id DESC";
                SqlCommand cmd = new SqlCommand(sqlquery, Conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Conn.Open();
                adp.Fill(td);
                foreach (DataRow row in td.Rows)
                {
                    StudentDetails obj = new StudentDetails();
                    obj.ID = Convert.ToInt32(row["Id"]);
                    obj.Name = Convert.ToString(row["Name"]);
                    obj.Department = Convert.ToString(row["Department"]);
                    list.Add(obj);
                }
            }
            catch (Exception)
            { }
            finally
            {
                Conn.Close();
            }
            return list;
        }

        internal StudentDetails GetStudentByID(int id)
        {

            DataTable td = new DataTable();
            StudentDetails obj = new StudentDetails();
            try
            {
                string sqlquery = "SELECT * FROM Student where Id = @id";
                SqlCommand cmd = new SqlCommand(sqlquery, Conn);
                cmd.Parameters.Add(new SqlParameter("id", id));
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Conn.Open();
                adp.Fill(td);

                obj.ID = Convert.ToInt32(td.Rows[0]["Id"]);
                obj.Name = Convert.ToString(td.Rows[0]["Name"]);
                obj.Department = Convert.ToString(td.Rows[0]["Department"]);

            }
            catch (Exception)
            { }
            finally
            {
                Conn.Close();
            }
            return obj;

        }
        
        internal int EditStud(StudentDetails model)
        {
            int rows = 0;
            try
            {
                string query = "UPDATE Student SET Name= @name, Department = @dept where Id = @id";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.Add(new SqlParameter("@name", model.Name));
                cmd.Parameters.Add(new SqlParameter("@dept", model.Department));
                cmd.Parameters.Add(new SqlParameter("@id", model.ID));
                Conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return rows;
        }

        internal int Delete(int id)
        {
            int rows = 0;
            try
            {
                string query = "DELETE from Student where Id = @id";
                SqlCommand cmd = new SqlCommand(query, Conn);
                cmd.Parameters.Add(new SqlParameter("@id", id));
                Conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conn.Close();
            }
            return rows;
        }
    }
}