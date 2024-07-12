using System.Diagnostics;
class MenuDocuments
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"


 ____                                        _       
|  _ \  ___   ___ _   _ _ __ ___   ___ _ __ | |_ ___ 
| | | |/ _ \ / __| | | | '_ ` _ \ / _ \ '_ \| __/ __|
| |_| | (_) | (__| |_| | | | | | |  __/ | | | |_\__ \
|____/ \___/ \___|\__,_|_| |_| |_|\___|_| |_|\__|___/




");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - OpenOffice ");
        Console.WriteLine("[2] - LibreOffice Writer ");
        Console.WriteLine("[3] - WPS Office ");
        Console.WriteLine("[4] - Obsidian ");
        Console.WriteLine("[5] - Return to Main Menu ");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string openOfficeUrl = "https://sourceforge.net/projects/openofficeorg.mirror/files/4.1.15/binaries/pt-BR/Apache_OpenOffice_4.1.15_Win_x86_install_pt-BR.exe/download";
                string openOfficeSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "OpenOfficeSetup.exe");
                Console.WriteLine("Downloading OpenOffice...");

                // Download OpenOffice installer
                using (HttpClient openOfficeClient = new HttpClient())
                {
                    using (HttpResponseMessage openOfficeResponse = openOfficeClient.GetAsync(openOfficeUrl).Result)
                    {
                        using (HttpContent openOfficeContent = openOfficeResponse.Content)
                        {
                            using (Stream openOfficeStream = openOfficeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream openOfficeFileStream = new FileStream(openOfficeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] openOfficeBuffer = new byte[1024];
                                    int openOfficeBytesRead;
                                    long openOfficeTotalBytesRead = 0;
                                    long openOfficeTotalBytes = openOfficeResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write OpenOffice installer file
                                    while ((openOfficeBytesRead = openOfficeStream.Read(openOfficeBuffer, 0, openOfficeBuffer.Length)) > 0)
                                    {
                                        openOfficeFileStream.Write(openOfficeBuffer, 0, openOfficeBytesRead);
                                        openOfficeTotalBytesRead += openOfficeBytesRead;

                                        if (openOfficeTotalBytes > 0)
                                        {
                                            int openOfficeProgress = (int)((openOfficeTotalBytesRead * 100) / openOfficeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {openOfficeProgress}% ({openOfficeTotalBytesRead / 1024} KB of {openOfficeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOpenOffice was downloaded successfully!");
                Process openOfficeInstallerProcess = Process.Start(new ProcessStartInfo(openOfficeSaveLocation) { UseShellExecute = true });

                if (openOfficeInstallerProcess != null && !openOfficeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    openOfficeInstallerProcess.WaitForExit();

                    if (openOfficeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(openOfficeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(openOfficeSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "2":
                Console.Clear();
                string libreOfficeUrl = "https://www.libreoffice.org/download/download/";
                string libreOfficeSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "LibreOfficeSetup.exe");
                Console.WriteLine("Downloading LibreOffice Writer...");

                // Download LibreOffice Writer installer
                using (HttpClient libreOfficeClient = new HttpClient())
                {
                    using (HttpResponseMessage libreOfficeResponse = libreOfficeClient.GetAsync(libreOfficeUrl).Result)
                    {
                        using (HttpContent libreOfficeContent = libreOfficeResponse.Content)
                        {
                            using (Stream libreOfficeStream = libreOfficeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream libreOfficeFileStream = new FileStream(libreOfficeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] libreOfficeBuffer = new byte[1024];
                                    int libreOfficeBytesRead;
                                    long libreOfficeTotalBytesRead = 0;
                                    long libreOfficeTotalBytes = libreOfficeResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write LibreOffice Writer installer file
                                    while ((libreOfficeBytesRead = libreOfficeStream.Read(libreOfficeBuffer, 0, libreOfficeBuffer.Length)) > 0)
                                    {
                                        libreOfficeFileStream.Write(libreOfficeBuffer, 0, libreOfficeBytesRead);
                                        libreOfficeTotalBytesRead += libreOfficeBytesRead;

                                        if (libreOfficeTotalBytes > 0)
                                        {
                                            int libreOfficeProgress = (int)((libreOfficeTotalBytesRead * 100) / libreOfficeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {libreOfficeProgress}% ({libreOfficeTotalBytesRead / 1024} KB of {libreOfficeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nLibreOffice Writer was downloaded successfully!");
                Process libreOfficeInstallerProcess = Process.Start(new ProcessStartInfo(libreOfficeSaveLocation) { UseShellExecute = true });

                if (libreOfficeInstallerProcess != null && !libreOfficeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    libreOfficeInstallerProcess.WaitForExit();

                    if (libreOfficeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(libreOfficeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(libreOfficeSaveLocation); // Delete the setup file

                    }
                }
                break;
            case "3":
                Console.Clear();
                string wpsOfficeUrl = "https://www.wps.com/office-free";
                string wpsOfficeSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "WPSOfficeSetup.exe");
                Console.WriteLine("Downloading WPS Office...");

                // Download WPS Office installer
                using (HttpClient wpsOfficeClient = new HttpClient())
                {
                    using (HttpResponseMessage wpsOfficeResponse = wpsOfficeClient.GetAsync(wpsOfficeUrl).Result)
                    {
                        using (HttpContent wpsOfficeContent = wpsOfficeResponse.Content)
                        {
                            using (Stream wpsOfficeStream = wpsOfficeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream wpsOfficeFileStream = new FileStream(wpsOfficeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] wpsOfficeBuffer = new byte[1024];
                                    int wpsOfficeBytesRead;
                                    long wpsOfficeTotalBytesRead = 0;
                                    long wpsOfficeTotalBytes = wpsOfficeResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write WPS Office installer file
                                    while ((wpsOfficeBytesRead = wpsOfficeStream.Read(wpsOfficeBuffer, 0, wpsOfficeBuffer.Length)) > 0)
                                    {
                                        wpsOfficeFileStream.Write(wpsOfficeBuffer, 0, wpsOfficeBytesRead);
                                        wpsOfficeTotalBytesRead += wpsOfficeBytesRead;

                                        if (wpsOfficeTotalBytes > 0)
                                        {
                                            int wpsOfficeProgress = (int)((wpsOfficeTotalBytesRead * 100) / wpsOfficeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {wpsOfficeProgress}% ({wpsOfficeTotalBytesRead / 1024} KB of {wpsOfficeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nWPS Office was downloaded successfully!");
                Process wpsOfficeInstallerProcess = Process.Start(new ProcessStartInfo(wpsOfficeSaveLocation) { UseShellExecute = true });

                if (wpsOfficeInstallerProcess != null && !wpsOfficeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    wpsOfficeInstallerProcess.WaitForExit();

                    if (wpsOfficeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(wpsOfficeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(wpsOfficeSaveLocation); // Delete the setup file
                    }
                }
                break;
            case "4":
                Console.Clear();
                string obsidianUrl = "https://github.com/obsidianmd/obsidian-releases/releases/download/v1.6.5/Obsidian-1.6.5.exe";
                string obsidianSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "ObsidianSetup.exe");
                Console.WriteLine("Downloading Obsidian (Vault)...");

                // Download Obsidian installer
                using (HttpClient obsidianClient = new HttpClient())
                {
                    using (HttpResponseMessage obsidianResponse = obsidianClient.GetAsync(obsidianUrl).Result)
                    {
                        using (HttpContent obsidianContent = obsidianResponse.Content)
                        {
                            using (Stream obsidianStream = obsidianContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream obsidianFileStream = new FileStream(obsidianSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] obsidianBuffer = new byte[1024];
                                    int obsidianBytesRead;
                                    long obsidianTotalBytesRead = 0;
                                    long obsidianTotalBytes = obsidianResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Obsidian installer file
                                    while ((obsidianBytesRead = obsidianStream.Read(obsidianBuffer, 0, obsidianBuffer.Length)) > 0)
                                    {
                                        obsidianFileStream.Write(obsidianBuffer, 0, obsidianBytesRead);
                                        obsidianTotalBytesRead += obsidianBytesRead;

                                        if (obsidianTotalBytes > 0)
                                        {
                                            int obsidianProgress = (int)((obsidianTotalBytesRead * 100) / obsidianTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {obsidianProgress}% ({obsidianTotalBytesRead / 1024} KB of {obsidianTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nObsidian (Vault) was downloaded successfully!");
                Process obsidianInstallerProcess = Process.Start(new ProcessStartInfo(obsidianSaveLocation) { UseShellExecute = true });

                if (obsidianInstallerProcess != null && !obsidianInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    obsidianInstallerProcess.WaitForExit();

                    if (obsidianInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(obsidianSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(obsidianSaveLocation); // Delete the setup file
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
