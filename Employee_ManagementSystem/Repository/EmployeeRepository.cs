using Employee_ManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace Employee_ManagementSystem.Repository
{
    public class EmployeeRepository
    {
        public static DataTable GetEmployees()
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[1];
            param[0] = new SqlParameter("@optype", "GetEmployeesDetails");

            var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            if (outputDs.Tables.Count > 0)
                return outputDs.Tables[0];
            else
                return new DataTable();
        }

        public static DataTable fetchDepartment()
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[1];
            param[0] = new SqlParameter("@optype", "Get_Department");

            var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);
            if (outputDs.Tables.Count > 0)
                return outputDs.Tables[0];
            else
            {
                return new DataTable();
            }
        }
        public static DataTable fetchAllByIDEmployeeDetails(int emp_ID)
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[2];
            param[0] = new SqlParameter("@optype", "GetByID_EmployeesDetails");
            param[1] = new SqlParameter("@emp_ID", emp_ID);

            var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            if (outputDs.Tables.Count > 0)
                return outputDs.Tables[0];
            else
                return new DataTable();
        }
        public static DataTable fetchAllEmployeeDetails(int emp_ID)
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[2];
            param[0] = new SqlParameter("@optype", "GetEmployeesDetails"); 
            param[1] = new SqlParameter("@emp_ID", emp_ID); 

             var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            if (outputDs.Tables.Count > 0)
                return outputDs.Tables[0];
            else
                return new DataTable();
        }
        public static DataTable DeleteEmployeeDetailsById(int emp_ID)
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[2];
            param[0] = new SqlParameter("@optype", "DeleteEmployeesDetailByID");
            param[1] = new SqlParameter("@emp_ID", emp_ID);

            var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            if (outputDs.Tables.Count > 0)
                return outputDs.Tables[0];
            else
                return new DataTable();
        }
        public static DataSet SaveEmployeeDetails(string department, int employeeNumber, string firstName, string middleName, string lastName,
            string email,  FileUpload photo, bool printOptions)
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[10];

            // Save photo if it exists
            string photoPath = null;
            if (photo.HasFile)
            {
                string filename = Path.GetFileName(photo.FileName);
                string directoryPath = HttpContext.Current.Server.MapPath("~/Uploads/");

                // Ensure the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                photoPath = Path.Combine(directoryPath, filename);
                photo.SaveAs(photoPath);
            }
            param[0] = new SqlParameter("@optype", "Get_SaveEmployeeDetails");
            param[2] = new SqlParameter("@emp_number", employeeNumber);
            param[3] = new SqlParameter("@emp_firstname", firstName);
            param[4] = new SqlParameter("@emp_middlename", middleName);
            param[5] = new SqlParameter("@emp_lastname", lastName);
            param[6] = new SqlParameter("@emp_department", department);
            param[7] = new SqlParameter("@emp_status", printOptions);
            param[8] = new SqlParameter("@emp_emailId", email);
            param[9] = new SqlParameter("@PhotoPath", photoPath); 

             // var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);
             DataSet outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            return outputDs;
        }
        public static DataSet UpdateEmployeeDetails(string department, int employeeNumber, string firstName, string middleName, string lastName,
         string email, FileUpload photo, bool printOptions, int emp_ID)
        {
            var dac = new SqlAccess();
            var param = new SqlParameter[10];

            // Save photo if it exists
            string photoPath = null;
            if (photo.HasFile)
            {
                string filename = Path.GetFileName(photo.FileName);
                string directoryPath = HttpContext.Current.Server.MapPath("~/Uploads/");

                // Ensure the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                photoPath = Path.Combine(directoryPath, filename);
                photo.SaveAs(photoPath);
            }
            param[0] = new SqlParameter("@optype", "Get_SaveEmployeeDetails");
            param[1] = new SqlParameter("@emp_ID", emp_ID);
            param[2] = new SqlParameter("@emp_number", employeeNumber);
            param[3] = new SqlParameter("@emp_firstname", firstName);
            param[4] = new SqlParameter("@emp_middlename", middleName);
            param[5] = new SqlParameter("@emp_lastname", lastName);
            param[6] = new SqlParameter("@emp_department", department);
            param[7] = new SqlParameter("@emp_status", printOptions);
            param[8] = new SqlParameter("@emp_emailId", email);
            param[9] = new SqlParameter("@PhotoPath", photoPath);

            // var outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);
            DataSet outputDs = dac.GenericProcedureExecutionWithParameters("usp_SaveEmployeeDetails", param);

            return outputDs;
        }
    }
}