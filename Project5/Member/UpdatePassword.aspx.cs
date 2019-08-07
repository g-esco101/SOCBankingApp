using myLibrary;
using System;
using System.Linq;
using System.Web;
using System.Xml.Linq;

public partial class Member_UpdatePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Updates the password in the Members.xml file in this project & in the Accounts.xml file in the BankingServices project. 
    protected void update(object sender, EventArgs e)
    {
        if (password1.Text != password2.Text)
        {
            Status.Text = "New password fields must match";
            return;
        }
        // Hash password using ClassLibrary1 DLL
        // Hash password input to compare it to stored values. 
        string saltCurrent = Utilities.getSalt(@"\App_Data\Members.xml", "Member", Context.User.Identity.Name);
        string pwdCurrent = Hash.HashGenerator(password.Text, saltCurrent);
        // Generate new salt & new password to update Accounts.xml file in BankingServices project & Members.xml file in this project. 
        string saltNew = Hash.SaltGenerator();
        string pwdNew = Hash.HashGenerator(password1.Text, saltNew);

        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        try
        {
            if (!myPxy.UpdatePassword(Context.User.Identity.Name, pwdCurrent, pwdNew, pwdNew))
            {
                myPxy.Close();
                Status.Text = "Account password update: Unsuccessful";
                return;
            }
            myPxy.Close();
        }
        catch
        {
            myPxy.Close();
            Status.Text = "Account password update: Unsuccessful";
            return;
        }
        
        string XMLLocale = HttpRuntime.AppDomainAppPath + @"\App_Data\Members.xml";
        XDocument xmlDocAccts = new XDocument();
        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var existingAccount = from c in xmlDocAccts.Root.Elements("Member")
                                  where (c.Element("Name").Value == Context.User.Identity.Name && c.Element("Password").Value == pwdCurrent)
                                  select c;
            foreach (var ea in existingAccount)
            {
                ea.Element("Password").Value = pwdNew;
                ea.Element("Salt").Value = saltNew;
                xmlDocAccts.Save(XMLLocale);
                Status.Text = "Password update: Successful";
                return;
            }
        }
        catch { }
        Status.Text = "Password update: Unsuccessful";
    }
}