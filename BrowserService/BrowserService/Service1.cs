using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BrowserService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
          //  timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  

            timer.Enabled = true;
            timer.Enabled = true;
            var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();

            if (RunningProcessPaths.Contains("firefox.exe"))
            {
                //firefox is running
                //Debug.WriteLine("firefox is running");
                WriteToFile("firefox.exe is running" + DateTime.Now);
               

            }

            if (RunningProcessPaths.Contains("chrome.exe"))
            {
                //Google Chrome is running
                //Debug.WriteLine("chrome is running");
                WriteToFile("chrome is running" + DateTime.Now);
                //foreach (Process process in Process.GetProcesses())
                //{
                //    string pname = process.ProcessName;

                //    string plower = pname.ToLower();

                //    string title = process.MainWindowTitle;

                //    if (plower.Contains("chrome") || plower.Contains("google") || plower.Contains("firefox"))
                //    {

                //        process.Kill();
                //        process.WaitForExit();
                //        Console.WriteLine($"{pname} {title}");
                //        WriteToFile("Chrome has stopped" + DateTime.Now);
                //    }
                //}

                var killProcess = ProcessFileNameFinderClass.GetKillPrcesses();
                if (killProcess != null)
                {
                    WriteToFile(killProcess+":"+ DateTime.Now);
                }
                else
                {
                    WriteToFile("killProcess" + DateTime.Now);
                }
            }

        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
