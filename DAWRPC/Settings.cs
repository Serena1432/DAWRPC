using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace DAWRPC
{
	public class Settings
	{
        private string SettingsPath;
        public bool HideProjectName = false;
        public bool HideSystemUsage = false;
        public int UpdateInterval = 2500;

        public void Load(string filePath) {
            this.SettingsPath = filePath;
            if (!File.Exists(filePath)) Save();
            Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(filePath));
            HideProjectName = settings.HideProjectName;
            HideSystemUsage = settings.HideSystemUsage;
            UpdateInterval = settings.UpdateInterval;
        }

        public void Save()
        {
            File.WriteAllText(this.SettingsPath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
	}
}
