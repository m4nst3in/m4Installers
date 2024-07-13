using System.Diagnostics;

class MenuMessaging
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
         __  __                           _             
        |  \/  | ___  ___ ___  __ _  __ _(_)_ __   __ _ 
        | |\/| |/ _ \/ __/ __|/ _` |/ _` | | '_ \ / _` |
        | |  | |  __/\__ \__ \ (_| | (_| | | | | | (_| |
        |_|  |_|\___||___/___/\__,_|\__, |_|_| |_|\__, |
                                    |___/         |___/ 

        ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Discord ");
        Console.WriteLine("[2] - Telegram ");
        Console.WriteLine("[3] - TeamSpeak ");
        Console.WriteLine("[4] - Skype ");
        Console.WriteLine("[5] - Return to Main Menu");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("Discord", "DiscordSetup.exe", "https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64");
                break;
            case "2":
                await DownloadAndInstall("Telegram", "TelegramSetup.exe", "https://telegram.org/dl/desktop/win64");
                break;
            case "3":
                await DownloadAndInstall("Teamspeak", "TeamSpeakSetup.msi", "https://files.teamspeak-services.com/pre_releases/client/5.0.0-beta77/teamspeak-client.msi");
                break;
            case "4":
                await DownloadAndInstall("Skype", "SkypeSetup.exe", "https://download.skype.com/s4l/download/win/Skype-8.123.0.203.exe");
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
