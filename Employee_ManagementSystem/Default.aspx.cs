using Employee_ManagementSystem.Repository;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_ManagementSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDepartment();
                getStudentDetails();
            }

        }
        public void getStudentDetails()
        {
            var studentdetails = EmployeeRepository.GetEmployees();
            gridSummary.DataSource = studentdetails;
            gridSummary.DataBind();


        }

        public void fetchAllEmployeeDetails(int EmpID)
        {
            //int EmpID = hdnEmpID.Value == "" ? 0 :  Convert.ToInt32(hdnEmpID.Value);
            var dt = EmployeeRepository.fetchAllEmployeeDetails(EmpID);
            if (dt.Rows.Count > 0)
            {
                var dr = dt.Rows[0];
                txtEmployeeNumber.Text = dr["emp_number"].ToString();
                txtFirstName.Text = dr["emp_firstname"].ToString();
                txtMiddleName.Text = dr["emp_middlename"].ToString();
                txtLastName.Text = dr["emp_lastname"].ToString();
                txtEmail.Text = dr["emp_emailId"].ToString();
                string photoPath = dr["PhotoPath"].ToString();
                if (!string.IsNullOrEmpty(photoPath))
                {
                    imgPhoto.ImageUrl = photoPath;
                    imgPhoto.Visible = true;
                }
                else
                {
                    imgPhoto.Visible = false;
                } 
                string imageUrl1 = dt.Rows[0]["ReAssign_Image"].ToString();
                string filename = Path.GetFileName(imageUrl1); 
                string imageUrl = "~/Uploads/" + filename; 
                imgPhoto.ImageUrl = imageUrl;
                 
                rdbPrintOptions.Text = dr["emp_status"].ToString();
                ddlDepartment.SelectedValue = dr["emp_department"].ToString();
                //WebUtils.SetSelectedItem(dr["DepartmentId"].ToString(), ddlDepartment);

            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please select Department...!','ERROR','ERROR');",
                   true);
                ddlDepartment.Focus();
                return;
            }
            if (txtEmployeeNumber.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please Enter Employee Number...!','ERROR','ERROR');",
                   true);
                txtEmployeeNumber.Focus();
                return;
            }
            if (txtFirstName.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please enter First Name...!','ERROR','ERROR');",
                   true);
                txtFirstName.Focus();
                return;
            }
            if (txtMiddleName.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please enter First Name...!','ERROR','ERROR');",
                   true);
                txtMiddleName.Focus();
                return;
            }
            if (txtLastName.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please enter First Name...!','ERROR','ERROR');",
                   true);
                txtLastName.Focus();
                return;
            }
            if (txtFirstName.Text.Trim() == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please enter First Name...!','ERROR','ERROR');",
                   true);
                txtFirstName.Focus();
                return;
            }
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                    "CustomToastrAlert",
                    "CustomToastrAlert('Enter a valid email address!','Error while saving','ERROR');",
                    true);

                return;
            }
            if (!fileUploadPhoto.HasFile)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please upload a photo!','ERROR','ERROR');",
                   true);
                fileUploadPhoto.Focus();
                return;
            }
            if (rdbPrintOptions.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),
                   "CustomToastrAlert",
                   "CustomToastrAlert('Please select Active or Inactive status!','ERROR','ERROR');",
                   true);
                rdbPrintOptions.Focus();
                return;
            }
            else
            {

                EmployeeRepository.SaveEmployeeDetails(ddlDepartment.SelectedValue, Convert.ToInt32(txtEmployeeNumber.Text), txtFirstName.Text,
                        txtMiddleName.Text, txtLastName.Text, txtEmail.Text, fileUploadPhoto, Convert.ToBoolean(rdbPrintOptions.SelectedValue));

                getStudentDetails();
                ShowCustomAlert("SUCCESS", "Create Employee ID Successfully...!", "SUCCESS");
            }
        }
        public void GetDepartment()
        {
            var dt = EmployeeRepository.fetchDepartment();
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select-", ""));
        }

        protected void gridSummary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                int employeeNumber = Convert.ToInt32(e.CommandArgument);
                Session["emp_ID"] = employeeNumber;

                //string url = "../Employee_management.aspx?CentreCode=" + employeeNumber.ToString();

                var url = "../Employee_management.aspx?CentreCode=" + e.CommandArgument;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ShowEmployeeManagementEdit", "ShowEmployeeManagementEdit('" + url + "')", true);
            }
            else if (e.CommandName == "DeleteEmployee")
            {
                int employeeNumber = Convert.ToInt32(e.CommandArgument);

                Session["emp_ID"] = employeeNumber;

                DeleteEmployee(employeeNumber);
            }
        }
        private void DeleteEmployee(int EmployeeID)
        {
            EmployeeRepository.DeleteEmployeeDetailsById(EmployeeID);

            getStudentDetails();

            ShowCustomAlert("ERROR", "Employee details deleted successfully!", "Employee Details");

        }
        protected void ShowCustomAlert(string messageType, string messageContent, string titleMessage)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CustomToastrAlert",
                       "CustomToastrAlert('" + messageContent + "','" + titleMessage + "','" + messageType + "');",
                       true);
        }
    }
}