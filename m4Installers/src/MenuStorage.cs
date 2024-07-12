using System.Diagnostics;
class MenuStorage
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____  _                             
/ ___|| |_ ___  _ __ __ _  __ _  ___ 
\___ \| __/ _ \| '__/ _` |/ _` |/ _ \
 ___) | || (_) | | | (_| | (_| |  __/
|____/ \__\___/|_|  \__,_|\__, |\___|
                          |___/      


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Dropbox ");
        Console.WriteLine("[2] - MEGA ");
        Console.WriteLine("[3] - SugarSync ");
        Console.WriteLine("[4] - Google Drive ");
        Console.WriteLine("[5] - OneDrive ");
        Console.WriteLine("[6] - Return to Main Menu ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string dropboxUrl = "https://www.dropbox.com/download?plat=win&type=full";
                string dropboxSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "DropboxSetup.exe");
                Console.WriteLine("Downloading Dropbox...");

                // Download Dropbox installer
                using (HttpClient dropboxClient = new HttpClient())
                {
                    using (HttpResponseMessage dropboxResponse = dropboxClient.GetAsync(dropboxUrl).Result)
                    {
                        using (HttpContent dropboxContent = dropboxResponse.Content)
                        {
                            using (Stream dropboxStream = dropboxContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream dropboxFileStream = new FileStream(dropboxSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] dropboxBuffer = new byte[1024];
                                    int dropboxBytesRead;
                                    long dropboxTotalBytesRead = 0;
                                    long dropboxTotalBytes = dropboxResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Dropbox installer file
                                    while ((dropboxBytesRead = dropboxStream.Read(dropboxBuffer, 0, dropboxBuffer.Length)) > 0)
                                    {
                                        dropboxFileStream.Write(dropboxBuffer, 0, dropboxBytesRead);
                                        dropboxTotalBytesRead += dropboxBytesRead;

                                        if (dropboxTotalBytes > 0)
                                        {
                                            int dropboxProgress = (int)((dropboxTotalBytesRead * 100) / dropboxTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {dropboxProgress}% ({dropboxTotalBytesRead / 1024} KB of {dropboxTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nDropbox was downloaded successfully!");
                Process dropboxInstallerProcess = Process.Start(new ProcessStartInfo(dropboxSaveLocation) { UseShellExecute = true });

                if (dropboxInstallerProcess != null && !dropboxInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    dropboxInstallerProcess.WaitForExit();

                    if (dropboxInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(dropboxSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(dropboxSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string megaUrl = "https://mega.nz/MEGAsyncSetup.exe";
                string megaSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "MEGASyncSetup.exe");
                Console.WriteLine("Downloading MEGA...");

                // Download MEGA installer
                using (HttpClient megaClient = new HttpClient())
                {
                    using (HttpResponseMessage megaResponse = megaClient.GetAsync(megaUrl).Result)
                    {
                        using (HttpContent megaContent = megaResponse.Content)
                        {
                            using (Stream megaStream = megaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream megaFileStream = new FileStream(megaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] megaBuffer = new byte[1024];
                                    int megaBytesRead;
                                    long megaTotalBytesRead = 0;
                                    long megaTotalBytes = megaResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write MEGA installer file
                                    while ((megaBytesRead = megaStream.Read(megaBuffer, 0, megaBuffer.Length)) > 0)
                                    {
                                        megaFileStream.Write(megaBuffer, 0, megaBytesRead);
                                        megaTotalBytesRead += megaBytesRead;

                                        if (megaTotalBytes > 0)
                                        {
                                            int megaProgress = (int)((megaTotalBytesRead * 100) / megaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {megaProgress}% ({megaTotalBytesRead / 1024} KB of {megaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nMEGA was downloaded successfully!");
                Process megaInstallerProcess = Process.Start(new ProcessStartInfo(megaSaveLocation) { UseShellExecute = true });

                if (megaInstallerProcess != null && !megaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    megaInstallerProcess.WaitForExit();

                    if (megaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(megaSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(megaSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string sugarsyncUrl = "https://sugarsync.com/downloads/p/SugarSyncSetup.exe";
                string sugarsyncSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "SugarSyncSetup.exe");
                Console.WriteLine("Downloading SugarSync...");

                // Download SugarSync installer
                using (HttpClient sugarsyncClient = new HttpClient())
                {
                    using (HttpResponseMessage sugarsyncResponse = sugarsyncClient.GetAsync(sugarsyncUrl).Result)
                    {
                        using (HttpContent sugarsyncContent = sugarsyncResponse.Content)
                        {
                            using (Stream sugarsyncStream = sugarsyncContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream sugarsyncFileStream = new FileStream(sugarsyncSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] sugarsyncBuffer = new byte[1024];
                                    int sugarsyncBytesRead;
                                    long sugarsyncTotalBytesRead = 0;
                                    long sugarsyncTotalBytes = sugarsyncResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write SugarSync installer file
                                    while ((sugarsyncBytesRead = sugarsyncStream.Read(sugarsyncBuffer, 0, sugarsyncBuffer.Length)) > 0)
                                    {
                                        sugarsyncFileStream.Write(sugarsyncBuffer, 0, sugarsyncBytesRead);
                                        sugarsyncTotalBytesRead += sugarsyncBytesRead;

                                        if (sugarsyncTotalBytes > 0)
                                        {
                                            int sugarsyncProgress = (int)((sugarsyncTotalBytesRead * 100) / sugarsyncTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {sugarsyncProgress}% ({sugarsyncTotalBytesRead / 1024} KB of {sugarsyncTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nSugarSync was downloaded successfully!");
                Process sugarsyncInstallerProcess = Process.Start(new ProcessStartInfo(sugarsyncSaveLocation) { UseShellExecute = true });

                if (sugarsyncInstallerProcess != null && !sugarsyncInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    sugarsyncInstallerProcess.WaitForExit();

                    if (sugarsyncInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(sugarsyncSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(sugarsyncSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "4":
                Console.Clear();
                string googleDriveUrl = "https://dl.google.com/drive-file-stream/GoogleDriveSetup.exe";
                string googleDriveSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "GoogleDriveSetup.exe");
                Console.WriteLine("Downloading Google Drive...");

                // Download Google Drive installer
                using (HttpClient googleDriveClient = new HttpClient())
                {
                    using (HttpResponseMessage googleDriveResponse = googleDriveClient.GetAsync(googleDriveUrl).Result)
                    {
                        using (HttpContent googleDriveContent = googleDriveResponse.Content)
                        {
                            using (Stream googleDriveStream = googleDriveContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream googleDriveFileStream = new FileStream(googleDriveSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] googleDriveBuffer = new byte[1024];
                                    int googleDriveBytesRead;
                                    long googleDriveTotalBytesRead = 0;
                                    long googleDriveTotalBytes = googleDriveResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Google Drive installer file
                                    while ((googleDriveBytesRead = googleDriveStream.Read(googleDriveBuffer, 0, googleDriveBuffer.Length)) > 0)
                                    {
                                        googleDriveFileStream.Write(googleDriveBuffer, 0, googleDriveBytesRead);
                                        googleDriveTotalBytesRead += googleDriveBytesRead;

                                        if (googleDriveTotalBytes > 0)
                                        {
                                            int googleDriveProgress = (int)((googleDriveTotalBytesRead * 100) / googleDriveTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {googleDriveProgress}% ({googleDriveTotalBytesRead / 1024} KB of {googleDriveTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGoogle Drive was downloaded successfully!");
                Process googleDriveInstallerProcess = Process.Start(new ProcessStartInfo(googleDriveSaveLocation) { UseShellExecute = true });

                if (googleDriveInstallerProcess != null && !googleDriveInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    googleDriveInstallerProcess.WaitForExit();

                    if (googleDriveInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(googleDriveSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(googleDriveSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "5":
                Console.Clear();
                string oneDriveUrl = "https://oneclient.sfx.ms/Win/Installers/24.126.0623.0001/amd64/OneDriveSetup.exe";
                string oneDriveSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "OneDriveSetup.exe");
                Console.WriteLine("Downloading OneDrive...");

                // Download OneDrive installer
                using (HttpClient oneDriveClient = new HttpClient())
                {
                    using (HttpResponseMessage oneDriveResponse = oneDriveClient.GetAsync(oneDriveUrl).Result)
                    {
                        using (HttpContent oneDriveContent = oneDriveResponse.Content)
                        {
                            using (Stream oneDriveStream = oneDriveContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream oneDriveFileStream = new FileStream(oneDriveSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] oneDriveBuffer = new byte[1024];
                                    int oneDriveBytesRead;
                                    long oneDriveTotalBytesRead = 0;
                                    long oneDriveTotalBytes = oneDriveResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write OneDrive installer file
                                    while ((oneDriveBytesRead = oneDriveStream.Read(oneDriveBuffer, 0, oneDriveBuffer.Length)) > 0)
                                    {
                                        oneDriveFileStream.Write(oneDriveBuffer, 0, oneDriveBytesRead);
                                        oneDriveTotalBytesRead += oneDriveBytesRead;

                                        if (oneDriveTotalBytes > 0)
                                        {
                                            int oneDriveProgress = (int)((oneDriveTotalBytesRead * 100) / oneDriveTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {oneDriveProgress}% ({oneDriveTotalBytesRead / 1024} KB of {oneDriveTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOneDrive was downloaded successfully!");
                Process oneDriveInstallerProcess = Process.Start(new ProcessStartInfo(oneDriveSaveLocation) { UseShellExecute = true });

                if (oneDriveInstallerProcess != null && !oneDriveInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    oneDriveInstallerProcess.WaitForExit();

                    if (oneDriveInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(oneDriveSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(oneDriveSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "6":
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
