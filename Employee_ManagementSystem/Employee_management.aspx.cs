using Employee_ManagementSystem.Repository;
using iTextSharp.LGPLv2.Core.System.NetUtils;
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee_ManagementSystem
{
    public partial class Employee_management : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Keys.Count > 0 && Request.QueryString["CentreCode"] != null)
                {
                    hdnCentreCode.Value = Request.QueryString["CentreCode"].ToString();

                }
                GetDepartment();
                fetchAllEmployeeDetails(Convert.ToInt32(hdnCentreCode.Value));
                //int EmpID = Convert.ToInt32(Session["emp_ID"].ToString());
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
            else
            {

                EmployeeRepository.UpdateEmployeeDetails(ddlDepartment.SelectedValue, Convert.ToInt32(txtEmployeeNumber.Text), txtFirstName.Text,
                        txtMiddleName.Text, txtLastName.Text, txtEmail.Text, fileUploadPhoto, Convert.ToBoolean(rdbPrintOptions.SelectedValue)
                        , Convert.ToInt32(hdnCentreCode.Value));

                // ShowCustomAlert("SUCCESS", "Update Successfully...!", "SUCCESS");

                string script = @"
            <script type='text/javascript'>
                CustomToastrAlert('Update Successfully...!', 'SUCCESS', 'SUCCESS');
                setTimeout(function() {
                    window.location.href = 'Default.aspx';
                }, 2000); // 2000 milliseconds = 1 seconds
            </script>";

                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Redirect", script, false);
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
        public void fetchAllEmployeeDetails(int EmpID)
        {

            var dt = EmployeeRepository.fetchAllByIDEmployeeDetails(EmpID);
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
                    imgPhoto.ImageUrl = ResolveUrl(photoPath);
                    imgPhoto.Visible = true;
                }
                else
                {
                    imgPhoto.Visible = false;
                }
                ListItem item = ddlDepartment.Items.FindByValue(dr["emp_department"].ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
                rdbPrintOptions.SelectedValue = dr["emp_status"].ToString();

                System.Diagnostics.Debug.WriteLine("Photo Path: " + photoPath);
            }
        }
        protected void ShowCustomAlert(string messageType, string messageContent, string titleMessage)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CustomToastrAlert",
                       "CustomToastrAlert('" + messageContent + "','" + titleMessage + "','" + messageType + "');",
                       true);
        }
    }
}