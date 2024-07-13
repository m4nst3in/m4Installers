using System.Diagnostics;
class MenuTorrents
{
    public static async Task ShowMenu()
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
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("UTorrent", "UTorrentSetup.exe", "https://download-hr.utorrent.com/track/beta/endpoint/utorrent/os/windows");
                break;

            case "2":
                await DownloadAndInstall("BitTorrent", "BittorrentSetup.exe", "https://download-new.utorrent.com/endpoint/bittorrent/os/windows/track/stable/");
                break;

            case "3":
                await DownloadAndInstall("qBitTorrent", "QBittorrentSetup.exe", "https://www.dropbox.com/scl/fi/bbthely0e6m64nmmav0yj/qbittorrent_4.6.5_x64_setup.exe?rlkey=qg8wt0lll4l0ppda094todubk&st=7ee8soaw&dl=01");
                break;

            case "4":
                await DownloadAndInstall("Transmission", "TransmissionSetup.msi", "https://github.com/transmission/transmission/releases/download/4.0.6/transmission-4.0.6-x64.msi");
                break;

            case "5":
                Installers.ReturnToMainMenu();
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
                            byte[] buffer = new byte[1024];
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

        Console.WriteLine($"\n{fileName} was downloaded successfully!");
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
