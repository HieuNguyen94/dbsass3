using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldCup
{
    public enum AccountType
    {
        Admin,
        TeamManager,
        Reporter,
        Client,
        None
    };
    public enum TableType
    { 
        WorldCup,
        TaiKhoan,
        QuanLyDoiBong,
        None
    };
    static class Program
    {
        public static string username = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            
            if (username != null)
            {
                if (loginForm.getAccountType == AccountType.Admin)
                {
                    AdminForm adminForm = new AdminForm();
                    Application.Run(adminForm);
                }
                else if (loginForm.getAccountType == AccountType.TeamManager)
                {
                    TeamManagerForm teamManagerForm = new TeamManagerForm();
                    Application.Run(teamManagerForm);
                }
                else if (loginForm.getAccountType == AccountType.Reporter)
                {
                    ReporterForm reporterForm = new ReporterForm();
                    Application.Run(reporterForm);
                }
                else if (loginForm.getAccountType == AccountType.Client)
                {
                    ClientForm clientForm = new ClientForm();
                    Application.Run(clientForm);
                }
            }
        }
    }
}
