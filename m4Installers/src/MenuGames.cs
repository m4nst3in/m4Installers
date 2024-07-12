using System.Diagnostics;

class MenuGames
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
  ____                           
 / ___| __ _ _ __ ___   ___  ___ 
| |  _ / _` | '_ ` _ \ / _ \/ __|
| |_| | (_| | | | | | |  __/\__ \
 \____|\__,_|_| |_| |_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - SKLauncher (MC) ");
        Console.WriteLine("[2] - Prisma Launcher (MC) ");
        Console.WriteLine("[3] - Heroic Games Launcher");
        Console.WriteLine("[4] - Playnite");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstallAsync("https://skmedix.pl/binaries/skl/3.2.8/x64/SKlauncher-3.2.exe", "SKLauncherSetup.exe");
                break;
            case "2":
                await DownloadAndInstallAsync("https://github.com/PrismLauncher/PrismLauncher/releases/download/8.4/PrismLauncher-Windows-MSVC-Setup-8.4.exe", "PrismaSetup.exe");
                break;
            case "3":
                await DownloadAndInstallAsync("https://github.com/Heroic-Games-Launcher/HeroicGamesLauncher/releases/download/v2.14.1/Heroic-2.14.1-Setup-x64.exe", "HeroicSetup.exe");
                break;
            case "4":
                await DownloadAndInstallAsync("https://github.com/JosefNemec/Playnite/releases/download/10.33/Playnite1033.exe", "PlayniteSetup.exe");
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

    private static async Task DownloadAndInstallAsync(string url, string fileName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {fileName}...");

        using (HttpClient client = new HttpClient())

        using (HttpResponseMessage response = await client.GetAsync(url))
        {
            using (Stream stream = await response.Content.ReadAsStreamAsync())
            {
                using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
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
                            Console.Write($"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
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
