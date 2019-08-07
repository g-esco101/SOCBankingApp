<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterNonService.master" AutoEventWireup="true" CodeFile="Login2.aspx.cs" Inherits="Login2" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Login</h2>
    Test Input<br />
    Members: Albert or Higgs<br />
    Staff1: Bob or Julia<br />
    Staff2: Alice or John<br />
    Password: 123
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-6 control-label">User name</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                            CssClass="text-danger" ErrorMessage="The user name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-6 control-label">Password</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <div class="checkbox">
                            <asp:CheckBox runat="server" ID="cbStaff" />
                            <asp:Label runat="server" AssociatedControlID="cbStaff">Check if Staff</asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <asp:Button runat="server" OnClick="LoginFunc" Text="Login" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="Result"></asp:Label>
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
            <td>GetAccountInfo</td>
            <td>string (owner)</td>
            <td>string (account number, nickname, & balance)</td>
            <td>Checks user input (username & password) against values stored in Staff.xml or Members.xml. Given the account owner, it returns a string containing the account number, nickname, & balance seperated by spaces.</td>
            <td>Uses HashGenerator (PBKDF2) in myLibrary dll. It gets the salt (RNGCryptoServiceProvider) stored in Members.xml/Staff.xml, & uses that & the user input password to generate a hash value. Then it uses the hash value & name to find the user in the xml file. Uses LINQ to XML. Uses session state - gets account nickname & balance to display in MasterMember.master</td>
        </tr>
    </table>
</asp:Content>
