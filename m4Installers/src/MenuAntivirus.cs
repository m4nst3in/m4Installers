using System.Diagnostics;

class MenuAntivirus
{
    public static void ShowMenu()
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
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                DownloadAndInstall("Avast", "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN/installertype_FULL/build_RELEASE/", "AvastSetup.exe");
                break;

            case "2":
                DownloadAndInstall("Kaspersky", "https://www.dropbox.com/scl/fi/mz69m452jlwbsjxedub7h/KasperskySetup.exe?rlkey=rw3nbq698ua3s9is53mt9zs1m&st=lvho0p8p&dl=1", "KasperskySetup.exe");
                break;

            case "3":
                DownloadAndInstall("Malwarebytes", "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe&t=1720763650278", "Malwarebytesetup.exe");
                break;

            case "4":
                DownloadAndInstall("Bitdefender", "https://download.bitdefender.com/windows/installer/pt-br/bitdefender_avfree.exe", "BitdefenderSetup.exe");
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }

    private static void DownloadAndInstall(string antivirusName, string downloadUrl, string fileName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {antivirusName}...");

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = client.GetAsync(downloadUrl).Result)
            {
                using (HttpContent content = response.Content)
                {
                    using (Stream stream = content.ReadAsStreamAsync().Result)
                    {
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.Content.Headers.ContentLength ?? -1;

                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
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

        Console.WriteLine($"\n{antivirusName} was downloaded successfully!");
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
            File.Delete(saveLocation);
        }
    }
}