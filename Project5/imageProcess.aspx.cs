using System;
using System.Drawing.Imaging;
using System.IO;

public partial class imageProcess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Calls the ASU image verifier service http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifierSvc/Service.svc
        Response.Clear();
        ServiceReference2.ServiceClient myPxy = new ServiceReference2.ServiceClient();
        string myStr, userLen;
        userLen = "4";
        myStr = myPxy.GetVerifierString(userLen);
        Session["generatedString"] = myStr;
        Stream myStream = myPxy.GetImage(myStr);
        myPxy.Close();
        System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
        Response.ContentType = "image/jpeg";
        myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
    }
}