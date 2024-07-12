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
                Console.Clear();
                string allinoneurl =
                    "https://media.computerbase.de/s/GMGpZJyVj9vYs5IosY2y_w/1720764360/download/758/aio-runtimes_v2.5.0.exe";
                string allinoneSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "AIOSetup.exe"); ;
                Console.WriteLine("Downloading AllinOne Runtimes...");

                // Download AllinOne Runtimes
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
                        File.Delete(allinoneSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(allinoneSaveLocation);
                    }
                }
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Choose the version of .NET Framework to install:");
                Console.WriteLine("[1] - .NET Framework 4.5.1");
                Console.WriteLine("[2] - .NET Framework 4.6.1");
                Console.WriteLine("[3] - .NET Framework 4.8.1");
                Console.WriteLine("[4] - Return to main menu");

                string dotnetVersionOption = Console.ReadLine();
                string dotneturl = "";
                string dotnetSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "DotNetSetup.exe");

                switch (dotnetVersionOption)
                {
                    case "1":
                        dotneturl = "https://download.microsoft.com/download/1/6/7/167F0D79-9317-48AE-AEDB-17120579F8E2/NDP451-KB2858728-x86-x64-AllOS-ENU.exe";
                        break;
                    case "2":
                        dotneturl = "https://download.microsoft.com/download/E/4/1/E4173890-A24A-4936-9FC9-AF930FE3FA40/NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
                        break;
                    case "3":
                        dotneturl = "https://download.microsoft.com/download/4/b/2/cd00d4ed-ebdd-49ee-8a33-eabc3d1030e3/NDP481-x86-x64-AllOS-ENU.exe";
                        break;
                    case "4":
                        Console.Clear();
                        ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try it again.");
                        System.Threading.Thread.Sleep(2500);
                        Console.Clear();
                        ShowMenu();
                        return;
                }
                Console.WriteLine("Downloading .NET Framework...");

                // Download .NET Framework
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
                        File.Delete(dotnetSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(dotnetSaveLocation);
                    }
                }
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Choose the version of Visual C++ Redistributable to install:");
                Console.WriteLine("[1] - Visual C++ Redistributable 15-17-19-22 x64");
                Console.WriteLine("[2] - Visual C++ Redistributable 15-17-19-22 x86");
                Console.WriteLine("[3] - Return to main menu");

                string vcVersionOption = Console.ReadLine();
                string vcUrl = "";

                switch (vcVersionOption)
                {
                    case "1":
                        vcUrl = "https://aka.ms/vs/17/release/vc_redist.x64.exe";
                        break;
                    case "2":
                        vcUrl = "https://aka.ms/vs/17/release/vc_redist.x86.exe";
                        break;
                    case "3":
                        Console.Clear();
                        ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try it again.");
                        System.Threading.Thread.Sleep(2500);
                        Console.Clear();
                        ShowMenu();
                        return;
                }

                string vcSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "VCRSetup.exe"); ;
                Console.WriteLine("Downloading Visual C++ Redistributable...");

                // Download Visual C++ Redistributable
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(vcUrl).Result)
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
                                                $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nVisual C++ Redistributable was downloaded successfully!");
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
                        File.Delete(vcSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(vcSaveLocation);
                    }
                }
                break;

            case "4":
                Console.Clear();
                string dxurl =
                    "https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe";
                string dxSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "DXWebSetup.exe"); ;
                Console.WriteLine("Downloading DirectX...");

                // Download DirectX
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
                        File.Delete(dxSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(dxSaveLocation);
                    }
                }
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");

                // Add a delay of 2.5 seconds
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
