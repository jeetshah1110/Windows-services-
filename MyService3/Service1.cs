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
namespace MyService3
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if(!File.Exists(@"C: \Users\Jeet\source\repos\MyService3\bin\Debug\hello.txt"))
            {
                File.Create(@"C: \Users\Jeet\source\repos\MyService3\bin\Debug\hello.txt");
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Jeet\source\repos\MyService3\bin\Debug\hello.txt",append:true))
            {
                sw.WriteLine("service started");
            }
        }

        protected override void OnStop()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Jeet\source\repos\MyService3\bin\Debug\hello.txt",append:true))
            {
                sw.WriteLine("service stopped");
                
            }
        }
    }
}
