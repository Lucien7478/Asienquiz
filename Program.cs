using System;
using System.Windows.Forms;

namespace Asienquiz
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            //aktiviert visuelle Stile, legt die Nutzung kompatibler TextRendering-Eigenschaften Applikationsweit fest und führt die Application danach aus
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((Form) new Form1());
        }
  }
}
