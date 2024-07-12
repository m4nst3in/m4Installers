using System.Diagnostics;

class MenuUtilities
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _   _ _   _ _ _ _   _           
| | | | |_(_) (_) |_(_) ___  ___ 
| | | | __| | | | __| |/ _ \/ __|
| |_| | |_| | | | |_| |  __/\__ \
 \___/ \__|_|_|_|\__|_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - CCleaner");
        Console.WriteLine("[2] - PuTTY");
        Console.WriteLine("[3] - Filezilla");
        Console.WriteLine("[4] - Recuva");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string ccleanerUrl =
                    "https://www.dropbox.com/scl/fi/5ytqjerss5wpmi2mz48vf/ccsetup625.exe?rlkey=rnr3b0r4pvwpoxbchlitw267s&st=ks9kk1lv&dl=1";
                string ccleanerSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "CCleanerSetup.exe"); ;
                Console.WriteLine("Downloading CCleaner...");

                // Download ccleaner installer
                using (HttpClient ccleanerClient = new HttpClient())
                {
                    using (HttpResponseMessage ccleanerResponse = ccleanerClient.GetAsync(ccleanerUrl).Result)
                    {
                        using (HttpContent ccleanerContent = ccleanerResponse.Content)
                        {
                            using (Stream ccleanerStream = ccleanerContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream ccleanerFileStream = new FileStream(ccleanerSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] ccleanerBuffer = new byte[1024];
                                    int ccleanerBytesRead;
                                    long ccleanerTotalBytesRead = 0;
                                    long ccleanerTotalBytes = ccleanerResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write ccleaner installer file
                                    while ((ccleanerBytesRead = ccleanerStream.Read(ccleanerBuffer, 0, ccleanerBuffer.Length)) > 0)
                                    {
                                        ccleanerFileStream.Write(ccleanerBuffer, 0, ccleanerBytesRead);
                                        ccleanerTotalBytesRead += ccleanerBytesRead;

                                        if (ccleanerTotalBytes > 0)
                                        {
                                            int ccleanerProgress = (int)((ccleanerTotalBytesRead * 100) / ccleanerTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {ccleanerProgress}% ({ccleanerTotalBytesRead / 1024} KB of {ccleanerTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nCCleaner was downloaded successfully!");
                Process ccleanerInstallerProcess = Process.Start(new ProcessStartInfo(ccleanerSaveLocation) { UseShellExecute = true });

                if (ccleanerInstallerProcess != null && !ccleanerInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    ccleanerInstallerProcess.WaitForExit();

                    if (ccleanerInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(ccleanerSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(ccleanerSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string puttyUrl = "https://the.earth.li/~sgtatham/putty/latest/w64/putty-64bit-0.81-installer.msi";
                string puttySaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "PuttySetup.exe"); ;
                Console.WriteLine("Downloading PuTTY...");

                // Download putty installer
                using (HttpClient puttyClient = new HttpClient())
                {
                    using (HttpResponseMessage puttyResponse = puttyClient.GetAsync(puttyUrl).Result)
                    {
                        using (HttpContent puttyContent = puttyResponse.Content)
                        {
                            using (Stream puttyStream = puttyContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream puttyFileStream = new FileStream(puttySaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] puttyBuffer = new byte[1024];
                                    int puttyBytesRead;
                                    long puttyTotalBytesRead = 0;
                                    long puttyTotalBytes = puttyResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write putty installer file
                                    while ((puttyBytesRead = puttyStream.Read(puttyBuffer, 0, puttyBuffer.Length)) > 0)
                                    {
                                        puttyFileStream.Write(puttyBuffer, 0, puttyBytesRead);
                                        puttyTotalBytesRead += puttyBytesRead;

                                        if (puttyTotalBytes > 0)
                                        {
                                            int puttyProgress = (int)((puttyTotalBytesRead * 100) / puttyTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {puttyProgress}% ({puttyTotalBytesRead / 1024} KB of {puttyTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nPuTTY was downloaded successfully!");
                Process puttyInstallerProcess = Process.Start(new ProcessStartInfo(puttySaveLocation) { UseShellExecute = true });

                if (puttyInstallerProcess != null && !puttyInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    puttyInstallerProcess.WaitForExit();

                    if (puttyInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(puttySaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(puttySaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string filezillaUrl = "https://download.filezilla-project.org/client/FileZilla_3.67.1_win64_sponsored2-setup.exe";
                string filezillaSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "FilezillaSetup.exe"); ;
                Console.WriteLine("Downloading Filezilla Desktop...");

                // Download filezilla installer
                using (HttpClient filezillaClient = new HttpClient())
                {
                    using (HttpResponseMessage filezillaResponse = filezillaClient.GetAsync(filezillaUrl).Result)
                    {
                        using (HttpContent filezillaContent = filezillaResponse.Content)
                        {
                            using (Stream filezillaStream = filezillaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream filezillaFileStream = new FileStream(filezillaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] filezillaBuffer = new byte[1024];
                                    int filezillaBytesRead;
                                    long filezillaTotalBytesRead = 0;
                                    long filezillaTotalBytes = filezillaResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write filezilla installer file
                                    while ((filezillaBytesRead = filezillaStream.Read(filezillaBuffer, 0, filezillaBuffer.Length)) > 0)
                                    {
                                        filezillaFileStream.Write(filezillaBuffer, 0, filezillaBytesRead);
                                        filezillaTotalBytesRead += filezillaBytesRead;

                                        if (filezillaTotalBytes > 0)
                                        {
                                            int filezillaProgress = (int)((filezillaTotalBytesRead * 100) / filezillaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {filezillaProgress}% ({filezillaTotalBytesRead / 1024} KB of {filezillaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nFilezilla Desktop was downloaded successfully!");
                Process filezillaInstallerProcess = Process.Start(new ProcessStartInfo(filezillaSaveLocation) { UseShellExecute = true });

                if (filezillaInstallerProcess != null && !filezillaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    filezillaInstallerProcess.WaitForExit();

                    if (filezillaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(filezillaSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(filezillaSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "4":
                Console.Clear();
                string recuvaUrl =
                    "https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip";
                string recuvaSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "RecuvaSetup.exe"); ;
                Console.WriteLine("Downloading Recuva...");

                // Download Recuva installer
                using (HttpClient recuvaClient = new HttpClient())
                {
                    using (HttpResponseMessage recuvaResponse = recuvaClient.GetAsync(recuvaUrl).Result)
                    {
                        using (HttpContent recuvaContent = recuvaResponse.Content)
                        {
                            using (Stream recuvaStream = recuvaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream recuvaFileStream = new FileStream(recuvaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] recuvaBuffer = new byte[1024];
                                    int recuvaBytesRead;
                                    long recuvaTotalBytesRead = 0;
                                    long recuvaTotalBytes = recuvaResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Recuva installer file
                                    while ((recuvaBytesRead = recuvaStream.Read(recuvaBuffer, 0, recuvaBuffer.Length)) > 0)
                                    {
                                        recuvaFileStream.Write(recuvaBuffer, 0, recuvaBytesRead);
                                        recuvaTotalBytesRead += recuvaBytesRead;

                                        if (recuvaTotalBytes > 0)
                                        {
                                            int recuvaProgress = (int)((recuvaTotalBytesRead * 100) / recuvaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {recuvaProgress}% ({recuvaTotalBytesRead / 1024} KB of {recuvaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nRecuva was downloaded successfully!");
                Process recuvaInstallerProcess = Process.Start(new ProcessStartInfo(recuvaSaveLocation) { UseShellExecute = true });

                if (recuvaInstallerProcess != null && !recuvaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    recuvaInstallerProcess.WaitForExit();

                    if (recuvaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(recuvaSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(recuvaSaveLocation); // Delete the setup file
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
