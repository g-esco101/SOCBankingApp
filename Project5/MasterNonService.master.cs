using System;

public partial class MasterNonService : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterNonService Page_Load");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterNonService Page_Init");
    }
}
