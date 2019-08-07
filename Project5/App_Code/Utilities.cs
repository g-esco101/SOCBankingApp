using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml.Linq;


public class Utilities
{
    // Checks if the member has registered (i.e. exists in Member web.config file)
    public static bool memberRegistered(string name)
    {
        string XMLLocale = HttpRuntime.AppDomainAppPath + @"\Member\Web.config";
        XDocument xmlDocAccts = new XDocument();
        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var existingAccount = from c in xmlDocAccts.Element("configuration").Element("system.web").Element("authorization").Elements("allow")
                                  where (c.Attribute("users").Value == name)
                                  select c;
            foreach (var ea in existingAccount)
            {
                return true;
            }
        }
        catch { }
        return false;
    }

    // Returns the salt value, given the owner. 
    public static string getSalt(string filename, string element, string owner)
    {
        string filepath = HttpRuntime.AppDomainAppPath + filename;
        XDocument xmlDoc = new XDocument();
        // Check if staff already exists
        try
        {
            xmlDoc = XDocument.Load(filepath);
            var acct = from c in xmlDoc.Root.Elements(element)
                                  where (c.Element("Name").Value == owner)
                                  select c;
            foreach (var ea in acct)
            {
                return ea.Element("Salt").Value;
            }
        }
        catch { }
        return "Error";
    }

    // Checks if user already exists in local Staff.xml or Member.xml. 
    public static bool userExists(string filename, string element, string name)
    {
        string filepath = HttpRuntime.AppDomainAppPath + filename;
        XDocument xmlDoc = new XDocument();
        // Check if staff already exists
        try
        {
            xmlDoc = XDocument.Load(filepath);
            var existingAccount = from c in xmlDoc.Root.Elements(element)
                                  where (c.Element("Name").Value == name)
                                  select c;
            foreach (var ea in existingAccount)
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
        return false;
    }

    // Adds the user to its associated web.config file
    public static bool updateWebConfig(string location, string name)
    {
        string webConfigFilepath = HttpRuntime.AppDomainAppPath + location;
        XDocument webConfigXml = new XDocument();
        try
        {
            webConfigXml = XDocument.Load(webConfigFilepath);
            XElement xmlElementConfig = new XElement("allow",
                new XAttribute("users", name));
            webConfigXml.Element("configuration").Element("system.web").Element("authorization").AddFirst(xmlElementConfig);
            webConfigXml.Save(webConfigFilepath);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Deletes the user from its associated web.config file
    public static bool deleteAuthorization(string location, string name)
    {
        string XMLLocale = HttpRuntime.AppDomainAppPath + location;
        XDocument xmlDocAccts = new XDocument();
        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var existingAccount = from c in xmlDocAccts.Element("configuration").Element("system.web").Element("authorization").Elements("allow")
                                  where (c.Attribute("users").Value == name)
                                  select c;
            foreach (var ea in existingAccount)
            {
                ea.Remove();
                xmlDocAccts.Save(XMLLocale);
                return true;
            }
        }
        catch { }
        return false;
    }

    // Deletes the user from its associated Staff.xml or Member.xml file
    public static bool deleteUser(string location, string element, string name)
    {
        string XMLLocale = HttpRuntime.AppDomainAppPath + location;
        XDocument xmlDocAccts = new XDocument();
        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var existingAccount = from c in xmlDocAccts.Root.Elements(element)
                                  where (c.Element("Name").Value == name)
                                  select c;
            foreach (var ea in existingAccount)
            {
                ea.Remove();
                xmlDocAccts.Save(XMLLocale);
                return true;
            }
        }
        catch { }
        return false;
    }

    // Updates ArchiveList.xml with archive activity.
    public static void updateArchiveList(string name, string archivedName, string date, string time)
    {
        string XMLLocale = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\ArchiveList.xml");
        XDocument xmlDocAccts = new XDocument();

        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var element = new XElement("File");
            element.Add(new XElement("Name", name));
            element.Add(new XElement("ArchivedName", archivedName));
            element.Add(new XElement("Date", date));
            element.Add(new XElement("Time", time));
            xmlDocAccts.Element("Files").Add(element);
            xmlDocAccts.Save(XMLLocale);
        }
        catch (Exception ex)
        {
            string exMsg = ex.Message.ToLower().ToString();
            if (exMsg.Contains("root") && exMsg.Contains("element") && (exMsg.Contains("not found") || exMsg.Contains("missing")))
            {
                xmlDocAccts = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XProcessingInstruction("xml-stylesheet", "type='text/xsl' ref='ArchiveList.xsl'"),
                new XComment("Archive List"),
                new XElement("Files"));
                var element = new XElement("File");
                element.Add(new XElement("Name", name));
                element.Add(new XElement("ArchivedName", archivedName));
                element.Add(new XElement("Date", date));
                element.Add(new XElement("Time", time));
                xmlDocAccts.Element("Files").Add(element);
                xmlDocAccts.Save(XMLLocale);
            }
        }
    }

    // Updates the ledger with any account activity resulting in a balance change.
    public static void updateLedger(string owner, string nickname, string transType, string amount, string balance, string destinationAcct = "")
    {
        string XMLLocale = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Ledger.xml");
        XDocument xmlDocAccts = new XDocument();
        string date = DateTime.Now.ToString("yyyy-M-dd");
        string time = DateTime.Now.ToString("HH:mm:ss");

        ServiceReference1.myInterfaceClient myPxy = new ServiceReference1.myInterfaceClient();
        string[] acctInfo = myPxy.GetAccountInfo(owner).Split(' ');
        myPxy.Close();
        try
        {
            xmlDocAccts = XDocument.Load(XMLLocale);
            var trans = new XElement("Transaction");
            trans.Add(new XElement("AccountNumber", acctInfo[0]));
            trans.Add(new XElement("Nickname", nickname));
            trans.Add(new XElement("Owner", owner));
            var type = new XElement("TransactionType", transType);
            type.Add(new XAttribute("AssociatedAccount", destinationAcct));
            trans.Add(type);
            trans.Add(new XElement("Amount", amount));
            trans.Add(new XElement("Balance", balance));
            trans.Add(new XElement("Date", date));
            trans.Add(new XElement("Time", time));
            xmlDocAccts.Element("Transactions").Add(trans);
            xmlDocAccts.Save(XMLLocale);
        }
        catch (Exception ex)
        {
            string exMsg = ex.Message.ToLower().ToString();
            if (exMsg.Contains("root") && exMsg.Contains("element") && (exMsg.Contains("not found") || exMsg.Contains("missing")))
            {
                xmlDocAccts = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XProcessingInstruction("xml-stylesheet", "type='text/xsl' ref='Ledger.xsl'"),
                new XComment("Transaction Ledger"),
                new XElement("Transactions"));
                var trans = new XElement("Transaction");
                trans.Add(new XElement("AccountNumber", acctInfo[0]));
                trans.Add(new XElement("Nickname", nickname));
                trans.Add(new XElement("Owner", owner));
                var type = new XElement("TransactionType", transType);
                type.Add(new XAttribute("AssociatedAccount", destinationAcct));
                trans.Add(type);
                trans.Add(new XElement("Amount", amount));
                trans.Add(new XElement("Balance", balance));
                trans.Add(new XElement("Date", date));
                trans.Add(new XElement("Time", time));
                xmlDocAccts.Element("Transactions").Add(trans);
                xmlDocAccts.Save(XMLLocale);
            }
        }
    }
}