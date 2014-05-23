using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace ProiectPAWInterfataSGBD
{
    public class XmlReadWrite
    {
        string dbConf;
        string srvTag;
        string dbTag;

        public XmlReadWrite()
        {
            dbConf = "config.xml";
            srvTag = "name";
            dbTag = "dbname";
        }
        public void createXml()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmldecl;
            xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            
            XmlNode rootNode = xmlDoc.CreateElement("servers");
            xmlDoc.AppendChild(rootNode);
            xmlDoc.InsertBefore(xmldecl, rootNode);

            xmlDoc.Save("config.xml");
        }

        public void writeXml(string server, string db)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("config.xml");

                XmlNode rootNode = xmlDoc.DocumentElement;

                XmlNode serverNode = xmlDoc.CreateElement("server");
                rootNode.AppendChild(serverNode);

                XmlNode nameNode = xmlDoc.CreateElement("name");
                nameNode.InnerText = server;
                serverNode.AppendChild(nameNode);
               
                XmlNode dbNode = xmlDoc.CreateElement("database");
                serverNode.AppendChild(dbNode);

                XmlNode dbnameNode = xmlDoc.CreateElement("dbname");
                dbnameNode.InnerText = db;
                dbNode.AppendChild(dbnameNode);

                xmlDoc.Save("config.xml");
            }

            catch (Exception e)
            {
                MessageBox.Show("XML corupt!");
            }

        }

        public bool exists(string server)
        {
            bool rez = false;
            XmlTextReader reader = new XmlTextReader(dbConf);
            try
            {              
                while (reader.Read())
                {
                    if (reader.Value == server)
                    {
                        rez = true;
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
             
            }

            return rez;
        }

        public bool exists(string server, string db)
        {
            bool rez = false;
            XmlTextReader reader = new XmlTextReader(dbConf);
            try
            {
                while (reader.Read())
                {
                    if (reader.Value == server)
                    {
                        reader.Read();
                        while (reader.Read() && reader.Name != srvTag)
                        {
                            if (reader.Value == db)
                            {
                                rez = true;
                            }
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {

            }

            return rez;
        }

        public void writeXmlDb(string server, string db)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("config.xml");

                XmlNode rootNode = xmlDoc.DocumentElement;

                XmlNode serverNode = xmlDoc.SelectSingleNode("/servers/server[name='" + server + "']");

                XmlNode dbNode = xmlDoc.CreateElement("database");
                serverNode.AppendChild(dbNode);

                XmlNode dbnameNode = xmlDoc.CreateElement("dbname");
                dbnameNode.InnerText = db;
                dbNode.AppendChild(dbnameNode);

                xmlDoc.Save("config.xml");
            }

            catch (Exception e)
            {
                MessageBox.Show("XML corupt!");
            }
        }

        public void removeServer(string node)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("config.xml");

                XmlElement server = (XmlElement)xmlDoc.SelectSingleNode("/servers/server[name='" + node + "']");
                if (server != null)
                {
                    server.ParentNode.RemoveChild(server);
                }

                xmlDoc.Save("config.xml");
            }

            catch (Exception e)
            {
                MessageBox.Show("XML corupt!");
            }
        }

        public void removeDb(string srv, string node)
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("config.xml");

                XmlElement server = (XmlElement)xmlDoc.SelectSingleNode("/servers/server[name='" + srv + "']/database[dbname='" + node + "']");
                if (server != null)
                {
                    server.ParentNode.RemoveChild(server);
                }

                xmlDoc.Save("config.xml");
            }

            catch (Exception e)
            {
                MessageBox.Show("XML corupt!");
            }
        }

        public List<string> readXml()
        {
            List<string> servers = new List<string>();
            XmlTextReader reader = new XmlTextReader(dbConf);
            try
            {              
                while (reader.Read())
                {
                    if (reader.Name == srvTag)
                    {
                        reader.Read();
                        if (!(String.IsNullOrWhiteSpace(reader.Value))) servers.Add(reader.Value);
                        reader.Read();
                    }
                }
                reader.Close();
                servers.Sort();
            }
            catch (Exception e)
            {
                servers = null;
            }
            return servers;
        }
        

        public List<string> readXml(String server)
        {
            List<string> dbs = new List<string>();
            
            if (String.IsNullOrWhiteSpace(server))
            {
                dbs = null;
            }
            else
            {
                try
                {
                    XmlTextReader reader = new XmlTextReader(dbConf);

                    while (reader.Read())
                    {
                        if (reader.Name == srvTag)
                        {
                            reader.Read();
                            if (reader.Value == server)
                            {
                                reader.Read();
                                while (reader.Read() && reader.Name != srvTag)
                                {
                                    if (reader.Name == dbTag)
                                    {
                                        reader.Read();
                                        if (!(String.IsNullOrWhiteSpace(reader.Value))) dbs.Add(reader.Value);
                                        reader.Read();
                                    }
                                }
                            }
                        }
                    }
                    reader.Close();
                    dbs.Sort();
                }
                catch (Exception e)
                {
                    dbs = null;
                }
            }
            return dbs;
        }
    }
}
