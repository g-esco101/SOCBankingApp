<%@ Page Title="Archive File" Language="C#" MasterPageFile="~/MasterStaff2.Master" AutoEventWireup="true" CodeFile="Storage.aspx.cs" Inherits="Staff2_Storage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff II Services</h2>
    <h3>Archive File</h3>
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <asp:Label runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-6 control-label">File path</asp:Label>
                <div class="col-md-6">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FileUpload1"
                        CssClass="text-danger" ErrorMessage="The file path field is required." />
                </div>
                <div class="col-md-offset-6 col-md-6">
                    <asp:Button runat="server" Text="Archive" OnClick="UploadButton_Click" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
    <asp:Label runat="server" AssociatedControlID="fServerPath">Path on BankingService</asp:Label>
    <asp:Label runat="server" ID="fServerPath"></asp:Label>
    <br />
    <br />
    <table class="table1">
        <tr>
            <th>Service name</th>
            <th>Input types</th>
            <th>Output type</th>
            <th>Service description</th>
            <th>Comments</th>
        </tr>
        <tr>
            <td>Storage</td>
            <td>string (fileName), byte[] (fileContents)</td>
            <td>string (path on server)</td>
            <td>Stores a file in the Files directory in the BankingServices project. It returns the URL of the file in the BankingServices project.</td>
            <td>Uses Utilities.updateArchiveList method to add file to ArchiveList.xml. Uses LINQ to XML. Uses HttpPostedFile.</td>
        </tr>
    </table>
</asp:Content>
