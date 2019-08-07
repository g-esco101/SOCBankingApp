<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterNonService.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h2>SOC Banking Application</h2>
            <p>
                The SOC Banking Application consumes the SOAP services in the BankingServices repository, which
                consume the RESTful services in the BankingRestServices repository. Each service has its own web 
                page where it can be tried. Each web page has information about the service.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Service Testing</h2>
            <p>
                Login as a Member, Staff I, or Staff II. Staff II is authorized to use Staff I & Staff II services. 
                    Members are allowed to self-subsribe, i.e. add himself/herself to Members.xml. This should be done after an
                    account is created for him/her by Staff. Only one account per owner is supported.          
            </p>
        </div>
        <div class="col-md-4">
            <h2>Future Development</h2>
            <p>
                Make file updates transactional.
            </p>
        </div>
    </div>
    <h2>Contact</h2>
    <h3>Govinda Escobar</h3>
    <address>
        <a href="mailto:govinda.escobar@gmail.com">govinda.escobar@gmail.com</a><br />
    </address>
</asp:Content>
