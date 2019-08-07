using myLibrary;
using System;
using System.Web;
using System.Xml.Linq;

public partial class Staff1_CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    // Creates the account in the Accounts.xml file in the BankingServices project, & adds the member to Members.xml in this project. 
    protected void createAccount(object sender, EventArgs e)
    {
        // Check if member already exists
        if (Utilities.userExists(@"App_Data\Members.xml", "Member", AccountOwner.Text))
        {
            Nickname.Text = "Member already registered.";
            return;
        }
        string defaultPassword = "123";
        string pwdHashed;
        string salt;
        try
        {
            // Hash password using myLibrary DLL
            salt = Hash.SaltGenerator();
            pwdHashed = Hash.HashGenerator(defaultPassword, salt);
            addMember(pwdHashed, salt);
        }
        catch
        {
            Nickname.Text = "Member not created.";
            return;
        }
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        try
        {
            string accountInfo = myPxy.CreateAccount(AccountNumber.Text, AccountOwner.Text, AccountBalance.Text, pwdHashed);
            myPxy.Close();
            Nickname.Text = accountInfo;
            return;
        }
        catch
        {
            myPxy.Close();
            Nickname.Text = "Member not created.";
        }      
    }

    // Adds member to Members.xml in this project. 
    private void addMember(string pwd, string slt)
    {
        string filepath = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Members.xml");
        XDocument xmlDocAccts = new XDocument();
        // If member does not exist add member to App_Data\Members.xml
        try
        {
            xmlDocAccts = XDocument.Load(filepath);
            XElement xmlElement = new XElement("Member",
                new XElement("Name", AccountOwner.Text),
                new XElement("Salt", slt),
                new XElement("Password", pwd));
            xmlDocAccts.Element("Members").Add(xmlElement);
        }
        catch (Exception ex)
        {
            // Creates App_Data\Members.xml if it does not exist & adds member to it.
            string exMsg = ex.Message.ToLower().ToString();
            if (exMsg.Contains("root") && exMsg.Contains("element") && (exMsg.Contains("not found") || exMsg.Contains("missing")))
            {
                xmlDocAccts = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XComment("Member Database"),
                new XElement("Members",
                new XElement("Member",
                new XElement("Name", AccountOwner.Text),
                new XElement("Salt", slt),
                new XElement("Password", pwd))));
            }
        }
        xmlDocAccts.Save(filepath);
    }
}