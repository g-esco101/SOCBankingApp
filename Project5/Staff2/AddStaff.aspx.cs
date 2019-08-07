using System;
using System.Web;
using System.Xml.Linq;
using myLibrary;

public partial class Staff2_AddStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Adds staff to Staff.xml & the associated Web.config file
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
        // Validate staff name & password
        string role;
        if (cbStaff1.Checked)
        {
            role = "Staff1";
        }
        else
        {
            role = "Staff2";
        }

        // Hash password using DLL
        string salt = Hash.SaltGenerator();
        string pwdHashed = Hash.HashGenerator(Password.Text, salt);
        XDocument xmlDocAccts = new XDocument();

        // Check if staff already exists
        if (Utilities.userExists(@"App_Data\Staff.xml", "Staff", StaffName.Text))
        {
            lblResult.Text = "Staff already exists.";
            return;
        }

        // Adds staff to authorization in Staff1\Web.config file
        if (!Utilities.updateWebConfig(@"\Staff1\Web.config", StaffName.Text))
        {
            lblResult.Text = "Configuration failed.";
            return;
        }

        if (!cbStaff1.Checked)
        {
            // Adds staff to authorization in Staff2\Web.config file
            if (!Utilities.updateWebConfig(@"\Staff2\Web.config", StaffName.Text))
            {
                lblResult.Text = "Configuration failed.";
                return;
            }
        }
        // If staff does not exist, add staff to App_Data\Staff.xml
        try
        {
            xmlDocAccts = XDocument.Load(filepath);
            XElement xmlElement = new XElement("Staff",
                new XElement("Name", StaffName.Text),
                new XElement("Salt", salt),
                new XElement("Password", pwdHashed),
                new XElement("Role", role));
            xmlDocAccts.Element("Staffs").Add(xmlElement);
        }
        catch (Exception ex)
        {
            // Creates App_Data\Staff.xml if it does not exist & adds staff to it.
            string exMsg = ex.Message.ToLower().ToString();
            if (exMsg.Contains("root") && exMsg.Contains("element") && (exMsg.Contains("not found") || exMsg.Contains("missing")))
            {
                xmlDocAccts = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XComment("Staff Database"),
                new XElement("Staffs",
                new XElement("Staff",
                new XElement("Name", StaffName.Text),
                new XElement("Salt", salt),
                new XElement("Password", pwdHashed),
                new XElement("Role", role))));
            }
        }
        xmlDocAccts.Save(filepath);
        lblResult.Text = "Staff added successfully.";
    }
}