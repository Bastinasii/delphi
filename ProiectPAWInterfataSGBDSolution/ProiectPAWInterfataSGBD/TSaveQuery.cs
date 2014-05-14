using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProiectPAWInterfataSGBD
{
    public class TSaveQuery
    {
        // Am presupus ca tot ce intra in fiser va fi string, deci vom folosi o lista de string-uri.
        // Am inclus nume in caz ca vrem sa dam un nume specific unui doc si nr ca sa testez ceva.
        public List<string> list = new List<string>();
        public string name;
        public static int nr=0;

        // Construcotr care primeste doar lista
        public TSaveQuery(List<string> list)
        {
            this.list = list;
            nr++;
            this.name=string.Format("LogFile{0}.txt",nr);
        }
        //Constructor care primeste lista si numele fisierului
        public TSaveQuery(string name, List<string> list)
        {
            this.list = list;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public List<string> SaveQ
        {
            get { return this.list; }
            set { this.list = value; }
        }
        //Metoda care probabil va fi apelata din constructor chiar.
        public void SaveToFile()
        {
            string path = string.Format("C:\\Users\\Tanase\\Documents\\PAWProjects\\Pregatire\\SQLEditorSolution\\SQLEditor\\{0}", Name);
                File.WriteAllLines(path, SaveQ);
        }
    }
}
