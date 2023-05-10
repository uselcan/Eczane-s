using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eczane
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool prog;
            Mutex mtx = new Mutex(true, "Eczane", out prog);

            if (prog)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
  MessageBox.Show("Bu program zaten çalışıyor.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
        }
    }
}
