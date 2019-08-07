using System;
using System.Web;

public partial class Staff2_DeleteStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Adds staff to Staff.xml & the associated Web.config file
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
        // Update authenticaion in Staff1\Web.config file
        if (!Utilities.deleteAuthorization(@"\Staff1\Web.config", StaffName.Text))
        {
            Status.Text = "Authorization1 deletion: Unsuccessful";
            return;
        }
        if (!cbStaff1.Checked)
        {
            // Update authenticaion in Staff2\Web.config file
            if (!Utilities.deleteAuthorization(@"\Staff2\Web.config", StaffName.Text))
            {
                Status.Text = "Authorization2 deletion: Unsuccessful";
                return;
            }
        }
        if (!Utilities.deleteUser(@"\App_Data\Staff.xml", "Staff", StaffName.Text))
        {
            Status.Text = "User Deletion: Unsuccessful";
            return;
        }
        Status.Text = "Deletion: Successful";
    }
}