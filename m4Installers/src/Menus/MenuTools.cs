using System.Diagnostics;

class MenuTools
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _____           _     
|_   _|__   ___ | |___ 
  | |/ _ \ / _ \| / __|
  | | (_) | (_) | \__ \
  |_|\___/ \___/|_|___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - WinRAR");
        Console.WriteLine("[2] - 7zip");
        Console.WriteLine("[3] - AIDA64");
        Console.WriteLine("[4] - CPU-Z");
        Console.WriteLine("[5] - GitHub Desktop");
        Console.WriteLine("[6] - GitKraken");
        Console.WriteLine("[7] - HWInfo");
        Console.WriteLine("[8] - Lightshot");
        Console.WriteLine("[9] - Docker");
        Console.WriteLine("[10] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("WinRAR", "WinRARSetup.exe", "https://www.win-rar.com/fileadmin/winrar-versions/winrar/winrar-x64-701.exe");
                break;

            case "2":
                await Installers.DownloadAndInstall("7zip", "7zipSetup.exe", "https://www.7-zip.org/a/7z2407-x64.exe");
                break;

            case "3":
                await Installers.DownloadAndInstall("AIDA64", "AIDA64Setup.exe", "https://download2.aida64.com/aida64extreme730.exe");
                break;

            case "4":
                await Installers.DownloadAndInstall("CPU-Z", "CPUZSetup.exe", "https://download.cpuid.com/cpu-z/cpu-z_1.79-en.exe");
                break;

            case "5":
                await Installers.DownloadAndInstall("GitHub Desktop", "GitHubDesktopSetup.exe", "https://central.github.com/deployments/desktop/desktop/latest/win32");
                break;

            case "6":
                await Installers.DownloadAndInstall("GitKraken", "GitKrakenSetup.exe", "https://release.gitkraken.com/windows/GitKrakenSetup.exe");
                break;

            case "7":
                await Installers.DownloadAndInstall("HWInfo", "HWInfoSetup.exe", "https://sinalbr.dl.sourceforge.net/project/hwinfo/Windows_Installer/hwi64_804.exe?viasf=1");
                break;

            case "8":
                await Installers.DownloadAndInstall("Lightshot", "LightshotSetup.exe", "https://app.prntscr.com/build/setup-lightshot.exe");
                break;

            case "9":
                await Installers.DownloadAndInstall("Docker", "DockerSetup.exe", "https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe");
                break;

            case "10":
                await Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }
}
