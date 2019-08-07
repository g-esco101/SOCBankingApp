using System;

public partial class Staff1_DeleteAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Deletes account from Accounts.xml in BankingServices & member information in Members.xml & Member\Web.config.
    protected void deleteAccount(object sender, EventArgs e)
    {
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        if (myPxy.AccountExists(AccountOwner.Text))
        {
            if (!myPxy.DeleteAccount(AccountOwner.Text))
            {
                myPxy.Close();
                Status.Text = "Account deletion: Unsuccessful";
                return;
            }
        }
        else
        {
            myPxy.Close();
            Status.Text = "Account deletion: Unsuccessful";
            return;
        }
        myPxy.Close();
        if (Utilities.userExists(@"\App_Data\Members.xml", "Member", AccountOwner.Text)) {
            if (!Utilities.deleteUser(@"\App_Data\Members.xml", "Member", AccountOwner.Text))
            {
                Status.Text = "User Deletion: Unsuccessful";
                return;
            }      
        }
        else
        {
            Status.Text = "Account deletion: Unsuccessful";
            return;
        }
        if (Utilities.memberRegistered(AccountOwner.Text)) // Checks if member is in Member/Web.config.
        {
            if (!Utilities.deleteAuthorization(@"\Member\Web.config", AccountOwner.Text))
            {
                Status.Text = "Authorization deletion: Unsuccessful";
                return;
            }
        }

        Status.Text = "Deletion: Successful";
    }
}