using System.Diagnostics;

class MenuTools
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _____           _     
|_   _|__   ___ | |___ 
  | |/ _ \ / _ \| / __|
  | | (_) | (_) | \__ \
  |_|\___/ \___/|_|___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - WinRAR");
        Console.WriteLine("[2] - 7zip");
        Console.WriteLine("[3] - AIDA64");
        Console.WriteLine("[4] - CPU-Z");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("WinRAR", "https://www.win-rar.com/fileadmin/winrar-versions/winrar/winrar-x64-701.exe", "WinRARSetup.exe");
                break;

            case "2":
                await DownloadAndInstall("7zip", "https://www.7-zip.org/a/7z2407-x64.exe", "7zipSetup.exe");
                break;

            case "3":
                await DownloadAndInstall("AIDA64", "https://download2.aida64.com/aida64extreme730.exe", "AIDA64Setup.exe");
                break;

            case "4":
                await DownloadAndInstall("CPU-Z", "https://download.cpuid.com/cpu-z/cpu-z_1.79-en.exe", "CPUZSetup.exe");
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

    private static async Task DownloadAndInstall(string softwareName, string url, string fileName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {softwareName}...");

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
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
            else
            {
                Console.WriteLine($"Failed to download {softwareName}. Please try again.");
            }
        }
    }
}
