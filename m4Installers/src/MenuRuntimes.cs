using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

class MenuRuntimes
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Runtimes \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - AllinOne Runtimes");
        Console.WriteLine("[2] - .NET Framework");
        Console.WriteLine("[3] - Visual C++");
        Console.WriteLine("[4] - DirectX");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        if (option == "1")
        {
            string url =
                "https://media.computerbase.de/s/GMGpZJyVj9vYs5IosY2y_w/1720764360/download/758/aio-runtimes_v2.5.0.exe";
            string saveLocation = "C:\\m4Installers\\AIOSetup.exe";
            Console.WriteLine("Downloading AllinOne Runtimes...");
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

            Console.WriteLine("\nAllinOne Runtimes was downloaded succesfully!");
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
            string url = "https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-offline-installer";
            string saveLocation = "C:\\m4Installers\\Net481Setup.exe";
            Console.WriteLine("Downloading .NET Framework...");
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

            Console.WriteLine("\n.NET Framework was downloaded successfully!");
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
            string url = "https://aka.ms/vs/17/release/vc_redist.x64.exe";
            string saveLocation = "C:\\m4Installers\\VcRedistSetup.exe";
            Console.WriteLine("Downloading Visual C++ Redist...");
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

            Console.WriteLine("\nVisual C++ was downloaded succesfully!");
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
                "https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe";
            string saveLocation = "C:\\m4Installers\\DXWebSetup.exe";
            Console.WriteLine("Downloading DirectX...");
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

            Console.WriteLine("\nDirectX was downloaded succesfully!");
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
            Thread.Sleep(2500); // Add a delay of 2.5 seconds
            Console.Clear();
            ShowMenu();
        }
    }
}
