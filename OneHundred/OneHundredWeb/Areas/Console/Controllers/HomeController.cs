using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneHundredWeb.Areas.Console.Controllers
{
    public class HomeController : Controller
    {
        private List<string> lines = new List<string>();

        public ActionResult Index()
        {
            ProcessStartInfo processStartInfo =
                new ProcessStartInfo(@"C:\Projects\Git\OneHundred\OneHundred\ConsoleProgramLuncher\bin\Debug\ConsoleProgramLuncher.exe");
            processStartInfo.UseShellExecute = false;
            processStartInfo.ErrorDialog = false;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            
            Process process = new Process();

            process.EnableRaisingEvents = true;
            process.ErrorDataReceived += process_ErrorDataReceived;
            process.OutputDataReceived += process_OutputDataReceived;

            process.StartInfo = processStartInfo;
            process.Start();

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            process.StandardInput.Write("e");
            process.StandardInput.Flush();

            process.WaitForExit();

            ViewBag.Lines = lines;

            return View();
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
                lines.Add(e.Data);
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
                lines.Add(String.Format("Error: {0}", e.Data));
        }
    }
}