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
                DownloadAndInstall("https://cdn-fastly.obsproject.com/downloads/OBS-Studio-30.1.2-Full-Installer-x64.exe", "OBSStudioSetup.exe");
                break;
            case "2":
                DownloadAndInstall("https://slobs-cdn.streamlabs.com/Streamlabs+Desktop+Setup+1.16.7.exe", "StreamlabsSetup.exe");
                break;
            case "3":
                DownloadAndInstall("https://beepa.com/free/setup.exe", "FrapsSetup.exe");
                break;
            case "4":
                DownloadAndInstall("https://dl.bandicam.com/bdcamsetup.exe", "BandicamSetup.exe");
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
            var response = client.GetAsync(url).Result;
            var totalBytes = response.Content.Headers.ContentLength ?? -1L;
            using (var stream = response.Content.ReadAsStreamAsync().Result)
            using (var fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                long totalBytesRead = 0;

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

        Console.WriteLine($"\n{fileName} was downloaded successfully!");
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