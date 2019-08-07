<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/MasterStaff1.Master" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="Staff1_CreateAccount" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff I Services</h2>
    <h3>Create Account</h3>
    Creates the account in the service's Accounts.xml file. 
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AccountNumber" CssClass="col-md-6 control-label">Account number</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="AccountNumber" CssClass="form-control" placeholder="best to use 4 digit numbers" />
                        <asp:RegularExpressionValidator runat="server"
                            ControlToValidate="AccountNumber" ValidationExpression="^\d+$"
                            ErrorMessage="Please enter numbers only (e.g., 4444)." Display="Dynamic" SetFocusOnError="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountNumber"
                            CssClass="text-danger" ErrorMessage="The account number field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AccountOwner" CssClass="col-md-6 control-label">Account owner</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="AccountOwner" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountOwner"
                            CssClass="text-danger" ErrorMessage="The account owner field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AccountBalance" CssClass="col-md-6 control-label">Account balance</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="AccountBalance" CssClass="form-control" placeholder="e.g., 1000 or 1000.50" />
                        <asp:RegularExpressionValidator runat="server"
                            ControlToValidate="AccountBalance" ValidationExpression="^\d+(\.\d\d)?$"
                            ErrorMessage="Please enter numbers only (e.g., 1000 or 1000.50)." Display="Dynamic" SetFocusOnError="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountBalance"
                            CssClass="text-danger" ErrorMessage="The account balance field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Label runat="server" AssociatedControlID="Nickname">Account nickname</asp:Label>
                        <asp:Label runat="server" ID="Nickname"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button runat="server" Text="Create" OnClick="createAccount" CssClass="btn btn-default" />
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
            <td>CreateAccount</td>
            <td>string (account number), string (account owner), string (account balance)</td>
            <td>string (account nickname)</td>
            <td>Adds account number, nickname, owner, password, & balance to Accounts.xml in the BankingServices project. Adds owner, salt, & password to Members.xml.</td>
            <td>Uses SaltGenerator (RNGCryptoServiceProvider) & HashGenerator (PBKDF2) in myLibrary dll to generate a salt & hash it with the default password (123). Uses the account number to generate an account nickname.</td>
        </tr>
    </table>
</asp:Content>
