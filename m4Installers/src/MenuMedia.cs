using System.Diagnostics;


class MenuMedia
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 __  __          _ _       
|  \/  | ___  __| (_) __ _ 
| |\/| |/ _ \/ _` | |/ _` |
| |  | |  __/ (_| | | (_| |
|_|  |_|\___|\__,_|_|\__,_|


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Spotify ");
        Console.WriteLine("[2] - Deezer ");
        Console.WriteLine("[3] - VLC Media Player ");
        Console.WriteLine("[4] - Kodi ");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string spotifyUrl =
                    "https://download.scdn.co/SpotifySetup.exe";
                string spotifySaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "SpotifySetup.exe");
                Console.WriteLine("Downloading Spotify...");

                // Download spotify installer
                using (HttpClient spotifyClient = new HttpClient())
                {
                    using (HttpResponseMessage spotifyResponse = spotifyClient.GetAsync(spotifyUrl).Result)
                    {
                        using (HttpContent spotifyContent = spotifyResponse.Content)
                        {
                            using (Stream spotifyStream = spotifyContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream spotifyFileStream = new FileStream(spotifySaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] spotifyBuffer = new byte[1024];
                                    int spotifyBytesRead;
                                    long spotifyTotalBytesRead = 0;
                                    long spotifyTotalBytes = spotifyResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write spotify installer file
                                    while ((spotifyBytesRead = spotifyStream.Read(spotifyBuffer, 0, spotifyBuffer.Length)) > 0)
                                    {
                                        spotifyFileStream.Write(spotifyBuffer, 0, spotifyBytesRead);
                                        spotifyTotalBytesRead += spotifyBytesRead;

                                        if (spotifyTotalBytes > 0)
                                        {
                                            int spotifyProgress = (int)((spotifyTotalBytesRead * 100) / spotifyTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {spotifyProgress}% ({spotifyTotalBytesRead / 1024} KB of {spotifyTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nSpotify was downloaded successfully!");
                Process spotifyInstallerProcess = Process.Start(new ProcessStartInfo(spotifySaveLocation) { UseShellExecute = true });

                if (spotifyInstallerProcess != null && !spotifyInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    spotifyInstallerProcess.WaitForExit();

                    if (spotifyInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(spotifySaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(spotifySaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string deezerUrl = "https://www.deezer.com/desktop/download?platform=win32&architecture=x86";
                string deezerSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "deezerSetup.exe");
                Console.WriteLine("Downloading Deezer...");

                // Download deezer installer
                using (HttpClient deezerClient = new HttpClient())
                {
                    using (HttpResponseMessage deezerResponse = deezerClient.GetAsync(deezerUrl).Result)
                    {
                        using (HttpContent deezerContent = deezerResponse.Content)
                        {
                            using (Stream deezerStream = deezerContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream deezerFileStream = new FileStream(deezerSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] deezerBuffer = new byte[1024];
                                    int deezerBytesRead;
                                    long deezerTotalBytesRead = 0;
                                    long deezerTotalBytes = deezerResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write deezer installer file
                                    while ((deezerBytesRead = deezerStream.Read(deezerBuffer, 0, deezerBuffer.Length)) > 0)
                                    {
                                        deezerFileStream.Write(deezerBuffer, 0, deezerBytesRead);
                                        deezerTotalBytesRead += deezerBytesRead;

                                        if (deezerTotalBytes > 0)
                                        {
                                            int deezerProgress = (int)((deezerTotalBytesRead * 100) / deezerTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {deezerProgress}% ({deezerTotalBytesRead / 1024} KB of {deezerTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nDeezer was downloaded successfully!");
                Process deezerInstallerProcess = Process.Start(new ProcessStartInfo(deezerSaveLocation) { UseShellExecute = true });

                if (deezerInstallerProcess != null && !deezerInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    deezerInstallerProcess.WaitForExit();

                    if (deezerInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(deezerSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(deezerSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string vlcUrl = "https://get.videolan.org/vlc/3.0.21/win32/vlc-3.0.21-win32.exe";
                string vlcSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "vlcSetup.exe");
                Console.WriteLine("Downloading VLC Media Player...");

                // Download vlc installer
                using (HttpClient vlcClient = new HttpClient())
                {
                    using (HttpResponseMessage vlcResponse = vlcClient.GetAsync(vlcUrl).Result)
                    {
                        using (HttpContent vlcContent = vlcResponse.Content)
                        {
                            using (Stream vlcStream = vlcContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream vlcFileStream = new FileStream(vlcSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] vlcBuffer = new byte[1024];
                                    int vlcBytesRead;
                                    long vlcTotalBytesRead = 0;
                                    long vlcTotalBytes = vlcResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((vlcBytesRead = vlcStream.Read(vlcBuffer, 0, vlcBuffer.Length)) > 0)
                                    {
                                        vlcFileStream.Write(vlcBuffer, 0, vlcBytesRead);
                                        vlcTotalBytesRead += vlcBytesRead;

                                        if (vlcTotalBytes > 0)
                                        {
                                            int vlcProgress = (int)((vlcTotalBytesRead * 100) / vlcTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {vlcProgress}% ({vlcTotalBytesRead / 1024} KB of {vlcTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nVLC Media Player was downloaded successfully!");
                Process vlcInstallerProcess = Process.Start(new ProcessStartInfo(vlcSaveLocation) { UseShellExecute = true });

                if (vlcInstallerProcess != null && !vlcInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    vlcInstallerProcess.WaitForExit();

                    if (vlcInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(vlcSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(vlcSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "4":
                Console.Clear();
                string kodiUrl = "https://mirrors.kodi.tv/releases/windows/win64/kodi-21.0-Omega-x64.exe?https=1";
                string kodiSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "kodiSetup.exe");
                Console.WriteLine("Downloading Kodi...");

                // Download kodi installer
                using (HttpClient kodiClient = new HttpClient())
                {
                    using (HttpResponseMessage kodiResponse = kodiClient.GetAsync(kodiUrl).Result)
                    {
                        using (HttpContent kodiContent = kodiResponse.Content)
                        {
                            using (Stream kodiStream = kodiContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream kodiFileStream = new FileStream(kodiSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] kodiBuffer = new byte[1024];
                                    int kodiBytesRead;
                                    long kodiTotalBytesRead = 0;
                                    long kodiTotalBytes = kodiResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((kodiBytesRead = kodiStream.Read(kodiBuffer, 0, kodiBuffer.Length)) > 0)
                                    {
                                        kodiFileStream.Write(kodiBuffer, 0, kodiBytesRead);
                                        kodiTotalBytesRead += kodiBytesRead;

                                        if (kodiTotalBytes > 0)
                                        {
                                            int kodiProgress = (int)((kodiTotalBytesRead * 100) / kodiTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {kodiProgress}% ({kodiTotalBytesRead / 1024} KB of {kodiTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nKodi was downloaded successfully!");
                Process kodiInstallerProcess = Process.Start(new ProcessStartInfo(kodiSaveLocation) { UseShellExecute = true });

                if (kodiInstallerProcess != null && !kodiInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    kodiInstallerProcess.WaitForExit();

                    if (kodiInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(kodiSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(kodiSaveLocation); // Delete the setup file

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
