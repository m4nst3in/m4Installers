using System.Diagnostics;

class MenuUtilities
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _   _ _   _ _ _ _   _           
| | | | |_(_) (_) |_(_) ___  ___ 
| | | | __| | | | __| |/ _ \/ __|
| |_| | |_| | | | |_| |  __/\__ \
 \___/ \__|_|_|_|\__|_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - CCleaner");
        Console.WriteLine("[2] - PuTTY");
        Console.WriteLine("[3] - Filezilla");
        Console.WriteLine("[4] - Recuva");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("CCleaner", "https://www.dropbox.com/scl/fi/5ytqjerss5wpmi2mz48vf/ccsetup625.exe?rlkey=rnr3b0r4pvwpoxbchlitw267s&st=ks9kk1lv&dl=1", "CCleanerInstaller.exe");
                break;
            case "2":
                await DownloadAndInstall("PuTTY", "https://the.earth.li/~sgtatham/putty/latest/w64/putty-64bit-0.81-installer.msi", "PuttyInstaller.msi");
                break;
            case "3":
                await DownloadAndInstall("Filezilla", "https://www.dropbox.com/scl/fi/ff5czb4u1c3tonxl5ozim/FileZilla_3.67.1_win64_sponsored2-setup.exe?rlkey=8o2is5rh7yobjqe26khj5d1o0&st=dxbcftmg&dl=1", "FilezillaInstaller.exe");
                break;
            case "4":
                await DownloadAndInstall("Recuva", "https://download.ccleaner.com/rcsetup154.exe", "RecuvaInstaller.exe");
                break;
            case "5":
                Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500); // Add a delay of 2.5 seconds
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
                await Task.Delay(2500);
                Console.Clear();
                await ShowMenu();
            }
        }
    }
}
