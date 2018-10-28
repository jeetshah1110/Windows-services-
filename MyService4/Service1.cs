using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyService4
{
    public partial class Service1 : ServiceBase
    {
        public System.Timers.Timer t1;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if(!File.Exists(@"C: \Users\Jeet\Desktop\hello.txt"))
            {
                using (File.Create(@"C:\Users\Jeet\Desktop\hello.txt"))
                {

                }
                
            }
           using (StreamWriter sw = new StreamWriter(@"C:\Users\Jeet\Desktop\hello.txt", append: true))
            {
                sw.WriteLine("service running");
            }
            t1 = new System.Timers.Timer();
            t1.Interval = 30000;                //writes every 30 seconds
            t1.AutoReset = true;
            t1.Enabled = true;
            t1.Elapsed += new System.Timers.ElapsedEventHandler(this.WriteFile);
        }

        protected override void OnStop()
        {
            t1.Stop();
            t1 = null;

        }
        public void WriteFile(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Jeet\Desktop\hello.txt",append:true))
            {
                sw.WriteLine("service running");
            }

        }
    }
}
