using System.Diagnostics;
class MenuPVEditor
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____  _           _           __     ___     _              _____    _ _ _   
|  _ \| |__   ___ | |_ ___     \ \   / (_) __| | ___  ___   | ____|__| (_) |_ ___  _ __ ___  
| |_) | '_ \ / _ \| __/ _ \ ____\ \ / /| |/ _` |/ _ \/ _ \  |  _| / _` | | __/ _ \| '__/ __|
|  __/| | | | (_) | || (_) |_____\ V / | | (_| |  __/ (_) | | |__| (_| | | || (_) | |  \__ \
|_|   |_| |_|\___/ \__\___/       \_/  |_|\__,_|\___|\___/  |_____\__,_|_|\__\___/|_|  |___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - GIMP");
        Console.WriteLine("[2] - Paint.NET");
        Console.WriteLine("[3] - OpenShot");
        Console.WriteLine("[4] - Krita");
        Console.WriteLine("[5] - Return to Main Menu");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                DownloadAndInstall("https://download.gimp.org/gimp/v2.10/windows/gimp-2.10.38-setup.exe", "GIMPSetup.exe");
                break;

            case "2":
                DownloadAndInstall("https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip", "PaintDotNetSetup.zip");
                break;

            case "3":
                DownloadAndInstall("https://github.com/OpenShot/openshot-qt/releases/download/v3.2.1/OpenShot-v3.2.1-x86_64.exe", "OpenShotSetup.exe");
                break;

            case "4":
                DownloadAndInstall("https://download.kde.org/stable/krita/4.4.5/krita-x64-4.4.5-setup.exe", "KritaSetup.exe");
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