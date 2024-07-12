using System.Diagnostics;

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

        switch (option)
        {
            case "1":
                string allinoneurl =
                    "https://media.computerbase.de/s/GMGpZJyVj9vYs5IosY2y_w/1720764360/download/758/aio-runtimes_v2.5.0.exe";
                string allinoneSaveLocation = "C:\\m4Installers\\AIOSetup.exe";
                Console.WriteLine("Downloading AllinOne Runtimes...");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(allinoneurl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(allinoneSaveLocation, FileMode.Create,
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
                Process allinoneInstallerProcess = Process.Start(new ProcessStartInfo(allinoneSaveLocation) { UseShellExecute = true });

                if (allinoneInstallerProcess != null && !allinoneInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    allinoneInstallerProcess.WaitForExit();

                    if (allinoneInstallerProcess.ExitCode == 0)
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
                string dotneturl = "https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-offline-installer";
                string dotnetSaveLocation = "C:\\m4Installers\\Net481Setup.exe";
                Console.WriteLine("Downloading .NET Framework...");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(dotneturl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(dotnetSaveLocation, FileMode.Create,
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
                Process dotnetInstallerProcess = Process.Start(new ProcessStartInfo(dotnetSaveLocation) { UseShellExecute = true });

                if (dotnetInstallerProcess != null && !dotnetInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    dotnetInstallerProcess.WaitForExit();

                    if (dotnetInstallerProcess.ExitCode == 0)
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
                string vcurl = "https://aka.ms/vs/17/release/vc_redist.x64.exe";
                string vcSaveLocation = "C:\\m4Installers\\VcRedistSetup.exe";
                Console.WriteLine("Downloading Visual C++ Redist...");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(vcurl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(vcSaveLocation, FileMode.Create,
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
                Process vcInstallerProcess = Process.Start(new ProcessStartInfo(vcSaveLocation) { UseShellExecute = true });

                if (vcInstallerProcess != null && !vcInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    vcInstallerProcess.WaitForExit();

                    if (vcInstallerProcess.ExitCode == 0)
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
                string dxurl =
                    "https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe";
                string dxSaveLocation = "C:\\m4Installers\\DXWebSetup.exe";
                Console.WriteLine("Downloading DirectX...");
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(dxurl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(dxSaveLocation, FileMode.Create,
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
                Process dxInstallerProcess = Process.Start(new ProcessStartInfo(dxSaveLocation) { UseShellExecute = true });

                if (dxInstallerProcess != null && !dxInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    dxInstallerProcess.WaitForExit();

                    if (dxInstallerProcess.ExitCode == 0)
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
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
