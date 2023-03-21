using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentWindowsFormsApp
{
    public partial class Form1 : Form
    {
        Student student = new Student();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = student.GetStudents();
        }
        //SqlConnection conn;
        //SqlCommand cmd;
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    conn = new SqlConnection("Data Source=.;Initial Catalog=StudentDB;Integrated Security=True");
        //    cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //}

        private void insert_Click(object sender, EventArgs e)
        {
            student.Id =Convert.ToInt32(txtId.Text);
            student.Name = txtName.Text;
            student.City = txtCity.Text;
            student.Department = txtDepartment.Text;
            student.Gender = cboGender.SelectedItem.ToString();
            // Call Insert Employee method to insert the employee details to database
            var success = student.InsertStudent(student);
            // Refresh the grid to show the updated employee details
            dataGridView1.DataSource = student.GetStudents();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                clearData();
                MessageBox.Show("Sudent has been added successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");

        }
        private void clearData()
        {
            txtId.Clear();
            txtName.Clear();
            txtDepartment.Clear();
            txtCity.Clear();
            cboGender.Text = "";
        }
        //private void displaydata()
        //{
           
        //}

        private void update_Click(object sender, EventArgs e)
        {
            student.Id = Convert.ToInt32(txtId.Text);
            student.Name = txtName.Text;
            student.City = txtCity.Text;
            student.Department = txtDepartment.Text;
            student.Gender = cboGender.SelectedItem.ToString();
            // Call Insert Employee method to insert the employee details to database
            var success = student.UpdateStudent(student);
            // Refresh the grid to show the updated employee details
            dataGridView1.DataSource = student.GetStudents();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                clearData();
                MessageBox.Show("Sudent has been updated successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            student.Id = Convert.ToInt32(txtId.Text);
            var success = student.DeleteStudent(student);
            // Refresh the grid to show the updated employee details
            dataGridView1.DataSource = student.GetStudents();
            if (success)
            {
                // Clear controls once the employee is inserted successfully
                clearData();
                MessageBox.Show("Sudent has been deleted successfully");
            }
            else
                MessageBox.Show("Error occured. Please try again...");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dgvstudentDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var index = e.RowIndex;
            txtId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtCity.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtDepartment.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            cboGender.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        
    }
}
