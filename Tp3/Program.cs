using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp3
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Cabaña hola = new Cabaña(010,"hola", "altube", "jose c paz", 1, 4, true, 1452,2, 1);

            //Agencia ag = new Agencia();

            //ag.insertarAlojamiento(hola);

            //AgenciaManager agm = new AgenciaManager();

            //agm.agregarAlojamiento(hola);

            //Console.WriteLine(ag.insertarAlojamiento(hola));

        }
    }
}
