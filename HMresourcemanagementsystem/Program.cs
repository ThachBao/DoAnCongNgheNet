﻿using HMresourcemanagementsystem.BoPhan;
using HMresourcemanagementsystem.ChamCong;
using HMresourcemanagementsystem.duAn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMresourcemanagementsystem.Group
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
            Application.Run(new Login());
        }
    }
}
