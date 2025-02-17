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
using System.IO;
using Newtonsoft.Json;

namespace DAWRPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string currentDAWName = "None",
               version = "2.3",
               versionText = "",
               discordUsernameGlobal = "";

        DiscordRpcClient client;
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));

        public Settings settings = new Settings();
        List<DAWConfig> daws = new List<DAWConfig>();

        bool errorDisplayed = false, hideDAWVersion = false;

        public string settingsPath = Application.StartupPath + "\\settings.json";
        public string dawConfigPath = Application.StartupPath + "\\daws.json";

        RichPresence presence = new RichPresence();

        // Settings Handler

        private void UpdateSettingDisplay()
        {
            hideProjectNameContextMenu.Text = oFFHideProjectNameToolStripMenuItem.Text = "[" + (settings.HideProjectName ? "ON" : "OFF") + "] Hide Project Name";
            hideSystemUsageContextMenu.Text = oFFHideSystemUsageToolStripMenuItem.Text = "[" + (settings.HideSystemUsage ? "ON" : "OFF") + "] Hide System Usage";
        }

        private void SetUpdateInterval()
        {
            int interval = Prompt.ShowDialog("Type the presence update interval (in miliseconds):", "Set Update Interval", settings.UpdateInterval);
            if (interval < 1000) return;
            settings.UpdateInterval = interval;
            settings.Save();
            MessageBox.Show("Successfully set the presence update interval.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToggleHideProjectName()
        {
            settings.HideProjectName = !settings.HideProjectName;
            settings.Save();
            UpdateSettingDisplay();
        }

        private void ToggleHideSystemUsage()
        {
            settings.HideSystemUsage = !settings.HideSystemUsage;
            settings.Save();
            UpdateSettingDisplay();
        }

        // Form Handler

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (Process.GetProcessesByName("DAWRPC").Length > 1)
            {
                MessageBox.Show("Another instance of DAWRPC is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exiting = true;
                Application.Exit();
            }
            this.Text = RPCMenuVersion.Text = "DAW Discord Rich Presence v" + version;
            // Load settings from JSON file
            settings.Load(settingsPath);
            UpdateSettingDisplay();
            timer1.Interval = settings.UpdateInterval;
            if (!File.Exists(dawConfigPath))
            {
                MessageBox.Show("\"" + dawConfigPath + "\" not found.\nRedownload this file from the DAWRPC repository or create one yourself, and reopen this program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exiting = true;
                Application.Exit();
            }
            else
            {
                // Load DAW configurations from JSON file
                daws = JsonConvert.DeserializeObject<List<DAWConfig>>(File.ReadAllText(dawConfigPath));
                timer1.Enabled = true;
                presence.Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "DAWRPC v" + version + " by Harpae/Nico Levianth"
                };
            }
        }

        private void ChangeNotifyIcon(string color)
        {
            notifyIcon1.Icon = (Icon)resources.GetObject(color);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string clientID = "";
                bool isRunning = false;

                // Begin Processing DAW Information
                foreach (DAWConfig daw in daws)
                {
                    daw.Update(settings);
                    if (daw.IsRunning)
                    {
                        DAWName.Text = daw.DisplayText;
                        ProjectOpening.Text = daw.ProjectName;
                        CPUUsage.Text = daw.CPUUsage;
                        RAMUsage.Text = daw.RAMUsage;
                        clientID = daw.ClientID;
                        versionText = daw.Version;
                        hideDAWVersion = daw.HideVersion;
                        isRunning = true;
                        break;
                    }
                }

                if (!isRunning)
                {
                    DAWName.Text = "None";
                    ProjectOpening.Text = "None";
                    CPUUsage.Text = "Undefined";
                    RAMUsage.Text = "Undefined";
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
                                if (!String.IsNullOrEmpty(readyEvent.User.Username))
                                    discordUsername.Text = "Logged in as " + readyEvent.User.Username;
                                else discordUsername.Text = "No Discord user available";
                                errorDisplayed = false;
                            }
                            catch { }
                        };
                        client.OnConnectionFailed += (cfSender, cfEvent) =>
                        {
                            discordUsername.Text = "Connection failed";
                            ChangeNotifyIcon("red");
                            if (!errorDisplayed)
                            {
                                MessageBox.Show("Cannot connect to Discord pipe " + cfEvent.FailedPipe.ToString() + ".", "DAWRPC Connection Error");
                                errorDisplayed = true;
                            }
                        };
                        client.OnError += (eSender, eEvent) =>
                        {
                            discordUsername.Text = "An error has been occurred";
                            ChangeNotifyIcon("red");
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
                            ChangeNotifyIcon("green");
                            errorDisplayed = false;
                        };
                        client.OnPresenceUpdate += (eSender, eEvent) =>
                        {
                            if (!String.IsNullOrEmpty(discordUsernameGlobal)) discordUsername.Text = "Logged in as " + discordUsernameGlobal;
                            else discordUsername.Text = "No Discord user available";
                            ChangeNotifyIcon("green");
                            errorDisplayed = false;
                        };
                        client.Initialize();
                        currentDAWName = DAWName.Text;
                        presence.Timestamps = new Timestamps()
                        {
                            Start = DateTime.UtcNow
                        };
                    }
                    catch
                    {
                        if (client != null)
                        {
                            client.Dispose();
                            currentDAWName = DAWName.Text;
                        }
                    }
                }
                if (DAWName.Text != "None")
                {
                    if (settings.HideSystemUsage)
                    {
                        presence.Details = "Opening project:";
                        presence.State = ProjectOpening.Text;
                    }
                    else
                    {
                        presence.Details = "Opening project: " + ProjectOpening.Text;
                        if (ProjectOpening.Text == "None" || ProjectOpening.Text == "Untitled") presence.Details = "Opening an untitled project";
                        presence.State = (hideDAWVersion ? ("v" + versionText + ", ") : "") + CPUUsage.Text + " of CPU usage, " + RAMUsage.Text + " of RAM usage";
                    }
                    client.SetPresence(presence);
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

        // Menu Buttons

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

        private void setUpdateIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetUpdateInterval();
        }

        private void setUpdateIntervalContextMenu_Click(object sender, EventArgs e)
        {
            SetUpdateInterval();
        }

        private void hideProjectNameContextMenu_Click(object sender, EventArgs e)
        {
            ToggleHideProjectName();
        }

        private void hideSystemUsageContextMenu_Click(object sender, EventArgs e)
        {
            ToggleHideSystemUsage();
        }

        private void oFFHideProjectNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleHideProjectName();
        }

        private void oFFHideSystemUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleHideSystemUsage();
        }
    }
}
