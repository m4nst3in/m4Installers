using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

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

        if (option == "1")
        {
            string url =
                "https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe";
            string saveLocation = "C:\\m4Installers\\SteamSetup.exe";
            Console.WriteLine("Downloading Steam...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nSteam was downloaded succesfully!");
            Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

            if (installerProcess != null && !installerProcess.HasExited)
            {
                Console.WriteLine("Installing...");

                // Wait until installation process has finished
                installerProcess.WaitForExit();

                if (installerProcess.ExitCode == 0)
                {
                    Console.WriteLine("Installation was concluded with success!");
                    Console.Clear();
                }
            }
        }
        else if (option == "2")
        {
            string url = "https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi";
            string saveLocation = "C:\\m4Installers\\EGSSetup.exe";
            Console.WriteLine("Downloading Epic Games Launcher...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nEpic Games Launcher was downloaded successfully!");
            Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

            if (installerProcess != null && !installerProcess.HasExited)
            {
                Console.WriteLine("Installing...");

                // Wait until installation process has finished
                installerProcess.WaitForExit();

                if (installerProcess.ExitCode == 0)
                {
                    Console.WriteLine("Installation was concluded with success!");
                    Console.Clear();
                }
            }
        }
        else if (option == "3")
        {
            string url = "https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe";
            string saveLocation = "C:\\m4Installers\\OriginSetup.exe";
            Console.WriteLine("Downloading EA App...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nOrigin was downloaded succesfully!");
            Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

            if (installerProcess != null && !installerProcess.HasExited)
            {
                Console.WriteLine("Installing...");

                // Wait until installation process has finished
                installerProcess.WaitForExit();

                if (installerProcess.ExitCode == 0)
                {
                    Console.WriteLine("Installation was concluded with success!");
                    Console.Clear();
                }
            }
        }
        else if (option == "4")
        {
            string url =
                "https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe";
            string saveLocation = "C:\\m4Installers\\GOGSetup.exe";
            Console.WriteLine("Downloading GOG Galaxy...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nGOG Galaxy was downloaded succesfully!");
            Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

            if (installerProcess != null && !installerProcess.HasExited)
            {
                Console.WriteLine("Installing...");

                // Wait until installation process has finished
                installerProcess.WaitForExit();

                if (installerProcess.ExitCode == 0)
                {
                    Console.WriteLine("Installation was concluded with success!");
                    Console.Clear();
                }
            }
        }
        else if (option == "5")
        {
            Installers.ReturnToMainMenu();
        }
        else
        {
            Console.WriteLine("Invalid option. Try it again.");
            Thread.Sleep(3000); // Add a delay of 2 seconds
            Console.Clear();
            ShowMenu();
        }
    }
}
