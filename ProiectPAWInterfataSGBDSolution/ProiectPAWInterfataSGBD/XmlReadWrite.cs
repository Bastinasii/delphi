using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProiectPAWInterfataSGBD
{
    public class XmlReadWrite
    {
        String dbConf;
        String srvTag;
        String dbTag;

        public XmlReadWrite()
        {
            dbConf = "config.xml";
            srvTag = "name";
            dbTag = "dbname";

            //Console.Write("Constructor XML");
        }
        public void writeXml(String server, String db)
        {
        }

        public List<string> readXml()
        {
            List<string> servers = new List<string>();
            XmlTextReader reader = new XmlTextReader(dbConf);

            while (reader.Read())
            {
                Console.Write(reader.Name + "\n");
                if (reader.Name == srvTag)
                {
                    reader.Read();
                    if(reader.Value !="") servers.Add(reader.Value);
                    reader.Read();
                }
            }
            reader.Close();

            Console.Write("Aici");
            return servers;
        }

        public List<string> readXml(String server)
        {
            List<string> dbs = new List<string>();
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
                                if (reader.Value != "") dbs.Add(reader.Value);
                                reader.Read();
                            }
                        }
                    }
                }
            }
            reader.Close();

            return dbs;
        }
    }
}
