using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentWindowsFormsApp
{
    internal class Student
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        private const string SelectQuery = "Select * from Student2";
        private const string InsertQuery = "Insert Into Student2(Id, Name, City, Department, Gender) Values (@Id, @Name, @City, @Department, @Gender)";
        private const string UpdateQuery = "Update Student2 set Name=@Name, City=@City, Department=@Department, Gender=@Gender where Id=@Id";
        private const string DeleteQuery = "Delete from Student2 where Id=@Id";

        public DataTable GetStudents()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
        public bool InsertStudent(Student student)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@Id", student.Id);
                    com.Parameters.AddWithValue("@Name", student.Name);
                    com.Parameters.AddWithValue("@City", student.City);
                    com.Parameters.AddWithValue("@Department", student.Department);
                    com.Parameters.AddWithValue("@Gender", student.Gender);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool UpdateStudent(Student student)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@Name", student.Name);
                    com.Parameters.AddWithValue("@City", student.City);
                    com.Parameters.AddWithValue("@Department", student.Department);
                    com.Parameters.AddWithValue("@Gender", student.Gender);
                    com.Parameters.AddWithValue("@Id", student.Id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool DeleteStudent(Student student)
        {
            int row = 0;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        com.Parameters.AddWithValue("@Id", student.Id);
                        row = com.ExecuteNonQuery();
                    }
                }
            }
            return (row > 0) ? true : false;
        }
    }
}
