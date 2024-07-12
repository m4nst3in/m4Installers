using System.Diagnostics;
class MenuTorrents
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _____                         _       
|_   _|__  _ __ _ __ ___ _ __ | |_ ___ 
  | |/ _ \| '__| '__/ _ \ '_ \| __/ __|
  | | (_) | |  | | |  __/ | | | |_\__ \
  |_|\___/|_|  |_|  \___|_| |_|\__|___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - uTorrent ");
        Console.WriteLine("[2] - BitTorrent ");
        Console.WriteLine("[3] - qBittorrent ");
        Console.WriteLine("[4] - Transmission ");
        Console.WriteLine("[5] - Return to Main Menu ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string utorrentUrl = "https://download-hr.utorrent.com/track/beta/endpoint/utorrent/os/windows";
                string utorrentSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "UTorrentSetup.exe");
                Console.WriteLine("Downloading uTorrent...");

                // Download uTorrent installer
                using (HttpClient utorrentClient = new HttpClient())
                {
                    using (HttpResponseMessage utorrentResponse = utorrentClient.GetAsync(utorrentUrl).Result)
                    {
                        using (HttpContent utorrentContent = utorrentResponse.Content)
                        {
                            using (Stream utorrentStream = utorrentContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream utorrentFileStream = new FileStream(utorrentSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] utorrentBuffer = new byte[1024];
                                    int utorrentBytesRead;
                                    long utorrentTotalBytesRead = 0;
                                    long utorrentTotalBytes = utorrentResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write uTorrent installer file
                                    while ((utorrentBytesRead = utorrentStream.Read(utorrentBuffer, 0, utorrentBuffer.Length)) > 0)
                                    {
                                        utorrentFileStream.Write(utorrentBuffer, 0, utorrentBytesRead);
                                        utorrentTotalBytesRead += utorrentBytesRead;

                                        if (utorrentTotalBytes > 0)
                                        {
                                            int utorrentProgress = (int)((utorrentTotalBytesRead * 100) / utorrentTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {utorrentProgress}% ({utorrentTotalBytesRead / 1024} KB of {utorrentTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nuTorrent was downloaded successfully!");
                Process utorrentInstallerProcess = Process.Start(new ProcessStartInfo(utorrentSaveLocation) { UseShellExecute = true });

                if (utorrentInstallerProcess != null && !utorrentInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    utorrentInstallerProcess.WaitForExit();

                    if (utorrentInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(utorrentSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(utorrentSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string bittorrentUrl = "https://download-new.utorrent.com/endpoint/bittorrent/os/windows/track/stable/";
                string bittorrentSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "BittorrentSetup.exe"); ;
                Console.WriteLine("Downloading BitTorrent...");

                // Download BitTorrent installer
                using (HttpClient bittorrentClient = new HttpClient())
                {
                    using (HttpResponseMessage bittorrentResponse = bittorrentClient.GetAsync(bittorrentUrl).Result)
                    {
                        using (HttpContent bittorrentContent = bittorrentResponse.Content)
                        {
                            using (Stream bittorrentStream = bittorrentContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream bittorrentFileStream = new FileStream(bittorrentSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] bittorrentBuffer = new byte[1024];
                                    int bittorrentBytesRead;
                                    long bittorrentTotalBytesRead = 0;
                                    long bittorrentTotalBytes = bittorrentResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write BitTorrent installer file
                                    while ((bittorrentBytesRead = bittorrentStream.Read(bittorrentBuffer, 0, bittorrentBuffer.Length)) > 0)
                                    {
                                        bittorrentFileStream.Write(bittorrentBuffer, 0, bittorrentBytesRead);
                                        bittorrentTotalBytesRead += bittorrentBytesRead;

                                        if (bittorrentTotalBytes > 0)
                                        {
                                            int bittorrentProgress = (int)((bittorrentTotalBytesRead * 100) / bittorrentTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {bittorrentProgress}% ({bittorrentTotalBytesRead / 1024} KB of {bittorrentTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nBitTorrent was downloaded successfully!");
                Process bittorrentInstallerProcess = Process.Start(new ProcessStartInfo(bittorrentSaveLocation) { UseShellExecute = true });

                if (bittorrentInstallerProcess != null && !bittorrentInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    bittorrentInstallerProcess.WaitForExit();

                    if (bittorrentInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(bittorrentSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(bittorrentSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string qbittorrentUrl = "https://www.dropbox.com/scl/fi/bbthely0e6m64nmmav0yj/qbittorrent_4.6.5_x64_setup.exe?rlkey=qg8wt0lll4l0ppda094todubk&st=7ee8soaw&dl=01";
                string qbittorrentSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "QBittorrentSetup.exe"); ;
                Console.WriteLine("Downloading qBittorrent...");

                // Download qBittorrent installer
                using (HttpClient qbittorrentClient = new HttpClient())
                {
                    using (HttpResponseMessage qbittorrentResponse = qbittorrentClient.GetAsync(qbittorrentUrl).Result)
                    {
                        using (HttpContent qbittorrentContent = qbittorrentResponse.Content)
                        {
                            using (Stream qbittorrentStream = qbittorrentContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream qbittorrentFileStream = new FileStream(qbittorrentSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] qbittorrentBuffer = new byte[1024];
                                    int qbittorrentBytesRead;
                                    long qbittorrentTotalBytesRead = 0;
                                    long qbittorrentTotalBytes = qbittorrentResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write qBittorrent installer file
                                    while ((qbittorrentBytesRead = qbittorrentStream.Read(qbittorrentBuffer, 0, qbittorrentBuffer.Length)) > 0)
                                    {
                                        qbittorrentFileStream.Write(qbittorrentBuffer, 0, qbittorrentBytesRead);
                                        qbittorrentTotalBytesRead += qbittorrentBytesRead;

                                        if (qbittorrentTotalBytes > 0)
                                        {
                                            int qbittorrentProgress = (int)((qbittorrentTotalBytesRead * 100) / qbittorrentTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {qbittorrentProgress}% ({qbittorrentTotalBytesRead / 1024} KB of {qbittorrentTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nqBittorrent was downloaded successfully!");
                Process qbittorrentInstallerProcess = Process.Start(new ProcessStartInfo(qbittorrentSaveLocation) { UseShellExecute = true });

                if (qbittorrentInstallerProcess != null && !qbittorrentInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    qbittorrentInstallerProcess.WaitForExit();

                    if (qbittorrentInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(qbittorrentSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(qbittorrentSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "4":
                Console.Clear();
                string transmissionUrl = "https://github.com/transmission/transmission/releases/download/4.0.6/transmission-4.0.6-x64.msi";
                string transmissionSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "TransmissionSetup.msi"); ;
                Console.WriteLine("Downloading Transmission...");

                // Download Transmission installer
                using (HttpClient transmissionClient = new HttpClient())
                {
                    using (HttpResponseMessage transmissionResponse = transmissionClient.GetAsync(transmissionUrl).Result)
                    {
                        using (HttpContent transmissionContent = transmissionResponse.Content)
                        {
                            using (Stream transmissionStream = transmissionContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream transmissionFileStream = new FileStream(transmissionSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] transmissionBuffer = new byte[1024];
                                    int transmissionBytesRead;
                                    long transmissionTotalBytesRead = 0;
                                    long transmissionTotalBytes = transmissionResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Transmission installer file
                                    while ((transmissionBytesRead = transmissionStream.Read(transmissionBuffer, 0, transmissionBuffer.Length)) > 0)
                                    {
                                        transmissionFileStream.Write(transmissionBuffer, 0, transmissionBytesRead);
                                        transmissionTotalBytesRead += transmissionBytesRead;

                                        if (transmissionTotalBytes > 0)
                                        {
                                            int transmissionProgress = (int)((transmissionTotalBytesRead * 100) / transmissionTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {transmissionProgress}% ({transmissionTotalBytesRead / 1024} KB of {transmissionTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nTransmission was downloaded successfully!");
                Process transmissionInstallerProcess = Process.Start(new ProcessStartInfo(transmissionSaveLocation) { UseShellExecute = true });

                if (transmissionInstallerProcess != null && !transmissionInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    transmissionInstallerProcess.WaitForExit();

                    if (transmissionInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(transmissionSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(transmissionSaveLocation); // Delete the setup file
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
