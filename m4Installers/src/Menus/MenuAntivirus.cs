using System.Diagnostics;

class MenuAntivirus
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
    _          _   _       _                
   / \   _ __ | |_(_)_   _(_)_ __ _   _ ___ 
  / _ \ | '_ \| __| \ \ / / | '__| | | / __|
 / ___ \| | | | |_| |\ V /| | |  | |_| \__ \
/_/   \_\_| |_|\__|_| \_/ |_|_|   \__,_|___/

");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Avast");
        Console.WriteLine("[2] - Kaspersky");
        Console.WriteLine("[3] - MalwareBytes");
        Console.WriteLine("[4] - Bitdefender");
        Console.WriteLine("[5] - AVG");
        Console.WriteLine("[6] - Avira");
        Console.WriteLine("[7] - SUPERAntiSpyware");
        Console.WriteLine("[8] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await DownloadAndInstall("Avast", "AvastSetup.exe", "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN/installertype_FULL/build_RELEASE/");
                break;

            case "2":
                await DownloadAndInstall("Kaspersky", "KasperskySetup.exe", "https://www.dropbox.com/scl/fi/mz69m452jlwbsjxedub7h/KasperskySetup.exe?rlkey=rw3nbq698ua3s9is53mt9zs1m&st=lvho0p8p&dl=1");
                break;

            case "3":
                await DownloadAndInstall("Malwarebytes", "Malwarebytesetup.exe", "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe&t=1720763650278");
                break;

            case "4":
                await DownloadAndInstall("Bitdefender", "BitdefenderSetup.exe", "https://download.bitdefender.com/windows/installer/pt-br/bitdefender_avfree.exe");
                break;

            case "5":
                await DownloadAndInstall("AVG", "AVGSetup.exe", "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN_AVG/installertype_ONLINE/build_RELEASE");
                break;

            case "6":
                await DownloadAndInstall("Avira", "AviraSetup.exe", "https://package.avira.com/download/spotlight-windows-bootstrapper/avira_en_sptl1_316508c615bffe3f__ws-spotlight-release.exe");
                break;

            case "7":
                await DownloadAndInstall("SUPERAntiSpyware", "SUPERAntiSpywareSetup.exe", "https://secure.superantispyware.com/SUPERAntiSpyware.exe");
                break;

            case "8":
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
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
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
                                    Console.Write($"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
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
