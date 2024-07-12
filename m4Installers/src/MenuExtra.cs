using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

class MenuExtra
{
    public static void ShowMenu()
    {
        Console.WriteLine("Extra");
        Console.WriteLine("[1] - Discord");
        Console.WriteLine("[2] - Telegram");
        Console.WriteLine("[3] - GitHub Desktop");
        Console.WriteLine("[4] - Paint.NET");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        if (option == "1")
        {
            string url =
                "https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64";
            string saveLocation = "C:\\m4Installers\\DiscordSetup.exe";
            Console.WriteLine("Downloading Discord...");
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

            Console.WriteLine("\nDiscord was downloaded succesfully!");
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
            string url = "https://telegram.org/dl/desktop/win64";
            string saveLocation = "C:\\m4Installers\\TelegramSetup.exe";
            Console.WriteLine("Downloading Telegram...");
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

            Console.WriteLine("\nTelegram was downloaded successfully!");
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
            string url = "https://central.github.com/deployments/desktop/desktop/latest/win32";
            string saveLocation = "C:\\m4Installers\\GitHubSetup.exe";
            Console.WriteLine("Downloading GitHub Desktop...");
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

            Console.WriteLine("\nGitHub Desktop was downloaded succesfully!");
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
                "https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip";
            string saveLocation = "C:\\m4Installers\\PaintNETSetup.exe";
            Console.WriteLine("Downloading Paint.NET...");
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

            Console.WriteLine("\nPaint.NET was downloaded succesfully!");
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
        }
    }
}
