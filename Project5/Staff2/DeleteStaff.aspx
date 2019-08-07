<%@ Page Title="Delete Staff" Language="C#" MasterPageFile="~/MasterStaff2.Master" AutoEventWireup="true" CodeFile="DeleteStaff.aspx.cs" Inherits="Staff2_DeleteStaff" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff II Services</h2>
    <h3>Delete Staff</h3>
    Deletes staff from the Staff.xml & its associated Web.config file.
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="StaffName" CssClass="col-md-6 control-label">Staff name</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="StaffName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="StaffName" CssClass="text-danger" ErrorMessage="The staff name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <div class="checkbox">
                            <asp:CheckBox runat="server" ID="cbStaff1" />
                            <asp:Label runat="server" AssociatedControlID="cbStaff1">Check if Staff I</asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <asp:Button runat="server" OnClick="btnSubmit_Click" Text="Submit" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <asp:Label ID="Status" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <table class="table1">
        <tr>
            <th>Service name</th>
            <th>Input types</th>
            <th>Output type</th>
            <th>Service description</th>
            <th>Comments</th>
        </tr>
        <tr>
            <td>N/A</td>
            <td>N/A</td>
            <td>N/A</td>
            <td>Deletes Staff from Staff.xml. Deletes Staff1 from Staff1 Web.config. Deletes Staff2 to Staff2\Web.config & Staff1\Web.config.</td>
            <td>Uses LINQ to XML.</td>
        </tr>
    </table>
</asp:Content>
