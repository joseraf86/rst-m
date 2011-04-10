﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSTmobile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            RSTmobile.view.RSTApp rst = RSTmobile.view.RSTApp.GetInstance();
            FMain fmain = rst.GetMain();
            Application.Run(fmain);
        }
    }
}