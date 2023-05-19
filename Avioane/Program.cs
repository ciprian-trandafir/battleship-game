using System;
using System.Windows.Forms;

namespace Avioane
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            new Main();

            Application.Run();
        }
    }
}
