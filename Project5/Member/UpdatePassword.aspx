<%@ Page Title="Update Password" Language="C#" MasterPageFile="~/MasterMember.Master" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="Member_UpdatePassword" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="MainContent1">
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-6 control-label">Current password</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="password1" CssClass="col-md-6 control-label">New password</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="password1" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password1"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="password2" CssClass="col-md-6 control-label">New password</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="password2" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password2"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button runat="server" Text="Update" OnClick="update" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Label runat="server" AssociatedControlID="Status"></asp:Label>
                        <asp:Label runat="server" ID="Status"></asp:Label>
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
            <td>UpdatePassword</td>
            <td>string (account owner), string (current password), string (new password), string (new password)</td>
            <td>boolean</td>
            <td>Updates the password in the Accounts.xml file in the BankingServices project & in the Members.xml file in this project.</td>
            <td>It generates a new salt value (RNGCryptoServiceProvider) to replace the current salt value. Uses the HashGenerator method in myLibrary dll (PBKDF2) written by Govinda Escobar. Uses LINQ to XML. </td>
        </tr>
    </table>
</asp:Content>
