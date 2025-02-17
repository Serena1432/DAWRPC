using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Resources;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace DAWRPC
{
    public class DAWConfig
    {
        public string ProcessName;
        public string DisplayText;
        public string TitleRegex;
        public string ClientID;
        public bool HideVersion = false;

        private DateTime lastTime, curTime;
        private TimeSpan lastTotalProcessorTime, curTotalProcessorTime;

        [JsonIgnore]
        public bool IsRunning = false;
        [JsonIgnore]
        public string CPUUsage = "Undefined", RAMUsage = "Undefined", ProjectName = "None", Version = "0.0.0";

        public string GetCPUUsage(Process p)
        {
            if (lastTime == null || lastTime == new DateTime())
            {
                lastTime = DateTime.Now;
                lastTotalProcessorTime = p.TotalProcessorTime;
            }
            else
            {
                curTime = DateTime.Now;
                curTotalProcessorTime = p.TotalProcessorTime;

                double cpuUsage = (curTotalProcessorTime.TotalMilliseconds - lastTotalProcessorTime.TotalMilliseconds) / curTime.Subtract(lastTime).TotalMilliseconds / Convert.ToDouble(Environment.ProcessorCount);
                string cpu = (cpuUsage * 100).ToString("N2");

                lastTime = curTime;
                lastTotalProcessorTime = curTotalProcessorTime;
                return cpu;
            }
            return "Undefined";
        }

        public string GetRAMUsage(Process proc)
        {
            long memsize = 0;
            PerformanceCounter PC = new PerformanceCounter();
            PC.CategoryName = "Process";
            PC.CounterName = "Working Set - Private";
            PC.InstanceName = proc.ProcessName;
            memsize = (long)(PC.NextValue()) / (long)(1048576);
            return memsize.ToString() + "MB";
        }

        public Process GetProcess()
        {
            var process = Process.GetProcessesByName(ProcessName);
            if (process.Length > 0) return process[0];
            return null;
        }

        public void Update(Settings settings)
        {
            Process process = GetProcess();
            if (process != null)
            {
                if (!settings.HideProjectName)
                {
                    // Get the window title
                    string title = process.MainWindowTitle;

                    // Use regex to process window title to the project name
                    Match match = Regex.Match(title, TitleRegex);
                    ProjectName = match.Success ? match.Groups[1].Value : "None";
                }
                else ProjectName = "(hidden)";
                if (!settings.HideSystemUsage)
                {
                    CPUUsage = GetCPUUsage(process) + "%";
                    RAMUsage = GetRAMUsage(process);
                }
                else
                {
                    CPUUsage = "Disabled";
                    RAMUsage = "Disabled";
                }
                Version = process.Modules[0].FileVersionInfo.ProductVersion.ToString();
                IsRunning = true;
            }
            else
            {
                IsRunning = false;
                CPUUsage = "Undefined";
                RAMUsage = "Undefined";
                ProjectName = "None";
            }
        }
    }
}
