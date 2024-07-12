using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System;

class MenuClients
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
  ____                         ____ _ _            _       
 / ___| __ _ _ __ ___   ___   / ___| (_) ___ _ __ | |_ ___ 
| |  _ / _` | '_ ` _ \ / _ \ | |   | | |/ _ \ '_ \| __/ __|
| |_| | (_| | | | | | |  __/ | |___| | |  __/ | | | |_\__ \
 \____|\__,_|_| |_| |_|\___|  \____|_|_|\___|_| |_|\__|___/



");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Steam");
        Console.WriteLine("[2] - Epic Games Launcher");
        Console.WriteLine("[3] - EA App (Origin)");
        Console.WriteLine("[4] - GOG");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                DownloadAndInstall("https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe", "SteamSetup.exe", "Steam");
                break;
            case "2":
                DownloadAndInstall("https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi", "EGSSetup.msi", "Epic Games Launcher");
                break;
            case "3":
                DownloadAndInstall("https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe", "OriginSetup.exe", "EA App");
                break;
            case "4":
                DownloadAndInstall("https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe", "GOGSetup.exe", "GOG Galaxy");
                break;
            case "5":
                Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                System.Threading.Thread.Sleep(3000); // Add a delay of 3 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }

    private static void DownloadAndInstall(string url, string fileName, string appName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        {
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                using (var fileStream = new FileStream(saveLocation, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
                }

                Console.WriteLine($"\n{appName} was downloaded successfully!");
                Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

                if (installerProcess != null && !installerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");
                    installerProcess.WaitForExit();

                    if (installerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                    }
                    Console.Clear();
                    File.Delete(saveLocation); // Delete the setup file
                }
            }
            else
            {
                Console.WriteLine($"Failed to download {appName}. Please try again later.");
            }
        }
    }
}