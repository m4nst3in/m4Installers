using System.Diagnostics;
class MenuStorage
{
    public static async Task ShowMenu()
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
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("Dropbox", "DropboxSetup.exe", "https://www.dropbox.com/download?plat=win&type=full");
                break;

            case "2":
                await DownloadAndInstall("MEGA", "MEGASyncSetup.exe", "https://mega.nz/MEGAsyncSetup.exe");
                break;

            case "3":
                await DownloadAndInstall("SugarSync", "SugarSyncSetup.exe", "https://sugarsync.com/downloads/p/SugarSyncSetup.exe");
                break;

            case "4":
                await DownloadAndInstall("Google Drive", "GoogleDriveSetup.exe", "https://dl.google.com/drive-file-stream/GoogleDriveSetup.exe");
                break;

            case "5":
                await DownloadAndInstall("OneDrive", "OneDriveSetup.exe", "https://oneclient.sfx.ms/Win/Installers/24.126.0623.0001/amd64/OneDriveSetup.exe");
                break;

            case "6":
                await Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                await Task.Delay(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }

    private static async Task DownloadAndInstall(string appName, string fileName, string downloadUrl)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(downloadUrl))
            {
                using (HttpContent content = response.Content)
                {
                    using (Stream stream = await content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write,
                                   FileShare.None))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.Content.Headers.ContentLength ?? -1;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
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

        Console.WriteLine($"\n{appName} was downloaded successfully!");
        Process? installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

        if (installerProcess != null && !installerProcess.HasExited)
        {
            Console.WriteLine("Installing...");

            installerProcess.WaitForExit();

            if (installerProcess.ExitCode == 0)
            {
                Console.WriteLine("Installation was concluded with success!");
                Console.Clear();
                File.Delete(saveLocation); // Delete the setup file
            }
            else
            {
                Console.WriteLine("Installation has failed!");
                Console.Clear();
                File.Delete(saveLocation); // Delete the setup file
            }
        }
    }
}
