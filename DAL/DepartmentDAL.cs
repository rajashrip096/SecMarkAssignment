using Microsoft.Extensions.Configuration;
using SecMarkAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SecMarkAssignment.DAL
{
    public class DepartmentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public DepartmentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Department> GetAllDepartment()
        {
            List<Department> deptlist = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    
                    dept.dept_code = dr["dept_code"].ToString();
                    dept.dept_name = dr["dept_name"].ToString();

                    deptlist.Add(dept);
                }
            }
            con.Close();
            return deptlist;
        }
        public Department GetDepartmentById(int dept_code)
        {
          Department dept = new Department();
            string qry = "select * from Department where dept_code=@dept_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", dept_code);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.dept_code = dr["dept_code"].ToString();
                    dept.dept_name = dr["dept_name"].ToString();
                   
                }
            }
            con.Close();
            return dept;
        }

        public int AddDepartment(Department dept)
        {
            string qry = "insert into Department values(@dept_code,@dept_name)";
            cmd = new SqlCommand(qry, con);
            
            cmd.Parameters.AddWithValue("@dept_code", dept.dept_code);
            cmd.Parameters.AddWithValue("@dept_name", dept.dept_name);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateDepartment(Department dept)
        {
            string qry = "update Department set dept_name=@dept_name where dept_code=@dept_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", dept.dept_code);
            cmd.Parameters.AddWithValue("@dept_name", dept.dept_name);
            
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteDepartment(int dept_code)
        {
            string qry = "delete from Department where dept_code=@dept_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", dept_code);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
