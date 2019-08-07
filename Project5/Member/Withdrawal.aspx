<%@ Page Title="Withdrawal" Language="C#" MasterPageFile="~/MasterMember.Master" AutoEventWireup="true" CodeFile="Withdrawal.aspx.cs" Inherits="Member_Withdrawal" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
</asp:Content>

<asp:Content runat="server" ID="BodyContent1" ContentPlaceHolderID="MainContent1">
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Amount" CssClass="col-md-6 control-label">Amount</asp:Label>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="Amount" CssClass="form-control" placeholder="e.g., 1000 or 1000.50" />
                        <asp:RegularExpressionValidator runat="server"
                            ControlToValidate="Amount" ValidationExpression="^\d+(\.\d\d)?$"
                            ErrorMessage="Please enter numbers only (e.g., 1000 or 1000.50)." Display="Dynamic" SetFocusOnError="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Amount"
                            CssClass="text-danger" ErrorMessage="The amount field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-6 col-md-6">
                        <asp:Button ID="btnDeposit" runat="server" Text="Withdrawal" OnClick="withdrawal" CssClass="btn btn-default" />
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
            <td>Withdrawal</td>
            <td>string (nickname), string (amount)</td>
            <td>string (new balance)</td>
            <td>Given the account nickname & the amount, it subtracts the amount from the balance, updates the balance in the Accounts.xml file in the BankingServices project, & returns the new balance.</td>
            <td>Uses LINQ to XML. Invokes BankingRestServices Subtraction restful service written by Govinda Escobar at http://localhost:54118/Service.svc </td>
        </tr>
    </table>
</asp:Content>
