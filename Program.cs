﻿using OneClickZip.Forms.Help;
using OneClickZip.Forms.Options;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Models;
using System;
using System.Windows.Forms;

namespace OneClickZip
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //DEBUG
            Console.WriteLine("~~~~~~~ Program ~~~~~~~");
            //args = new string[]{ "E:\\zuTempOneClickZip\\2 - Test Filture Rule Save.oczd" };

            Console.WriteLine(args);
            Console.WriteLine();
            //END DEBUG

            ApplicationArgumentModel applicationArgumentModel = new ApplicationArgumentModel(args);
            ProjectSession.Instance().ApplicationArgumentModel = applicationArgumentModel; ;

            //Application.Run(new Main());

            //MessageBox.Show(applicationArgumentModel.GetAllArgs);

            if (applicationArgumentModel.IsOpenProjectBatchFile)
            {
                Application.Run(new OneClickProcessorFrm());
            }
            else
            {
                Application.Run(new ZipDesigner());
            }
            //Application.Run(new FilterRuleFrm());
            //Application.Run(new About()); 
            //Application.Run(new FileAssociationFrm());
        }
    }
}
