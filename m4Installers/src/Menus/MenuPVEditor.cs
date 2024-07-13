using System.Diagnostics;
class MenuPVEditor
{
    public static async Task ShowMenu()
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

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await DownloadAndInstall("GIMP", "GIMPSetup.exe", "https://download.gimp.org/gimp/v2.10/windows/gimp-2.10.38-setup.exe");
                break;

            case "2":
                await DownloadAndInstall("Paint.NET", "PaintDotNetSetup.exe", "https://www.dropbox.com/scl/fi/q490njix95u49b10f2xnp/paint.net.5.0.13.install.anycpu.web.exe?rlkey=u06viwqd1jh7mjl7rclg3z4x9&st=7upuevwe&dl=1");
                break;

            case "3":
                await DownloadAndInstall("OpenShot", "OpenShotSetup.exe", "https://github.com/OpenShot/openshot-qt/releases/download/v3.2.1/OpenShot-v3.2.1-x86_64.exe");
                break;

            case "4":
                await DownloadAndInstall("Krita", "KritaSetup.exe", "https://download.kde.org/stable/krita/4.4.5/krita-x64-4.4.5-setup.exe");
                break;

            case "5":
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
