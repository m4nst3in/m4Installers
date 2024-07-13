using System.Diagnostics;

class MenuDocuments
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                                        _       
|  _ \  ___   ___ _   _ _ __ ___   ___ _ __ | |_ ___ 
| | | |/ _ \ / __| | | | '_ ` _ \ / _ \ '_ \| __/ __|
| |_| | (_) | (__| |_| | | | | | |  __/ | | | |_\__ \
|____/ \___/ \___|\__,_|_| |_| |_|\___|_| |_|\__|___/

");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - OpenOffice ");
        Console.WriteLine("[2] - LibreOffice Writer ");
        Console.WriteLine("[3] - WPS Office ");
        Console.WriteLine("[4] - Obsidian ");
        Console.WriteLine("[5] - Return to Main Menu ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("OpenOffice", "OpenOfficeSetup.exe", "https://sourceforge.net/projects/openofficeorg.mirror/files/4.1.15/binaries/pt-BR/Apache_OpenOffice_4.1.15_Win_x86_install_pt-BR.exe/download");
                break;
            case "2":
                await DownloadAndInstall("LibreOffice Writer", "LibreOfficeSetup.exe", "https://www.libreoffice.org/download/download/");
                break;
            case "3":
                await DownloadAndInstall("WPS Office", "WPSOfficeSetup.exe", "https://www.wps.com/office-free");
                break;
            case "4":
                await DownloadAndInstall("Obsidian (Vault)", "ObsidianSetup.exe", "https://github.com/obsidianmd/obsidian-releases/releases/download/v1.6.5/Obsidian-1.6.5.exe");
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
        else
        {
            Console.WriteLine($"Failed to download {appName}. Please try again later.");
        }
    }
}
