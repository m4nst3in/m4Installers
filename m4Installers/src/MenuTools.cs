using System.Diagnostics;


class MenuTools
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Tools \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - WinRAR");
        Console.WriteLine("[2] - 7zip");
        Console.WriteLine("[3] - AIDA64");
        Console.WriteLine("[4] - CPU-Z");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string winrarUrl = "https://www.win-rar.com/fileadmin/winrar-versions/winrar/winrar-x64-701.exe";
                string winrarSaveLocation = "C:\\m4Installers\\WinRARSetup.exe";
                Console.WriteLine("Downloading WinRAR...");

                // Download WinRAR installer
                using (HttpClient winrarClient = new HttpClient())
                {
                    using (HttpResponseMessage winrarResponse = winrarClient.GetAsync(winrarUrl).Result)
                    {
                        using (HttpContent winrarContent = winrarResponse.Content)
                        {
                            using (Stream winrarStream = winrarContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream winrarFileStream = new FileStream(winrarSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] winrarBuffer = new byte[1024];
                                    int winrarBytesRead;
                                    long winrarTotalBytesRead = 0;
                                    long winrarTotalBytes = winrarResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((winrarBytesRead = winrarStream.Read(winrarBuffer, 0, winrarBuffer.Length)) > 0)
                                    {
                                        winrarFileStream.Write(winrarBuffer, 0, winrarBytesRead);
                                        winrarTotalBytesRead += winrarBytesRead;

                                        if (winrarTotalBytes > 0)
                                        {
                                            int winrarProgress = (int)((winrarTotalBytesRead * 100) / winrarTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {winrarProgress}% ({winrarTotalBytesRead / 1024} KB of {winrarTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nWinRAR was downloaded successfully!");
                Process winrarInstallerProcess = Process.Start(new ProcessStartInfo(winrarSaveLocation) { UseShellExecute = true });

                if (winrarInstallerProcess != null && !winrarInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    winrarInstallerProcess.WaitForExit();

                    if (winrarInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(winrarSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "2":
                Console.Clear();
                string sevenZipUrl = "https://www.7-zip.org/a/7z2407-x64.exe";
                string sevenZipSaveLocation = "C:\\m4Installers\\7zipSetup.exe";
                Console.WriteLine("Downloading 7zip...");

                // Download 7zip installer
                using (HttpClient sevenZipClient = new HttpClient())
                {
                    using (HttpResponseMessage sevenZipResponse = sevenZipClient.GetAsync(sevenZipUrl).Result)
                    {
                        using (HttpContent sevenZipContent = sevenZipResponse.Content)
                        {
                            using (Stream sevenZipStream = sevenZipContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream sevenZipFileStream = new FileStream(sevenZipSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] sevenZipBuffer = new byte[1024];
                                    int sevenZipBytesRead;
                                    long sevenZipTotalBytesRead = 0;
                                    long sevenZipTotalBytes = sevenZipResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((sevenZipBytesRead = sevenZipStream.Read(sevenZipBuffer, 0, sevenZipBuffer.Length)) > 0)
                                    {
                                        sevenZipFileStream.Write(sevenZipBuffer, 0, sevenZipBytesRead);
                                        sevenZipTotalBytesRead += sevenZipBytesRead;

                                        if (sevenZipTotalBytes > 0)
                                        {
                                            int sevenZipProgress = (int)((sevenZipTotalBytesRead * 100) / sevenZipTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {sevenZipProgress}% ({sevenZipTotalBytesRead / 1024} KB of {sevenZipTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\n7zip was downloaded successfully!");
                Process sevenZipInstallerProcess = Process.Start(new ProcessStartInfo(sevenZipSaveLocation) { UseShellExecute = true });

                if (sevenZipInstallerProcess != null && !sevenZipInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    sevenZipInstallerProcess.WaitForExit();

                    if (sevenZipInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(sevenZipSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "3":
                Console.Clear();
                string aida64Url = "https://download2.aida64.com/aida64extreme730.exe";
                string aida64SaveLocation = "C:\\m4Installers\\AIDA64Setup.exe";
                Console.WriteLine("Downloading AIDA64...");

                // Download AIDA64 installer
                using (HttpClient aida64Client = new HttpClient())
                {
                    using (HttpResponseMessage aida64Response = aida64Client.GetAsync(aida64Url).Result)
                    {
                        using (HttpContent aida64Content = aida64Response.Content)
                        {
                            using (Stream aida64Stream = aida64Content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream aida64FileStream = new FileStream(aida64SaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] aida64Buffer = new byte[1024];
                                    int aida64BytesRead;
                                    long aida64TotalBytesRead = 0;
                                    long aida64TotalBytes = aida64Response.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((aida64BytesRead = aida64Stream.Read(aida64Buffer, 0, aida64Buffer.Length)) > 0)
                                    {
                                        aida64FileStream.Write(aida64Buffer, 0, aida64BytesRead);
                                        aida64TotalBytesRead += aida64BytesRead;

                                        if (aida64TotalBytes > 0)
                                        {
                                            int aida64Progress = (int)((aida64TotalBytesRead * 100) / aida64TotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {aida64Progress}% ({aida64TotalBytesRead / 1024} KB of {aida64TotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nAIDA64 was downloaded successfully!");
                Process aida64InstallerProcess = Process.Start(new ProcessStartInfo(aida64SaveLocation) { UseShellExecute = true });

                if (aida64InstallerProcess != null && !aida64InstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    aida64InstallerProcess.WaitForExit();

                    if (aida64InstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(aida64SaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "4":
                Console.Clear();
                string cpuZUrl = "https://download.cpuid.com/cpu-z/cpu-z_1.79-en.exe";
                string cpuZSaveLocation = "C:\\m4Installers\\CPUZSetup.exe";
                Console.WriteLine("Downloading CPU-Z...");

                // Download CPU-Z installer
                using (HttpClient cpuZClient = new HttpClient())
                {
                    using (HttpResponseMessage cpuZResponse = cpuZClient.GetAsync(cpuZUrl).Result)
                    {
                        using (HttpContent cpuZContent = cpuZResponse.Content)
                        {
                            using (Stream cpuZStream = cpuZContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream cpuZFileStream = new FileStream(cpuZSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] cpuZBuffer = new byte[1024];
                                    int cpuZBytesRead;
                                    long cpuZTotalBytesRead = 0;
                                    long cpuZTotalBytes = cpuZResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((cpuZBytesRead = cpuZStream.Read(cpuZBuffer, 0, cpuZBuffer.Length)) > 0)
                                    {
                                        cpuZFileStream.Write(cpuZBuffer, 0, cpuZBytesRead);
                                        cpuZTotalBytesRead += cpuZBytesRead;

                                        if (cpuZTotalBytes > 0)
                                        {
                                            int cpuZProgress = (int)((cpuZTotalBytesRead * 100) / cpuZTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {cpuZProgress}% ({cpuZTotalBytesRead / 1024} KB of {cpuZTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nCPU-Z was downloaded successfully!");
                Process cpuZInstallerProcess = Process.Start(new ProcessStartInfo(cpuZSaveLocation) { UseShellExecute = true });

                if (cpuZInstallerProcess != null && !cpuZInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    cpuZInstallerProcess.WaitForExit();

                    if (cpuZInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(cpuZSaveLocation); // Delete the setup file
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
                Console.WriteLine("Invalid option. Try again.");
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
