using System;
using System.IO;
using System.Web;

public partial class Staff2_MemberLedger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlString = File.ReadAllText(Server.MapPath("~/App_Data/Ledger.xml"));

        // Defines the contents of the XML control  
        Xml1.DocumentContent = xmlString;

        Xml1.TransformSource = Server.MapPath("~/App_Data/Ledger.xsl");
    }

    // Calls the Storage service. Input: the file path & a byte array of the file contents. 
    // It displays the path to the file on the server.
    protected void archiveLedger(object sender, EventArgs e)
    {
        try
        {
            string filePath = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Ledger.xml");
            if (File.Exists(filePath))
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                string date = DateTime.Now.ToString("yyyy-M-dd");
                string time = DateTime.Now.ToString("HH-mm-ss");
                string archivedName = "Ledger" + "_" + date + "_" + time + ".xml";
                ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
                fServerPath.Text = myPxy.Storage(archivedName, bytes);
                myPxy.Close();
                Utilities.updateArchiveList("Ledger.xml", archivedName, date, time);
                return;
            }

        }
        catch (Exception s)
        {
            fServerPath.Text = s.ToString();
            return;
        }
        fServerPath.Text = "Upload failed";
    }
}