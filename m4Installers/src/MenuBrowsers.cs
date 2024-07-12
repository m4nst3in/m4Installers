using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

class MenuBrowsers
{
    public static void ShowMenu()
    {
        Console.WriteLine("Browsers");
        Console.WriteLine("[1] - Brave");
        Console.WriteLine("[2] - Firefox");
        Console.WriteLine("[3] - Vivaldi");
        Console.WriteLine("[4] - Opera GX");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        if (option == "1")
        {
            string url =
                "https://github.com/brave/brave-browser/releases/download/v1.67.123/BraveBrowserStandaloneSetup.exe";
            string saveLocation = "C:\\m4Installers\\BraveSetup.exe";
            Console.WriteLine("Downloading Brave...");
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

            Console.WriteLine("\nBrave was downloaded succesfully!");
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
            string url = "https://download.mozilla.org/?product=firefox-latest&os=win64";
            string saveLocation = "C:\\m4Installers\\FirefoxSetup.exe";
            Console.WriteLine("Downloading Firefox...");
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

            Console.WriteLine("\nFirefox was downloaded succesfully!");
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
            string url = "https://downloads.vivaldi.com/stable/Vivaldi.6.8.3381.46.x64.exe";
            string saveLocation = "C:\\m4Installers\\VivaldiSetup.exe";
            Console.WriteLine("Downloading Vivaldi...");
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

            Console.WriteLine("\nVivaldi was downloaded succesfully!");
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
                "https://download3.operacdn.com/pub/opera_gx/100.0.4815.44/win/Opera_GX_100.0.4815.44_Setup_x64.exe";
            string saveLocation = "C:\\m4Installers\\OperaGXSetup.exe";
            Console.WriteLine("Downloading OperaGX...");
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

            Console.WriteLine("\nOperaGX was downloaded succesfully!");
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
