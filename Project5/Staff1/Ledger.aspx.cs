using System;
using System.IO;

public partial class Staff1_Ledger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlString = File.ReadAllText(Server.MapPath("~/App_Data/Ledger.xml"));

        // Defines the contents of the XML control  
        Xml1.DocumentContent = xmlString;

        Xml1.TransformSource = Server.MapPath("~/App_Data/Ledger.xsl");
    }
}