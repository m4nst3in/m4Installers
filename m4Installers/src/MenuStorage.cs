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
                DownloadAndInstall("https://www.dropbox.com/download?plat=win&type=full", "DropboxSetup.exe", "Dropbox");
                break;

            case "2":
                DownloadAndInstall("https://mega.nz/MEGAsyncSetup.exe", "MEGASyncSetup.exe", "MEGA");
                break;

            case "3":
                DownloadAndInstall("https://sugarsync.com/downloads/p/SugarSyncSetup.exe", "SugarSyncSetup.exe", "SugarSync");
                break;

            case "4":
                DownloadAndInstall("https://dl.google.com/drive-file-stream/GoogleDriveSetup.exe", "GoogleDriveSetup.exe", "Google Drive");
                break;

            case "5":
                DownloadAndInstall("https://oneclient.sfx.ms/Win/Installers/24.126.0623.0001/amd64/OneDriveSetup.exe", "OneDriveSetup.exe", "OneDrive");
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

    private static void DownloadAndInstall(string url, string fileName, string appName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            {
                using (HttpContent content = response.Content)
                {
                    using (Stream stream = content.ReadAsStreamAsync().Result)
                    {
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
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
                                    Console.Write($"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"\n{appName} was downloaded successfully!");
        Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

        if (installerProcess != null && !installerProcess.HasExited)
        {
            Console.WriteLine("Installing...");

            installerProcess.WaitForExit();

            if (installerProcess.ExitCode == 0)
            {
                Console.WriteLine("Installation was concluded with success!");
            }
            else
            {
                Console.WriteLine("Installation has failed!");
            }
            Console.Clear();
            File.Delete(saveLocation); // Delete the setup file
        }
    }
}