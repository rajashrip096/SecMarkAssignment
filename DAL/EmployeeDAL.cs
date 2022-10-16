using Microsoft.Extensions.Configuration;
using SecMarkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SecMarkAssignment.DAL
{
    public class EmployeeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> emplist = new List<Employee>();
            string qry = "select * from employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.Emp_code = dr["Emp_code"].ToString();
                    emp.Emp_Name = dr["Emp_Name"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Emp_dept = dr["Emp_dept"].ToString();
                    emp.Password = dr["Password"].ToString();
                    emplist.Add(emp);
                }
            }
            con.Close();
            return emplist;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            string qry = "select * from Employee where Emp_no=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Emp_code = dr["Emp_code"].ToString();
                    emp.Emp_Name = dr["Emp_Name"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Emp_dept = dr["Emp_dept"].ToString();
                    emp.Password = dr["Password"].ToString();

                }
            }
            con.Close();
            return emp;
        }
        public Employee GetEmployeeByEmail(Employee emp)
        {
            Employee e = new Employee();
            string qry = "select * from Employee where Email=@email";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Emp_code = dr["Emp_code"].ToString();
                    emp.Emp_Name = dr["Emp_Name"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Emp_dept = dr["Emp_dept"].ToString();
                    emp.Password= dr["Password"].ToString();

                }
            }
            con.Close();
            return e;
        }
        public int AddEmployee(Employee emp)
        {
            string qry = "insert into Employee values(@emp_code,@emp_name,@email,@emp_dept,@pass)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emp_code", emp.Emp_code);
            cmd.Parameters.AddWithValue("@emp_name", emp.Emp_Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@emp_dept",emp.Emp_dept);
            cmd.Parameters.AddWithValue("@pass", emp.Password);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateEmployee(Employee emp)
        {
            string qry = "update Employee set Emp_code=@emp_code,Emp_Name=@emp_name,Email=@email, Emp_dept=@Emp_dept,Password=@pass where Emp_no=@id";
            cmd = new SqlCommand(qry, con);
           // cmd.Parameters.AddWithValue("@id", emp.Emp_no);
            cmd.Parameters.AddWithValue("@emp_code", emp.Emp_code);
            cmd.Parameters.AddWithValue("@emp_name", emp.Emp_Name);
            cmd.Parameters.AddWithValue("@email", emp.Email);
            cmd.Parameters.AddWithValue("@emp_dept", emp.Emp_dept);
            cmd.Parameters.AddWithValue("@pass", emp.Password);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteEmployee(int id)
        {
            string qry = "delete from Employee where Emp_no=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
