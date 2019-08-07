<%@ Page Title="Delete Account" Language="C#" MasterPageFile="~/MasterStaff1.Master" AutoEventWireup="true" CodeFile="DeleteAccount.aspx.cs" Inherits="Staff1_DeleteAccount" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff I Services</h2>
    <h3>Delete Account</h3>
    Deletes the member information in Members.xml, in Member\Web.config, & the account in the service's Accounts.xml file. 
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="AccountOwner" CssClass="col-md-6 control-label">Account owner</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="AccountOwner" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountOwner"
                            CssClass="text-danger" ErrorMessage="The account owner field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Label runat="server" AssociatedControlID="Status"></asp:Label>
                        <asp:Label runat="server" ID="Status"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button runat="server" Text="Delete" OnClick="deleteAccount" CssClass="btn btn-default" />
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
            <td>DeleteAccount</td>
            <td>string (account owner)</td>
            <td>boolean</td>
            <td>Returns true if the account is deleted from Accounts.xml in the BankingServices project. It also deletes the member from Members.xml & Member/Web.config.</td>
            <td>Uses LINQ to XML. </td>
        </tr>
    </table>
</asp:Content>
