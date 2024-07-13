﻿using System.Diagnostics;

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
                await DownloadAndInstall("https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe", "SteamSetup.exe", "Steam");
                break;
            case "2":
                await DownloadAndInstall("https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi", "EGSSetup.msi", "Epic Games Launcher");
                break;
            case "3":
                await DownloadAndInstall("https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe", "OriginSetup.exe", "EA App");
                break;
            case "4":
                await DownloadAndInstall("https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe", "GOGSetup.exe", "GOG Galaxy");
                break;
            case "5":
                await DownloadAndInstall("https://ubi.li/4vxt9", "UbiConnectSetup.exe", "Ubisoft Connect");
                break;
            case "6":
                await DownloadAndInstall("https://downloader.battle.net//download/getInstallerForGame?os=win&gameProgram=BATTLENET_APP&version=Live", "BattleNetSetup.exe", "Battle.net");
                break;
            case "7":
                await DownloadAndInstall("https://assets.xbox.com/installer/20190628.8/anycpu/XboxInstaller.exe", "XboxAppSetup.exe", "Xbox App");
                break;
            case "8":
                await DownloadAndInstall("https://www.dropbox.com/scl/fi/xz9f99o403o2i00gxdci7/itch-setup.exe?rlkey=5ri0faw8hr22qoykqvvscjhsr&st=wov1z2d6&dl=0", "ItchIOSetup.exe", "Itch.io");
                break;
            case "9":
                await DownloadAndInstall("https://gamedownloads.rockstargames.com/public/installer/Rockstar-Games-Launcher.exe", "RockstarLauncherSetup.exe", "Rockstar Launcher");
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

    private static async Task DownloadAndInstall(string downloadUrl, string fileName, string clientName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {clientName}...");

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

        Console.WriteLine($"\n{clientName} was downloaded successfully!");
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
            Console.WriteLine($"Failed to download {clientName}. Please try again later.");
        }
    }
}

