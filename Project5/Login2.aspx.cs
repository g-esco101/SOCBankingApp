using myLibrary;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

public partial class Login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {

    }

    protected void LoginFunc(object sender, EventArgs e)
    {
        if (myAuthenticate(UserName.Text, Password.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
        }
        else Result.Text = "Invalid login";
    }

    // Checks user input (username & password) against values stored in Staff.xml or Members.xml. 
    private bool myAuthenticate(string username, string password)
    {
        string filepath;
        string nodeName;
        if (cbStaff.Checked)
        {
            filepath = @"\App_Data\Staff.xml";
            nodeName = "Staff";
        }
        else
        {
            filepath = @"\App_Data\Members.xml";
            nodeName = "Member";
        }

        // Hash password using ClassLibrary1 DLL
        string salt;
        string pwdHashed;
        try
        {
            // Hash password using ClassLibrary1 DLL
            salt = Utilities.getSalt(filepath, nodeName, username);
            pwdHashed = Hash.HashGenerator(Password.Text, salt);
        }
        catch
        {
            return false;
        }
        XDocument xmlDocAccts = new XDocument();
        filepath = HttpRuntime.AppDomainAppPath + filepath;

        // Check if account is valid
        try
        {
            xmlDocAccts = XDocument.Load(filepath);
            var existingAccount = from c in xmlDocAccts.Root.Elements(nodeName)
                                  where (c.Element("Name").Value == UserName.Text && c.Element("Password").Value == pwdHashed)
                                  select c;

            foreach (var ea in existingAccount)
            {
                if (!cbStaff.Checked)
                {
                    if (!Utilities.memberRegistered(username)) // Checks if the member has registered (i.e. exists in Member web.config file)
                    {
                        return false;
                    }
                    // Gets account nickname & balance to display in MasterMember.master
                    ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
                    string str1 = myPxy.GetAccountInfo(UserName.Text);
                    myPxy.Close();
                    string[] acctInfo = str1.Split(' ');
                    Session["Nickname"] = acctInfo[1];
                    Session["Balance"] = acctInfo[2];
                }
                return true;
            }
        }
        catch { }
        return false;
    }
}