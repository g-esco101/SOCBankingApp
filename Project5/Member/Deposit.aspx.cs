using System;

public partial class Member_Deposit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        
    }

    // Calls the deposit service. Input: the account nickname & the amount. It dispalays the new balance. 
    protected void deposit(object sender, EventArgs e)
    {
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        MasterMember master = (MasterMember)Page.Master;
        string name = master.MasterNickname.Text;
        string bal = myPxy.Deposit(name, Amount.Text);
        myPxy.Close();
        master.MasterBalance.Text = bal;
        Utilities.updateLedger(Context.User.Identity.Name, name, "Deposit", Amount.Text, bal);
    }
}