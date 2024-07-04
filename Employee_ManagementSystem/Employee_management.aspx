<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Employee_management.aspx.cs" Inherits="Employee_ManagementSystem.Employee_management" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href='<%= ResolveClientUrl("~/assets/global/plugins/bootstrap-toastr/toastr.min.css") %>' />
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/bootstrap-toastr/toastr.min.js" )%>'></script>
    <link rel="stylesheet" type="text/css" href='<%= ResolveClientUrl("~/assets/global/plugins/select2/select2.css") %>' />
    <link rel="stylesheet" type="text/css" href='<%= ResolveClientUrl("~/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css") %>' />
 
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" />
    <link href="../assets/chosen.css" rel="stylesheet" type="text/css" />
    <script src='<%= ResolveUrl("~/assets/chosen.js") %>' type="text/javascript"></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/select2/select2.min.js")%>'></script>
    <!-- END PAGE LEVEL STYLES -->
    <script>
        function showCustomAlert() {
            $('#customAlert').modal('show');
        }

        function CustomToastrAlert(message1, message2, type) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
            if (type == 'SUCCESS')
                toastr.success(message1, message2);
            else if (type == 'ERROR')
                toastr.error(message1, message2);
        }
    </script>
    <div class="page-toolbar">
        <asp:HiddenField ID="hdnCentreCode" runat="server" />
    </div>
    <label>
        <br />
        <br />
        <br />
        <br />
    </label>
    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <label>Department</label>
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control input-sm">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Employee Number</label>
                <asp:TextBox ID="txtEmployeeNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Middle Name</label>
                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Upload Photo</label>
                <asp:Image ID="imgPhoto" runat="server" Visible="true" CssClass="employee-photo" /> 
                <asp:FileUpload ID="fileUploadPhoto" runat="server" CssClass="form-control input-sm" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Status</label>
                <asp:RadioButtonList ID="rdbPrintOptions" runat="server" CssClass="form-control input-sm" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="true">&nbsp;&nbsp;&nbsp;Active &nbsp;&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Value="false">&nbsp;&nbsp;&nbsp;Inactive</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="col-md-3">
            <label>
                <br />
                <br />
            </label>
            <asp:Button ID="btnAddNew" runat="server" Text="Update"
                CssClass="btn btn-success" OnClick="btnAddNew_Click"></asp:Button>
        </div>
    </div>

</asp:Content>
