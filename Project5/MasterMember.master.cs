using System;
using System.Web.UI.WebControls;

public partial class MasterMember : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        System.Diagnostics.Debug.WriteLine("MasterMember Page_Load");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // Get account information from service
        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        string str1 = myPxy.GetAccountInfo(Context.User.Identity.Name);
        myPxy.Close();
        string[] acctInfo = str1.Split(' ');
        Nickname.Text = acctInfo[1];
        Balance.Text = acctInfo[2];
        System.Diagnostics.Debug.WriteLine("MasterMember Page_Init");
    }

    public Label MasterBalance
    {
        get { return Balance; }
        set { Balance = value; }
    }

    public Label MasterNickname
    {
        get { return Nickname; }
        set { Nickname = value; }
    }
}
