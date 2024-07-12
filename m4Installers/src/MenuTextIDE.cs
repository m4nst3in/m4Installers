using System.Diagnostics;

class MenuTextIDE
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _____         _     _____    _ _ _                    _____ ____  _____     
|_   _|____  _| |_  | ____|__| (_) |_ ___  _ __ ___   / /_ _|  _ \| ____|___ 
  | |/ _ \ \/ / __| |  _| / _` | | __/ _ \| '__/ __| / / | || | | |  _| / __|
  | |  __/>  <| |_  | |__| (_| | | || (_) | |  \__ \/ /  | || |_| | |___\__ \
  |_|\___/_/\_\\__| |_____\__,_|_|\__\___/|_|  |___/_/  |___|____/|_____|___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Sublime Text");
        Console.WriteLine("[2] - Notepad++");
        Console.WriteLine("[3] - Visual Studio Code");
        Console.WriteLine("[4] - JetBrains IDEs");
        Console.WriteLine("[5] - Return to Main Menu");

        // Read user input
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstallAsync("https://download.sublimetext.com/sublime_text_build_4169_x64_setup.exe", "SublimeTextSetup.exe", "Sublime Text");
                break;
            case "2":
                await DownloadAndInstallAsync("https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.6.7/npp.8.6.7.Installer.x64.exe", "NotepadSetup.exe", "Notepad++");
                break;
            case "3":
                await DownloadAndInstallAsync("https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user", "VSCodeSetup.exe", "Visual Studio Code");
                break;
            case "4":
                await DownloadAndInstallAsync("https://download.jetbrains.com/toolbox/jetbrains-toolbox-2.4.0.32175.exe", "JetBrainsIDESetup.exe", "JetBrains Toolbox");
                break;
            case "5":
                Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }

    private static async Task DownloadAndInstallAsync(string url, string fileName, string softwareName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {softwareName}...");

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            Stream stream = await response.Content.ReadAsStreamAsync();

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

        Console.WriteLine($"\n{softwareName} was downloaded successfully!");
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
