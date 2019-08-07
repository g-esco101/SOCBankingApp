<%@ Page Title="Ledger" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterStaff1.Master" CodeFile="Ledger.aspx.cs" Inherits="Staff1_Ledger" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Staff I Services</h2>
    <h3>Ledger</h3>
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
            <td> Reads the Members.xml file & uses the Members.xsl file to display its content.</td>
            <td></td>
        </tr>
    </table>
</asp:Content>
