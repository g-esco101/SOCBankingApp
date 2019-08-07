using System;

public partial class Member_Transfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Calls the Transfer service. Input: the source account nickname, its password,
    // amount, & destination account nicknames. It displays the new balance of the source account. 
    protected void transfer(object sender, EventArgs e)
    {
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        MasterMember master = (MasterMember)Page.Master;
        string name = master.MasterNickname.Text;
        string transReturn = myPxy.Transfer(name, dNickname.Text, Amount.Text);
        myPxy.Close();
        master.MasterBalance.Text = transReturn;
        Utilities.updateLedger(Context.User.Identity.Name, name, "Transfer", "-" + Amount.Text, transReturn, dNickname.Text);
    }
}