using System.Diagnostics;
class MenuRecorders
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                             ____                        _               
/ ___|  ___ _ __ ___  ___ _ __   |  _ \ ___  ___ ___  _ __ __| | ___ _ __ ___ 
\___ \ / __| '__/ _ \/ _ \ '_ \  | |_) / _ \/ __/ _ \| '__/ _` |/ _ \ '__/ __|
 ___) | (__| | |  __/  __/ | | | |  _ <  __/ (_| (_) | | | (_| |  __/ |  \__ \
|____/ \___|_|  \___|\___|_| |_| |_| \_\___|\___\___/|_|  \__,_|\___|_|  |___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - OBS Studio");
        Console.WriteLine("[2] - Streamlabs");
        Console.WriteLine("[3] - Fraps");
        Console.WriteLine("[4] - Bandicam");
        Console.WriteLine("[5] - Return to Main Menu");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string obsUrl = "https://cdn-fastly.obsproject.com/downloads/OBS-Studio-30.1.2-Full-Installer-x64.exe";
                string obsSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "OBSStudioSetup.exe");
                Console.WriteLine("Downloading OBS Studio...");

                // Download OBS Studio installer
                using (HttpClient obsClient = new HttpClient())
                {
                    using (HttpResponseMessage obsResponse = obsClient.GetAsync(obsUrl).Result)
                    {
                        using (HttpContent obsContent = obsResponse.Content)
                        {
                            using (Stream obsStream = obsContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream obsFileStream = new FileStream(obsSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] obsBuffer = new byte[1024];
                                    int obsBytesRead;
                                    long obsTotalBytesRead = 0;
                                    long obsTotalBytes = obsResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write OBS Studio installer file
                                    while ((obsBytesRead = obsStream.Read(obsBuffer, 0, obsBuffer.Length)) > 0)
                                    {
                                        obsFileStream.Write(obsBuffer, 0, obsBytesRead);
                                        obsTotalBytesRead += obsBytesRead;

                                        if (obsTotalBytes > 0)
                                        {
                                            int obsProgress = (int)((obsTotalBytesRead * 100) / obsTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {obsProgress}% ({obsTotalBytesRead / 1024} KB of {obsTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOBS Studio was downloaded successfully!");
                Process obsInstallerProcess = Process.Start(new ProcessStartInfo(obsSaveLocation) { UseShellExecute = true });

                if (obsInstallerProcess != null && !obsInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    obsInstallerProcess.WaitForExit();

                    if (obsInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(obsSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(obsSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string streamlabsUrl = "https://slobs-cdn.streamlabs.com/Streamlabs+Desktop+Setup+1.16.7.exe";
                string streamlabsSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "StreamlabsSetup.exe");
                Console.WriteLine("Downloading Streamlabs...");

                // Download Streamlabs installer
                using (HttpClient streamlabsClient = new HttpClient())
                {
                    using (HttpResponseMessage streamlabsResponse = streamlabsClient.GetAsync(streamlabsUrl).Result)
                    {
                        using (HttpContent streamlabsContent = streamlabsResponse.Content)
                        {
                            using (Stream streamlabsStream = streamlabsContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream streamlabsFileStream = new FileStream(streamlabsSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] streamlabsBuffer = new byte[1024];
                                    int streamlabsBytesRead;
                                    long streamlabsTotalBytesRead = 0;
                                    long streamlabsTotalBytes = streamlabsResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Streamlabs installer file
                                    while ((streamlabsBytesRead = streamlabsStream.Read(streamlabsBuffer, 0, streamlabsBuffer.Length)) > 0)
                                    {
                                        streamlabsFileStream.Write(streamlabsBuffer, 0, streamlabsBytesRead);
                                        streamlabsTotalBytesRead += streamlabsBytesRead;

                                        if (streamlabsTotalBytes > 0)
                                        {
                                            int streamlabsProgress = (int)((streamlabsTotalBytesRead * 100) / streamlabsTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {streamlabsProgress}% ({streamlabsTotalBytesRead / 1024} KB of {streamlabsTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nStreamlabs was downloaded successfully!");
                Process streamlabsInstallerProcess = Process.Start(new ProcessStartInfo(streamlabsSaveLocation) { UseShellExecute = true });

                if (streamlabsInstallerProcess != null && !streamlabsInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    streamlabsInstallerProcess.WaitForExit();

                    if (streamlabsInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(streamlabsSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(streamlabsSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string frapsUrl = "https://beepa.com/free/setup.exe";
                string frapsSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "FrapsSetup.exe");
                Console.WriteLine("Downloading Fraps...");

                // Download Fraps installer
                using (HttpClient frapsClient = new HttpClient())
                {
                    using (HttpResponseMessage frapsResponse = frapsClient.GetAsync(frapsUrl).Result)
                    {
                        using (HttpContent frapsContent = frapsResponse.Content)
                        {
                            using (Stream frapsStream = frapsContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream frapsFileStream = new FileStream(frapsSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] frapsBuffer = new byte[1024];
                                    int frapsBytesRead;
                                    long frapsTotalBytesRead = 0;
                                    long frapsTotalBytes = frapsResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Fraps installer file
                                    while ((frapsBytesRead = frapsStream.Read(frapsBuffer, 0, frapsBuffer.Length)) > 0)
                                    {
                                        frapsFileStream.Write(frapsBuffer, 0, frapsBytesRead);
                                        frapsTotalBytesRead += frapsBytesRead;

                                        if (frapsTotalBytes > 0)
                                        {
                                            int frapsProgress = (int)((frapsTotalBytesRead * 100) / frapsTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {frapsProgress}% ({frapsTotalBytesRead / 1024} KB of {frapsTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nFraps was downloaded successfully!");
                Process frapsInstallerProcess = Process.Start(new ProcessStartInfo(frapsSaveLocation) { UseShellExecute = true });

                if (frapsInstallerProcess != null && !frapsInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    frapsInstallerProcess.WaitForExit();

                    if (frapsInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(frapsSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(frapsSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "4":
                Console.Clear();
                string bandicamUrl = "https://dl.bandicam.com/bdcamsetup.exe";
                string bandicamSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "BandicamSetup.exe");
                Console.WriteLine("Downloading Bandicam...");

                // Download Bandicam installer
                using (HttpClient bandicamClient = new HttpClient())
                {
                    using (HttpResponseMessage bandicamResponse = bandicamClient.GetAsync(bandicamUrl).Result)
                    {
                        using (HttpContent bandicamContent = bandicamResponse.Content)
                        {
                            using (Stream bandicamStream = bandicamContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream bandicamFileStream = new FileStream(bandicamSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] bandicamBuffer = new byte[1024];
                                    int bandicamBytesRead;
                                    long bandicamTotalBytesRead = 0;
                                    long bandicamTotalBytes = bandicamResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Bandicam installer file
                                    while ((bandicamBytesRead = bandicamStream.Read(bandicamBuffer, 0, bandicamBuffer.Length)) > 0)
                                    {
                                        bandicamFileStream.Write(bandicamBuffer, 0, bandicamBytesRead);
                                        bandicamTotalBytesRead += bandicamBytesRead;

                                        if (bandicamTotalBytes > 0)
                                        {
                                            int bandicamProgress = (int)((bandicamTotalBytesRead * 100) / bandicamTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {bandicamProgress}% ({bandicamTotalBytesRead / 1024} KB of {bandicamTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nBandicam was downloaded successfully!");
                Process bandicamInstallerProcess = Process.Start(new ProcessStartInfo(bandicamSaveLocation) { UseShellExecute = true });

                if (bandicamInstallerProcess != null && !bandicamInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    bandicamInstallerProcess.WaitForExit();

                    if (bandicamInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(bandicamSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(bandicamSaveLocation); // Delete the setup file
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
