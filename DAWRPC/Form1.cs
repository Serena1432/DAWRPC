using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DiscordRPC;

namespace DAWRPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string currentDAWName = "None", version = "1.4", state = "", versionText = "";
        DiscordRpcClient client;

        DateTime lastTime, curTime, startTimestamp;
        TimeSpan lastTotalProcessorTime, curTotalProcessorTime;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("DAWRPC").Length > 1)
            {
                timer1.Enabled = false;
                MessageBox.Show("Another instance of DAWRPC is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.Text = "DAW Discord Rich Presence v" + version;
        }

        string GetCPUUsage(Process p)
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

        string GetRAMUsage(Process proc)
        {
            long memsize = 0;
            PerformanceCounter PC = new PerformanceCounter();
            PC.CategoryName = "Process";
            PC.CounterName = "Working Set - Private";
            PC.InstanceName = proc.ProcessName;
            memsize = (long)(PC.NextValue()) / (long)(1048576);
            return memsize.ToString() + "MB";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Begin DAW Process Variables
                var FLStudio = Process.GetProcessesByName("FL");
                var FLStudio64 = Process.GetProcessesByName("FL64");
                var Ab9Intro = Process.GetProcessesByName("Ableton Live 9 Intro");
                var Ab10Intro = Process.GetProcessesByName("Ableton Live 10 Intro");
                var Ab11Intro = Process.GetProcessesByName("Ableton Live 11 Intro");
                var Ab9Stan = Process.GetProcessesByName("Ableton Live 9 Standard");
                var Ab10Stan = Process.GetProcessesByName("Ableton Live 10 Standard");
                var Ab11Stan = Process.GetProcessesByName("Ableton Live 11 Standard");
                var Ab9Suite = Process.GetProcessesByName("Ableton Live 9 Suite");
                var Ab10Suite = Process.GetProcessesByName("Ableton Live 10 Suite");
                var Ab11Suite = Process.GetProcessesByName("Ableton Live 11 Suite");
                var Reaper = Process.GetProcessesByName("reaper");
                var Bitwig = Process.GetProcessesByName("Bitwig Studio");
                var StudioOne = Process.GetProcessesByName("Studio One");
                // End DAW Process Variables
                string clientID = "";
                // Begin DAW Information Grabbing
                if (FLStudio.Length != 0)
                {
                    DAWName.Text = "FL Studio";
                    string title = FLStudio[0].MainWindowTitle;
                    if (title.Contains(" - FL Studio"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 15);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(FLStudio[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(FLStudio[0]);
                    clientID = "824353827704668163";
                    state = CPUUsage.Text + " of CPU usage, " + RAMUsage.Text + " of RAM usage";
                    versionText = FLStudio64[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (FLStudio64.Length != 0)
                {
                    DAWName.Text = "FL Studio";
                    string title = FLStudio64[0].MainWindowTitle;
                    if (title.Contains(" - FL Studio"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 15);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(FLStudio64[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(FLStudio64[0]);
                    clientID = "824353827704668163";
                    versionText = FLStudio64[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab9Intro.Length != 0)
                {
                    DAWName.Text = "Ableton Live 9 Intro";
                    string title = Ab9Intro[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 9 Intro"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 23);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab9Intro[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab9Intro[0]);
                    clientID = "824924155534114896";
                    versionText = Ab9Intro[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab10Intro.Length != 0)
                {
                    DAWName.Text = "Ableton Live 10 Intro";
                    string title = Ab10Intro[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 10 Intro"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 24);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab10Intro[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab10Intro[0]);
                    clientID = "824922704724492339";
                    versionText = Ab10Intro[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab11Intro.Length != 0)
                {
                    DAWName.Text = "Ableton Live 11 Intro";
                    string title = Ab11Intro[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 11 Intro"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 24);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab11Intro[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab11Intro[0]);
                    clientID = "824924504190091275";
                    versionText = Ab11Intro[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab9Suite.Length != 0)
                {
                    DAWName.Text = "Ableton Live 9 Suite";
                    string title = Ab10Suite[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 9 Suite"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 23);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab10Suite[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab10Suite[0]);
                    clientID = "824927510215131156";
                    versionText = Ab9Suite[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab10Suite.Length != 0)
                {
                    DAWName.Text = "Ableton Live 10 Suite";
                    string title = Ab10Suite[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 10 Suite"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 24);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab10Suite[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab10Suite[0]);
                    clientID = "824354477720076309";
                    versionText = Ab10Suite[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab11Suite.Length != 0)
                {
                    DAWName.Text = "Ableton Live 11 Suite";
                    string title = Ab11Suite[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 11 Suite"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 24);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab11Suite[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab11Suite[0]);
                    clientID = "824365569973288980";
                    versionText = Ab11Suite[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab9Stan.Length != 0)
                {
                    DAWName.Text = "Ableton Live 9 Standard";
                    string title = Ab10Stan[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 9 Standard"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 26);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab9Stan[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab9Stan[0]);
                    clientID = "824925290526408759";
                    versionText = Ab9Stan[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab10Stan.Length != 0)
                {
                    DAWName.Text = "Ableton Live 10 Standard";
                    string title = Ab10Stan[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 10 Standard"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 27);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab10Stan[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab10Stan[0]);
                    clientID = "824355553252999208";
                    versionText = Ab10Stan[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab11Stan.Length != 0)
                {
                    DAWName.Text = "Ableton Live 11 Standard";
                    string title = Ab11Stan[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 11 Standard"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 27);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab11Stan[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab11Stan[0]);
                    clientID = "824365704890679347";
                    versionText = Ab11Stan[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Reaper.Length != 0)
                {
                    DAWName.Text = "REAPER";
                    string title = Reaper[0].MainWindowTitle;
                    if (title.Contains(" - REAPER v"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.IndexOf(" - REAPER v"));
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Reaper[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Reaper[0]);
                    clientID = "825128795039465472";
                    var registeredText = "unregistered";
                    if (title.Contains("Registered to ")) registeredText = ", registered to " + title.Substring(title.IndexOf("Registered to ") + 14, title.Length - title.IndexOf("Registered to ") - 14);
                    state = "v" + Reaper[0].Modules[0].FileVersionInfo.ProductVersion.ToString() + registeredText.Substring(0, registeredText.IndexOf(" (")) + ", " + CPUUsage.Text + " of CPU usage, " + RAMUsage.Text + " of RAM usage";
                }
                else if (Bitwig.Length != 0)
                {
                    DAWName.Text = "Bitwig Studio";
                    string title = Bitwig[0].MainWindowTitle;
                    if (title.Contains("Bitwig Studio - "))
                    {
                        ProjectOpening.Text = title.Substring(16, title.Length - 16);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Bitwig[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Bitwig[0]);
                    clientID = "825134933256962108";
                    versionText = Bitwig[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (StudioOne.Length != 0)
                {
                    DAWName.Text = "Studio One";
                    string title = StudioOne[0].MainWindowTitle;
                    if (title.Contains("Studio One - "))
                    {
                        ProjectOpening.Text = title.Substring(13, title.Length - 13);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(StudioOne[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(StudioOne[0]);
                    clientID = "825286462672732160";
                    versionText = StudioOne[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                // End DAW Process Information Grabbing
                else
                {
                    DAWName.Text = "None";
                    ProjectOpening.Text = "None";
                }

                // Update DAWRPC Information
                if (DAWName.Text != currentDAWName)
                {
                    try
                    {
                        client = new DiscordRpcClient(clientID);
                        client.Initialize();
                        currentDAWName = DAWName.Text;
                        startTimestamp = DateTime.UtcNow;
                    }
                    catch
                    {
                        if (client != null)
                        {
                            client.Dispose();
                        }
                    }
                }
                if (DAWName.Text != "None")
                {
                    string details = "Opening project: " + ProjectOpening.Text;
                    // Default state for non-REAPER DAW
                    if (DAWName.Text != "REAPER") state = "v" + versionText + ", " + CPUUsage.Text + " of CPU usage, " + RAMUsage.Text + " of RAM usage";
                    if (ProjectOpening.Text == "None" || ProjectOpening.Text == "Untitled") details = "Opening an untitled project";
                    client.SetPresence(new RichPresence()
                    {
                        Timestamps = new Timestamps()
                        {
                            Start = startTimestamp
                        },
                        Details = details,
                        State = state,
                        Assets = new Assets()
                        {
                            LargeImageKey = "icon",
                            LargeImageText = "DAWRPC v" + version + " by Nico Levianth"
                        }
                    });
                }
                else if (client != null)
                {
                    client.Dispose();
                }
            }
            catch
            {

            }
        }
    }
}
