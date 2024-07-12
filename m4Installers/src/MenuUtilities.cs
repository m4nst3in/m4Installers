using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System;

class MenuUtilities
{
    public static void ShowMenu()
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
                DownloadAndInstall("CCleaner", "https://www.dropbox.com/scl/fi/5ytqjerss5wpmi2mz48vf/ccsetup625.exe?rlkey=rnr3b0r4pvwpoxbchlitw267s&st=ks9kk1lv&dl=1");
                break;
            case "2":
                DownloadAndInstall("PuTTY", "https://the.earth.li/~sgtatham/putty/latest/w64/putty-64bit-0.81-installer.msi");
                break;
            case "3":
                DownloadAndInstall("Filezilla", "https://download.filezilla-project.org/client/FileZilla_3.67.1_win64_sponsored2-setup.exe");
                break;
            case "4":
                DownloadAndInstall("Recuva", "https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip");
                break;
            case "5":
                Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }

    private static void DownloadAndInstall(string softwareName, string url)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", $"{softwareName}Setup.exe");
        Console.WriteLine($"Downloading {softwareName}...");

        using (HttpClient client = new HttpClient())
        {
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                using (var stream = response.Content.ReadAsStreamAsync().Result)
                using (var fileStream = new FileStream(saveLocation, FileMode.Create))
                {
                    stream.CopyTo(fileStream);
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