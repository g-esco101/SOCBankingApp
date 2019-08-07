<%@ Page Title="Member Ledger" Language="C#" MasterPageFile="~/MasterStaff2.Master" AutoEventWireup="true" CodeFile="MemberLedger.aspx.cs" Inherits="Staff2_MemberLedger" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff II Services</h2>
    <h3>Member Ledger</h3>
    Press to archive member ledger. 
    <div>
        <asp:Button runat="server" Text="Archive" OnClick="archiveLedger" CssClass="btn btn-default" />
    </div>
    <asp:Label runat="server" AssociatedControlID="fServerPath">File path in BankingServices project</asp:Label>
    <asp:Label runat="server" ID="fServerPath"></asp:Label>
    <div>
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
    </div>
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
            <td>N/A</td>
            <td>N/A</td>
            <td>N/A</td>
            <td> Uses Ledger.xsl to display Ledger.xml.</td>
            <td></td>
        </tr>
    </table>
</asp:Content>
