using System;
using System.IO;


public partial class Staff2_ViewArchive : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        showArchiveList();
        Name.Text = "";
        Content.Text = "";
    }

    protected void getFile(object sender, EventArgs e)
    {
        try
        {
            string archivedName = FileName.Text;
            int typeIndex = archivedName.LastIndexOf('.');
            string fileType = archivedName.Substring(typeIndex);
            ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
            string fileContents = myPxy.GetFile(archivedName);
            myPxy.Close();
            int index = archivedName.Length - 23;
            string fileName = archivedName.Remove(index, 23);
            if (fileType == ".xml")
            {
                // Defines the contents of the XML control  
                Xml2.DocumentContent = fileContents;
                string xslName = fileName + ".xsl";
                xslName = "~/App_Data/" + xslName;
                Xml2.TransformSource = Server.MapPath(xslName);
            }
            else
            {
                Name.Text = fileName;
                Content.Text = fileContents;
            }
        }
        catch
        {

        }
    }

    protected void showArchiveList()
    {
        string xmlString = File.ReadAllText(Server.MapPath("~/App_Data/ArchiveList.xml"));

        // Defines the contents of the XML control  
        Xml1.DocumentContent = xmlString;

        Xml1.TransformSource = Server.MapPath("~/App_Data/ArchiveList.xsl");
    }
}