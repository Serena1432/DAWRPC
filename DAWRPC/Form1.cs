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
using System.Resources;

namespace DAWRPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string currentDAWName = "None", version = "2.1", state = "", versionText = "", discordUsernameGlobal = "";
        DiscordRpcClient client;

        DateTime lastTime, curTime, startTimestamp;
        TimeSpan lastTotalProcessorTime, curTotalProcessorTime;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));

        bool errorDisplayed = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("DAWRPC").Length > 1)
            {
                timer1.Enabled = false;
                MessageBox.Show("Another instance of DAWRPC is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            this.Text = RPCMenuVersion.Text = "DAW Discord Rich Presence v" + version;
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
                var LMMS = Process.GetProcessesByName("lmms");
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
                    clientID = "908331713032241153";
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
                    clientID = "908331713032241153";
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
                    clientID = "908336639913381918";
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
                    clientID = "908338941613207582";
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
                    clientID = "1189627743919411270";
                    versionText = Ab11Intro[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (Ab9Suite.Length != 0)
                {
                    DAWName.Text = "Ableton Live 9 Suite";
                    string title = Ab9Suite[0].MainWindowTitle;
                    if (title.Contains(" - Ableton Live 9 Suite"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.Length - 23);
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(Ab9Suite[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(Ab9Suite[0]);
                    clientID = "908335858212548608";
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
                    clientID = "908336162337349693";
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
                    clientID = "1189627361881235507";
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
                    clientID = "908342188759482388";
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
                    clientID = "908342338353528932";
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
                    clientID = "1189628515801366690";
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
                    clientID = "909424276208255067";
                    versionText = Reaper[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
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
                    clientID = "909425705819992145";
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
                    clientID = "909425503960727583";
                    versionText = StudioOne[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
                }
                else if (LMMS.Length != 0)
                {
                    DAWName.Text = "LMMS";
                    string title = LMMS[0].MainWindowTitle;
                    if (title.Contains(" - LMMS"))
                    {
                        ProjectOpening.Text = title.Substring(0, title.IndexOf(" - LMMS"));
                    }
                    else
                    {
                        ProjectOpening.Text = "None";
                    }
                    CPUUsage.Text = GetCPUUsage(LMMS[0]) + "%";
                    RAMUsage.Text = GetRAMUsage(LMMS[0]);
                    clientID = "1180315820446982214";
                    versionText = LMMS[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
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
                        discordUsername.Text = "No Discord user available";
                        client = new DiscordRpcClient(clientID);
                        client.OnReady += (readySender, readyEvent) =>
                        {
                            discordUsernameGlobal = readyEvent.User.Username;
                            try
                            {
                                if (!String.IsNullOrEmpty(readyEvent.User.Username)) discordUsername.Text = "Logged in as " + readyEvent.User.Username;
                                else discordUsername.Text = "No Discord user available";
                                errorDisplayed = false;
                            }
                            catch { }
                        };
                        client.OnConnectionFailed += (cfSender, cfEvent) =>
                        {
                            discordUsername.Text = "Connection failed";
                            notifyIcon1.Icon = (Icon)resources.GetObject("red");
                            if (!errorDisplayed)
                            {
                                MessageBox.Show("Cannot connect to Discord pipe " + cfEvent.FailedPipe.ToString() + ".", "DAWRPC Connection Error");
                                errorDisplayed = true;
                            }
                        };
                        client.OnError += (eSender, eEvent) =>
                        {
                            discordUsername.Text = "An error has been occurred";
                            notifyIcon1.Icon = (Icon)resources.GetObject("red");
                            if (!errorDisplayed)
                            {
                                MessageBox.Show("Cannot connect to Discord RPC server.\nCode " + eEvent.Code.ToString() + ": " + eEvent.Message, "DAWRPC Connection Error");
                                errorDisplayed = true;
                            }
                        };
                        client.OnConnectionEstablished += (eSender, eEvent) =>
                        {
                            if (!String.IsNullOrEmpty(discordUsernameGlobal)) discordUsername.Text = "Logged in as " + discordUsernameGlobal;
                            else discordUsername.Text = "No Discord user available";
                            notifyIcon1.Icon = (Icon)resources.GetObject("green");
                            errorDisplayed = false;
                        };
                        client.OnPresenceUpdate += (eSender, eEvent) =>
                        {
                            if (!String.IsNullOrEmpty(discordUsernameGlobal)) discordUsername.Text = "Logged in as " + discordUsernameGlobal;
                            else discordUsername.Text = "No Discord user available";
                            notifyIcon1.Icon = (Icon)resources.GetObject("green");
                            errorDisplayed = false;
                        };
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
                    state = "v" + versionText + ", " + CPUUsage.Text + " of CPU usage, " + RAMUsage.Text + " of RAM usage";
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
                            LargeImageText = "DAWRPC v" + version + " by Harpae/Nico Levianth"
                        }
                    });
                }
                else if (client != null)
                {
                    client.Dispose();
                    notifyIcon1.Icon = (Icon)resources.GetObject("red");
                    discordUsername.Text = "Open a DAW to begin displaying RPC";
                }
            }
            catch
            {

            }
        }

        bool exiting = false;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exiting = true;
            Application.Exit();
        }

        private void openWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exiting)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
