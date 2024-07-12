using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System;

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
                DownloadAndInstall("https://download.scdn.co/SpotifySetup.exe", "SpotifySetup.exe", "Spotify");
                break;
            case "2":
                DownloadAndInstall("https://www.deezer.com/desktop/download?platform=win32&architecture=x86", "deezerSetup.exe", "Deezer");
                break;
            case "3":
                DownloadAndInstall("https://get.videolan.org/vlc/3.0.21/win32/vlc-3.0.21-win32.exe", "vlcSetup.exe", "VLC Media Player");
                break;
            case "4":
                DownloadAndInstall("https://mirrors.kodi.tv/releases/windows/win64/kodi-21.0-Omega-x64.exe?https=1", "kodiSetup.exe", "Kodi");
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

    private static void DownloadAndInstall(string url, string fileName, string appName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = client.GetAsync(url).Result)
        using (HttpContent content = response.Content)
        using (Stream stream = content.ReadAsStreamAsync().Result)
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