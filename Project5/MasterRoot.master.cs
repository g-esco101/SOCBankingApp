using System;
using System.Web.Security;

public partial class MasterRoot : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterRoot Page_Load");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterRoot Page_Init");
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterRoot btnSignOut_Click Start");
        FormsAuthentication.SignOut();
        Server.Transfer("/Default.aspx");
        System.Diagnostics.Debug.WriteLine("MasterRoot btnSignOut_Click End");
    }
}
