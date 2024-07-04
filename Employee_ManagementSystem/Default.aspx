<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee_ManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href='<%= ResolveClientUrl("~/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css") %>' />
    <link rel="stylesheet" type="text/css" href='<%= ResolveClientUrl("~/assets/global/plugins/bootstrap-toastr/toastr.min.css") %>' />
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/bootstrap-toastr/toastr.min.js" )%>'></script>
    <link href="../assets/chosen.css" rel="stylesheet" type="text/css" />
    <script src='<%= ResolveUrl("~/assets/chosen.js") %>' type="text/javascript"></script>
    <script>

        // for popup
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
    <div class="jumbotron">
    </div>

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
                <asp:HiddenField runat="server" ID="hdnEmpID" />
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
                <asp:Image ID="imgPhoto" runat="server" Visible="true" />
                <asp:FileUpload ID="fileUploadPhoto" runat="server" CssClass="form-control input-sm" />
            </div>
        </div>
        <div class="col-md-3">
            <div class="form-group">
                <label>Status</label>
                <asp:RadioButtonList ID="rdbPrintOptions" runat="server" CssClass="form-control input-sm" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true">&nbsp;&nbsp;&nbsp;Active &nbsp;&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem Selected="True" Value="false">&nbsp;&nbsp;&nbsp;Inactive</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="col-md-3">
            <label>
                <br />
                <br />
            </label>
            <asp:Button ID="btnAddNew" runat="server" Text="Add New Employee"
                CssClass="btn btn-warning" OnClick="btnAddNew_Click"></asp:Button>
        </div>
    </div>
    <%-- Gridview --%>
    <div class="portlet-body">
        <div class="row">
            <div class="col-md-9">
                <div class="box box-primary">
                    <div class="box-body table-responsive">
                        <asp:GridView ID="gridSummary" CssClass="table table-bordered table-hover table-striped" ShowHeader="True"
                            runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="false" ShowFooter="false" UseAccessibleHeader="true"
                            OnRowCommand="gridSummary_RowCommand">
                            <Columns>
                               <%-- <asp:TemplateField HeaderText="Staff Signature">
                                    <ItemTemplate>
                                        <asp:Image ID="SignaturePath" runat="server" ImageUrl='<%# Eval("PhotoPath") %>' Style="width: 100%; height: auto" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:BoundField HeaderText="Emp Number" DataField="emp_number" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="First Name" DataField="emp_firstname" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Mid Name" DataField="emp_middlename" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Last Name" DataField="emp_lastname" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Email ID" DataField="emp_emailId" ItemStyle-Width="10%" />
                                <asp:BoundField HeaderText="Department" DataField="emp_department" ItemStyle-Width="20%" />
                                <asp:BoundField HeaderText="Status" DataField="emp_status" ItemStyle-Width="10%" />

                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditEmployee" CommandArgument='<%# Eval("emp_ID") %>' CssClass="btn btn-primary btn-sm" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteEmployee" CommandArgument='<%# Eval("emp_ID") %>' CssClass="btn btn-danger btn-sm" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/select2/select2.min.js" )%>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/datatables/media/js/jquery.dataTables.min.js")%>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/datatables/extensions/TableTools/js/dataTables.tableTools.min.js")%>'></script>

    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js")%>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/assets/global/plugins/jquery-validation/js/jquery.validate.min.js")%>'></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <script type="text/javascript">

        function ShowEmployeeManagementEdit(url) {
            window.open(url, 'popup_window', 'height=1600,width=1800,resizable=yes,scrollbars=yes');

        }
    </script>
    <script type="text/javascript">

        function showReportList() {
            $('#reportList').modal('show');
        }

        function pageLoad(sender, args) {

            $('.chosen').chosen();

            try {
                $('#<%= gridSummary.ClientID %>').dataTable({
                    "bPaginate": true,
                    "bLengthChange": false,
                    "bFilter": true,
                    "bInfo": true,
                    "bsort": true,
                    "bordering": true,
                    "iDisplayLength": 10,
                    "aaSorting": [],
                    "bAutoWidth": false
                });
            } catch (ex) {
                console.log(ex);
            }

        }
    </script>
</asp:Content>

