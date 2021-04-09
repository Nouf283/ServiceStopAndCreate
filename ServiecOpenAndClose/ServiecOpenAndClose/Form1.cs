using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiecOpenAndClose
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("BrowserService.Demo");
            try
            {
                int millisec1 = Environment.TickCount;
                //TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                //service.Stop();
                //service.WaitForStatus(ServiceControllerStatus.Stopped);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
             //   timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                // ...
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("BrowserService.Demo");
            try
            {
              //  TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
