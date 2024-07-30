using System.Diagnostics;

class MenuRecorders
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                             ____                        _               
/ ___|  ___ _ __ ___  ___ _ __   |  _ \ ___  ___ ___  _ __ __| | ___ _ __ ___ 
\___ \ / __| '__/ _ \/ _ \ '_ \  | |_) / _ \/ __/ _ \| '__/ _` |/ _ \ '__/ __|
 ___) | (__| | |  __/  __/ | | | |  _ <  __/ (_| (_) | | | (_| |  __/ |  \__ \
|____/ \___|_|  \___|\___|_| |_| |_| \_\___|\___\___/|_|  \__,_|\___|_|  |___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - OBS Studio");
        Console.WriteLine("[2] - Streamlabs");
        Console.WriteLine("[3] - Fraps");
        Console.WriteLine("[4] - Bandicam");
        Console.WriteLine("[5] - ShareX");
        Console.WriteLine("[6] - Monosnap");
        Console.WriteLine("[7] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("OBSStudio", "OBSStudioSetup.exe", "https://cdn-fastly.obsproject.com/downloads/OBS-Studio-30.1.2-Full-Installer-x64.exe");
                break;
            case "2":
                await Installers.DownloadAndInstall("Streamlabs", "StreamlabsSetup.exe", "https://slobs-cdn.streamlabs.com/Streamlabs+Desktop+Setup+1.16.7.exe");
                break;
            case "3":
                await Installers.DownloadAndInstall("Fraps", "FrapsSetup.exe", "https://beepa.com/free/setup.exe");
                break;
            case "4":
                await Installers.DownloadAndInstall("Bandicam", "BandicamSetup.exe", "https://dl.bandicam.com/bdcamsetup.exe");
                break;
            case "5":
                await Installers.DownloadAndInstall("ShareX", "ShareXSetup.exe", "https://github.com/ShareX/ShareX/releases/download/v16.1.0/ShareX-16.1.0-setup.exe");
                break;
            case "6":
                await Installers.DownloadAndInstall("Monosnap", "MonosnapSetup.exe", "https://take.ms/download_monosnap_for_windows");
                break;
            case "7":
                await Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                await Task.Delay(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }
}
