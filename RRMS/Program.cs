using Microsoft.Data.SqlClient;
using RRMS.Forms;

namespace RRMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ConnectToServer();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        static void ConnectToServer()
        {
            Helper.ConnectionStringKey = "ConnectionString";
            try
            {
                Helper.LoadConfiguration("appsettings.json");
                Connection = Helper.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connecting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }
        public static SqlConnection Connection = default!;
    }
}

// Testing Push and Pull

//LOLLL