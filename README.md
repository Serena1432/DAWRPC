# DAW Discord Rich Presence

This is a small C# application that supports showing what you're making on your Digital Audio Workstation (DAW) in your Discord account using Discord Rich Presence.

It will show as the following:

![Discord Presence image](https://i.imgur.com/7wWlQNM.png)

[VirusTotal Scanning](https://www.virustotal.com/gui/file/e31d0c64fac5dd2b5880d9c2c8264bd4ca1b525a782f70774e1a3ca07b0b639e)<br>
1 detection from MaxSecure, is this false positive?

## List of DAW currently supported

* FL Studio 11 or later
* Ableton Live 9 Intro or later (doesn't support Lite, Beta and Trial version)
* REAPER
* Bitwig Studio (fxxk Bitwig, you used more CPU and RAM than Ableton)
* Studio One
* LMMS

## Installation

Download the latest release version [here](https://github.com/lmharpae/DAWRPC/releases), extract it and run the `DAWRPC.exe` executable file. Open any supported DAW and enjoy the result!

## How does it work?

This app uses the [Process](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process) class to get the current running DAW process(es) and reads the project name from the process(es) window title.

## Dependencies used

* .NET Framework 4
* [DiscordRPC](https://github.com/Lachee/discord-rpc-csharp) by Lachee
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [System.Windows.Forms](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms)
* [System.Diagnostics.Process](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process)
* [System.Diagnostics.PerformanceCounter](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.performancecounter)

## Editing the source code

Download the latest source code from this repository above and open `DAWRPC.sln` in your Visual Studio that supports .NET Framework 4. I used *Visual Studio 2010* to make this application (i know, this is an old version but my computer can't run a higher one), and I suggest that you should use it (although i know that no one uses it anymore) to edit my application.

### You can add a new DAW support using this method:

* **Step 1:** Go to your [Discord Developer Portal](https://discord.com/developers/applications) and create a new application with the DAW name you want to support.
* **Step 2:** Go to your new application you have just created and click `Rich Presence -> App Assets`.
* **Step 3:** Add a new Rich Presence Asset Image with the DAW icon. Set the Asset Image Name into `icon`.
* **Step 4:** Open the `DAWRPC.sln` project file and open the `Form1.cs` file in your Visual Studio.
* **Step 5:** Above the `// End DAW Process Variables` line, add the following code line:

```csharp
var YourDAWName = Process.GetProcessesByName("YourDAWProcessName");
```

with `YourDAWName` as the DAW name and `YourDAWProcessName` as your DAW Process Name in Task Manager (for example, `FL64` is the Process Name of FL Studio, and `Ableton Live 10 Suite` is the Process Name of Ableton Live 10 Suite).

* **Step 6:** Above the `// End DAW Process Information Grabbing` line, add the following code lines:

```csharp
else if (YourDAWName.Length != 0)
{
	DAWName.Text = "Your DAW Name";
	if (SomeConditions)
	{
		ProjectOpening.Text = SomeScripts();
	}
	else
	{
		ProjectOpening.Text = "None";
	}
	CPUUsage.Text = GetCPUUsage(YourDAWName[0]) + "%";
	RAMUsage.Text = GetRAMUsage(YourDAWName[0]);
	clientID = "YourClientID";
	versionText = YourDAWName[0].Modules[0].FileVersionInfo.ProductVersion.ToString();
}
```

with `YourDAWName` as the DAW variable you declared in the above step, `SomeConditions` as some conditions to check if the project name is other than `Untitled`, `SomeScripts()` is some commands to get the project title from the process, and `YourClientID` as the Client ID of the application created in Step 1.

You can see an example in the source code repository.

* **Step 7:** Run the application and test it. After that, you can [send me a Pull Request](https://github.com/lmharpae/DAWRPC/compare) with your new added DAW supporting in the source code.

## Contact the developer

You can contact the developer by using these social networks:

* [Discord](https://discord.com/users/693107293516070944)
* Facebook: `(temporarily not available)`
* YouTube: [Harpae](https://www.youtube.com/@lmharpae)
