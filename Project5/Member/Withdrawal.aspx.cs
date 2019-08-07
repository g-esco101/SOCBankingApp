using System;

public partial class Member_Withdrawal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Calls the deposit service. Input: the account nickname & the amount. It dispalays the new balance. 
    protected void withdrawal(object sender, EventArgs e)
    {
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        MasterMember master = (MasterMember)Page.Master;
        string name = master.MasterNickname.Text;
        string bal = myPxy.Withdrawal(name, Amount.Text);
        myPxy.Close();
        master.MasterBalance.Text = bal;
        Utilities.updateLedger(Context.User.Identity.Name, name, "Withdrawal", Amount.Text, bal);
        System.Diagnostics.Debug.WriteLine("Deposit deposit");
    }
}