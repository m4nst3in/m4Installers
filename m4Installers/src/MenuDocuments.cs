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

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("https://sourceforge.net/projects/openofficeorg.mirror/files/4.1.15/binaries/pt-BR/Apache_OpenOffice_4.1.15_Win_x86_install_pt-BR.exe/download", "OpenOfficeSetup.exe", "OpenOffice");
                break;
            case "2":
                await DownloadAndInstall("https://www.libreoffice.org/download/download/", "LibreOfficeSetup.exe", "LibreOffice Writer");
                break;
            case "3":
                await DownloadAndInstall("https://www.wps.com/office-free", "WPSOfficeSetup.exe", "WPS Office");
                break;
            case "4":
                await DownloadAndInstall("https://github.com/obsidianmd/obsidian-releases/releases/download/v1.6.5/Obsidian-1.6.5.exe", "ObsidianSetup.exe", "Obsidian (Vault)");
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

    private static async Task DownloadAndInstall(string url, string fileName, string softwareName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {softwareName}...");

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(saveLocation, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
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
                Console.WriteLine($"Failed to download {softwareName}. Please try again later.");
            }
        }
    }
}
