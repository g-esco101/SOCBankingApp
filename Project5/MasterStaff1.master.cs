using System;

public partial class MasterStaff1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterStaff1 Page_Load");
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MasterStaff1 Page_Init");
    }
}
