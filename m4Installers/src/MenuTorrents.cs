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
                DownloadAndInstall("https://download-hr.utorrent.com/track/beta/endpoint/utorrent/os/windows", "UTorrentSetup.exe");
                break;

            case "2":
                DownloadAndInstall("https://download-new.utorrent.com/endpoint/bittorrent/os/windows/track/stable/", "BittorrentSetup.exe");
                break;

            case "3":
                DownloadAndInstall("https://www.dropbox.com/scl/fi/bbthely0e6m64nmmav0yj/qbittorrent_4.6.5_x64_setup.exe?rlkey=qg8wt0lll4l0ppda094todubk&st=7ee8soaw&dl=01", "QBittorrentSetup.exe");
                break;

            case "4":
                DownloadAndInstall("https://github.com/transmission/transmission/releases/download/4.0.6/transmission-4.0.6-x64.msi", "TransmissionSetup.msi");
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

    private static void DownloadAndInstall(string url, string fileName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {fileName}...");

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

        Console.WriteLine($"\n{fileName} was downloaded successfully!");
        Process installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

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