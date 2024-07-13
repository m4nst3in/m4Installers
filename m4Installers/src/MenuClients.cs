using System.Diagnostics;

class MenuClients
{
    public static async Task ShowMenu()
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
        Console.WriteLine("[5] - Ubisoft Connect");
        Console.WriteLine("[6] - Battle.net");
        Console.WriteLine("[7] - Xbox App");
        Console.WriteLine("[8] - Itch.io");
        Console.WriteLine("[9] - Rockstar Launcher");
        Console.WriteLine("[10] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("Steam", "SteamSetup.exe", "https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe");
                break;
            case "2":
                await DownloadAndInstall("Epic Games Launcher", "EGSSetup.msi", "https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi");
                break;
            case "3":
                await DownloadAndInstall("EA App", "OriginSetup.exe", "https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe");
                break;
            case "4":
                await DownloadAndInstall("GOG Galaxy", "GOGSetup.exe", "https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe");
                break;
            case "5":
                await DownloadAndInstall("Ubisoft Connect", "UbiConnectSetup.exe", "https://ubi.li/4vxt9");
                break;
            case "6":
                await DownloadAndInstall("Battle.net", "BattleNetSetup.exe", "https://downloader.battle.net//download/getInstallerForGame?os=win&gameProgram=BATTLENET_APP&version=Live");
                break;
            case "7":
                await DownloadAndInstall("Xbox App", "XboxAppSetup.exe", "https://assets.xbox.com/installer/20190628.8/anycpu/XboxInstaller.exe");
                break;
            case "8":
                await DownloadAndInstall("Itch.io", "ItchIOSetup.exe", "https://www.dropbox.com/scl/fi/xz9f99o403o2i00gxdci7/itch-setup.exe?rlkey=5ri0faw8hr22qoykqvvscjhsr&st=wov1z2d6&dl=0");
                break;
            case "9":
                await DownloadAndInstall("Rockstar Launcher", "RockstarLauncherSetup.exe", "https://gamedownloads.rockstargames.com/public/installer/Rockstar-Games-Launcher.exe");
                break;
            case "10":
                Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                await Task.Delay(3000); // Add a delay of 3 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }

    private static async Task DownloadAndInstall(string appName, string fileName, string downloadUrl)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(downloadUrl))
            {
                using (HttpContent content = response.Content)
                {
                    using (Stream stream = await content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.Content.Headers.ContentLength ?? -1;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;

                                if (totalBytes > 0)
                                {
                                    int progress = (int)((totalBytesRead * 100) / totalBytes);
                                    Console.Write($"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"\n{appName} was downloaded successfully!");
        Process? installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

        if (installerProcess != null && !installerProcess.HasExited)
        {
            Console.WriteLine("Installing...");
            installerProcess.WaitForExit();

            if (installerProcess.ExitCode == 0)
            {
                Console.WriteLine("Installation was concluded with success!");
                Console.Clear();
                File.Delete(saveLocation); // Delete the setup file
            }
            else
            {
                Console.WriteLine("Installation has failed!");
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

