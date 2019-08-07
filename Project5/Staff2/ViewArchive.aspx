<%@ Page Title="View Archive" Language="C#" MasterPageFile="~/MasterStaff2.Master" AutoEventWireup="true" CodeFile="ViewArchive.aspx.cs" Inherits="Staff2_ViewArchive" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff II Services</h2>
    <h3>View Archived File</h3>
    Reads & displays the archived file that is stored by the service
    <br />
    <br />
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FileName" CssClass="col-md-6 control-label">Archived file name</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="FileName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="FileName" CssClass="text-danger" ErrorMessage="The file name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-10">
                        <asp:Button runat="server" OnClick="getFile" Text="View" CssClass="btn btn-default" />
                    </div>
                </div>
                <div class="form-group">
                    <h3>
                        <asp:Label ID="Name" runat="server" Text=""></asp:Label>
                    </h3>
                    <asp:Label ID="Content" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:Xml ID="Xml2" runat="server"></asp:Xml>
    </div>
    <div>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
    </div>
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
            <td>GetFile</td>
            <td>string (fileName)</td>
            <td>string (file contents)</td>
            <td>Given the filename, it gets the file from the File directory in the BankingServices project.</td>
            <td>Uses associated XSL file when displaying XML files.</td>
        </tr>
    </table>
</asp:Content>
