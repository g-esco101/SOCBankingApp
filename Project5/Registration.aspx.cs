using System;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/imageProcess.aspx";
    }

    // Updates image verification data. 
    protected void btnShowStr_Click(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/imageProcess.aspx";
    }

    // Adds member to Web.config file in Member directory.
    protected void btnSubmitStr_Click(object sender, EventArgs e)
    {
        // Image verifier test
        if (Session["generatedString"].Equals(ImageText.Text))
        {
            lblStrResult.Text = "Congratulations! The string you entered is correct.";

            // Check if user has an account
            ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
            try
            {
                if (!myPxy.AccountExists(UserName.Text))
                {
                    myPxy.Close();
                    lblStrResult.Text = "You are not a member.";
                    Image1.ImageUrl = "~/imageProcess.aspx";
                    return;
                }
                myPxy.Close();
            }
            catch
            {
                myPxy.Close();
                lblStrResult.Text = "Account verification failed.";
                Image1.ImageUrl = "~/imageProcess.aspx";
                return;
            }
            // Checks if the member has registered (i.e. exists in Member web.config file)
            if (Utilities.memberRegistered(UserName.Text))
            {
                lblStrResult.Text = "Member already registered.";
                Image1.ImageUrl = "~/imageProcess.aspx";
                return;
            }
            // Update authenticaion in web.config file
            if (!Utilities.updateWebConfig(@"\Member\Web.config", UserName.Text))
            {
                lblStrResult.Text = "Configuration failed.";
                Image1.ImageUrl = "~/imageProcess.aspx";
                return;
            }
            lblStrResult.Text = "Member added successfully.";
            Response.Redirect("Login2.aspx");
        }
        else
        {
            lblStrResult.Text = "The string you entered is incorrect. Please try again.";
            Image1.ImageUrl = "~/imageProcess.aspx";
        }
    }
}