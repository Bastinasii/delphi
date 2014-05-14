using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLEditor
{
    static class TSQLEditor
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<string> tabele = new List<string>();
            List<List<string>> output = new List<List<string>>();
            List<string> coloane = new List<string>();
            
            tabele.Add("Angajati");
            tabele.Add("Sucursala");
            coloane.Add("Nume");
            coloane.Add("Functie");
            coloane.Add("Salariu");
            output.Add(new List<string>());
            output.Add(new List<string>());
            output[0].Add("Marius");
            output[0].Add("Barman");
            output[0].Add("2000");
            output[1].Add("Andrei");
            output[1].Add("Manager");
            output[1].Add("2005");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditQueryF(tabele,output,coloane));
            //List<string> list = new List<string>();
            //list.Add("Linia 1");
            //list.Add("Linia 2");
            //list.Add("Linia 3");
            //SaveQuery test = new SaveQuery(list);
            //test.SaveToFile();
        }
    }
}
