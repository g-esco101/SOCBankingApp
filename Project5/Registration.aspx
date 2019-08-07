<%@ Page Title="Member Registration" Language="C#" MasterPageFile="~/MasterNonService.Master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Member Registration</h2>
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-6 control-label">Member name</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                            CssClass="text-danger" ErrorMessage="The user name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-6 control-label">Password:</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Image runat="server" ID="Image1"></asp:Image> <br /><br />
                    </div>
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button runat="server" Text="Show Another Image" OnClick="btnShowStr_Click" CssClass="btn btn-default"></asp:Button>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ImageText" CssClass="col-md-6 control-label">Image text</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="ImageText" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ImageText"
                            CssClass="text-danger" ErrorMessage="The image text field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button runat="server" Text="Submit" OnClick="btnSubmitStr_Click" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblStrResult"></asp:Label>
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
            <td>AccountExists</td>
            <td>string (account owner)</td>
            <td>boolean</td>
            <td>Returns true if the owner has an account in Accounts.xml. Adds member member Web.config files in this project.</td>
            <td>Uses LINQ to XML. Uses session state. Calls the ASU image verifier service at http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc</td>
        </tr>
    </table>
</asp:Content>
