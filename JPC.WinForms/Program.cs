using JPC.Business.Services.Implementations.CSS;
using JPC.Business.Services.Interfaces.CSS;
using Microsoft.Extensions.DependencyInjection;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.CSS;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.Login;
using Nhom14_DoAnCNPM_JobPlacementCenter_Code.Forms.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom14_DoAnCNPM_JobPlacementCenter_Code
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrangChuCSS_Form());
        }
    }
}
