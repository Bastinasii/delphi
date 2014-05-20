using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProiectPAWInterfataSGBD
{
    class XmlReadWrite
    {
        void writeXml(String server, String db)
        {
        }

        List<string> readXml()
        {
            List<string> servers = new List<string>();
            XmlTextReader reader = new XmlTextReader("dbconfig.xml");

            while (reader.Read())
            {
                if (reader.Name == "server")
                {
                    servers.Add(reader.Value);
                }
            }
            return servers;
        }

        List<string> readXml(String server)
        {
            List<string> dbs = new List<string>();
            XmlTextReader reader = new XmlTextReader("dbconfig.xml");


            return dbs;
        }
    }
}
