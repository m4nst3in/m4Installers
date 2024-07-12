﻿using System.Diagnostics;

class MenuClients
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Game Clients \n");
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
                string steamUrl = "https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe";
                string steamSaveLocation = "C:\\m4Installers\\SteamSetup.exe";
                Console.WriteLine("Downloading Steam...");
                using (HttpClient steamClient = new HttpClient())
                {
                    using (HttpResponseMessage steamResponse = steamClient.GetAsync(steamUrl).Result)
                    {
                        using (HttpContent steamContent = steamResponse.Content)
                        {
                            using (Stream steamStream = steamContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream steamFileStream = new FileStream(steamSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] steamBuffer = new byte[1024];
                                    int steamBytesRead;
                                    long steamTotalBytesRead = 0;
                                    long steamTotalBytes = steamResponse.Content.Headers.ContentLength ?? -1;

                                    while ((steamBytesRead = steamStream.Read(steamBuffer, 0, steamBuffer.Length)) > 0)
                                    {
                                        steamFileStream.Write(steamBuffer, 0, steamBytesRead);
                                        steamTotalBytesRead += steamBytesRead;

                                        if (steamTotalBytes > 0)
                                        {
                                            int steamProgress = (int)((steamTotalBytesRead * 100) / steamTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {steamProgress}% ({steamTotalBytesRead / 1024} KB de {steamTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nSteam was downloaded succesfully!");
                Process steamInstallerProcess = Process.Start(new ProcessStartInfo(steamSaveLocation) { UseShellExecute = true });

                if (steamInstallerProcess != null && !steamInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    steamInstallerProcess.WaitForExit();

                    if (steamInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "2":
                string epicUrl = "https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi";
                string epicSaveLocation = "C:\\m4Installers\\EGSSetup.msi";
                Console.WriteLine("Downloading Epic Games Launcher...");
                using (HttpClient epicClient = new HttpClient())
                {
                    using (HttpResponseMessage epicResponse = epicClient.GetAsync(epicUrl).Result)
                    {
                        using (HttpContent epicContent = epicResponse.Content)
                        {
                            using (Stream epicStream = epicContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream epicFileStream = new FileStream(epicSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] epicBuffer = new byte[1024];
                                    int epicBytesRead;
                                    long epicTotalBytesRead = 0;
                                    long epicTotalBytes = epicResponse.Content.Headers.ContentLength ?? -1;

                                    while ((epicBytesRead = epicStream.Read(epicBuffer, 0, epicBuffer.Length)) > 0)
                                    {
                                        epicFileStream.Write(epicBuffer, 0, epicBytesRead);
                                        epicTotalBytesRead += epicBytesRead;

                                        if (epicTotalBytes > 0)
                                        {
                                            int epicProgress = (int)((epicTotalBytesRead * 100) / epicTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {epicProgress}% ({epicTotalBytesRead / 1024} KB de {epicTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nEpic Games Launcher was downloaded successfully!");
                Process epicInstallerProcess = Process.Start(new ProcessStartInfo(epicSaveLocation) { UseShellExecute = true });

                if (epicInstallerProcess != null && !epicInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    epicInstallerProcess.WaitForExit();

                    if (epicInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "3":
                string originUrl = "https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe";
                string originSaveLocation = "C:\\m4Installers\\OriginSetup.exe";
                Console.WriteLine("Downloading EA App...");
                using (HttpClient originClient = new HttpClient())
                {
                    using (HttpResponseMessage originResponse = originClient.GetAsync(originUrl).Result)
                    {
                        using (HttpContent originContent = originResponse.Content)
                        {
                            using (Stream originStream = originContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream originFileStream = new FileStream(originSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] originBuffer = new byte[1024];
                                    int originBytesRead;
                                    long originTotalBytesRead = 0;
                                    long originTotalBytes = originResponse.Content.Headers.ContentLength ?? -1;

                                    while ((originBytesRead = originStream.Read(originBuffer, 0, originBuffer.Length)) > 0)
                                    {
                                        originFileStream.Write(originBuffer, 0, originBytesRead);
                                        originTotalBytesRead += originBytesRead;

                                        if (originTotalBytes > 0)
                                        {
                                            int originProgress = (int)((originTotalBytesRead * 100) / originTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {originProgress}% ({originTotalBytesRead / 1024} KB de {originTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOrigin was downloaded succesfully!");
                Process originInstallerProcess = Process.Start(new ProcessStartInfo(originSaveLocation) { UseShellExecute = true });

                if (originInstallerProcess != null && !originInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    originInstallerProcess.WaitForExit();

                    if (originInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "4":
                string gogUrl = "https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe";
                string gogSaveLocation = "C:\\m4Installers\\GOGSetup.exe";
                Console.WriteLine("Downloading GOG Galaxy...");
                using (HttpClient gogClient = new HttpClient())
                {
                    using (HttpResponseMessage gogResponse = gogClient.GetAsync(gogUrl).Result)
                    {
                        using (HttpContent gogContent = gogResponse.Content)
                        {
                            using (Stream gogStream = gogContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream gogFileStream = new FileStream(gogSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] gogBuffer = new byte[1024];
                                    int gogBytesRead;
                                    long gogTotalBytesRead = 0;
                                    long gogTotalBytes = gogResponse.Content.Headers.ContentLength ?? -1;

                                    while ((gogBytesRead = gogStream.Read(gogBuffer, 0, gogBuffer.Length)) > 0)
                                    {
                                        gogFileStream.Write(gogBuffer, 0, gogBytesRead);
                                        gogTotalBytesRead += gogBytesRead;

                                        if (gogTotalBytes > 0)
                                        {
                                            int gogProgress = (int)((gogTotalBytesRead * 100) / gogTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {gogProgress}% ({gogTotalBytesRead / 1024} KB de {gogTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGOG Galaxy was downloaded succesfully!");
                Process gogInstallerProcess = Process.Start(new ProcessStartInfo(gogSaveLocation) { UseShellExecute = true });

                if (gogInstallerProcess != null && !gogInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    gogInstallerProcess.WaitForExit();

                    if (gogInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(3000); // Add a delay of 2 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
