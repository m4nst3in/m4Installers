using System.Diagnostics;
using System.Net.Http;
using System.IO;
using System;

class MenuRuntimes
{
    private static readonly HttpClient client = new HttpClient();

    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____              _   _                     
|  _ \ _   _ _ __ | |_(_)_ __ ___   ___  ___ 
| |_) | | | | '_ \| __| | '_ ` _ \ / _ \/ __|
|  _ <| |_| | | | | |_| | | | | | |  __/\__ \
|_| \_\\__,_|_| |_|\__|_|_| |_| |_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - AllinOne Runtimes");
        Console.WriteLine("[2] - .NET Framework");
        Console.WriteLine("[3] - Visual C++");
        Console.WriteLine("[4] - DirectX");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                DownloadAndInstall("https://media.computerbase.de/s/GMGpZJyVj9vYs5IosY2y_w/1720764360/download/758/aio-runtimes_v2.5.0.exe", "AIOSetup.exe");
                break;

            case "2":
                HandleDotNetFrameworkInstallation();
                break;

            case "3":
                HandleVisualCPlusPlusInstallation();
                break;

            case "4":
                DownloadAndInstall("https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe", "DXWebSetup.exe");
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
                ShowMenu();
                break;
        }
    }

    private static void DownloadAndInstall(string url, string fileName)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {fileName}...");

        HttpResponseMessage response = client.GetAsync(url).Result;
        Stream stream = response.Content.ReadAsStreamAsync().Result;
        FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write, FileShare.None);
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

        fileStream.Close();
        stream.Close();
        response.Dispose();

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
            File.Delete(saveLocation);
        }
    }

    private static void HandleDotNetFrameworkInstallation()
    {
        Console.Clear();
        Console.WriteLine("Choose the version of .NET Framework to install:");
        Console.WriteLine("[1] - .NET Framework 4.5.1");
        Console.WriteLine("[2] - .NET Framework 4.6.1");
        Console.WriteLine("[3] - .NET Framework 4.8.1");
        Console.WriteLine("[4] - Return to main menu");

        string dotnetVersionOption = Console.ReadLine();
        string dotneturl = "";

        switch (dotnetVersionOption)
        {
            case "1":
                dotneturl = "https://download.microsoft.com/download/1/6/7/167F0D79-9317-48AE-AEDB-17120579F8E2/NDP451-KB2858728-x86-x64-AllOS-ENU.exe";
                break;
            case "2":
                dotneturl = "https://download.microsoft.com/download/E/4/1/E4173890-A24A-4936-9FC9-AF930FE3FA40/NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
                break;
            case "3":
                dotneturl = "https://download.microsoft.com/download/4/b/2/cd00d4ed-ebdd-49ee-8a33-eabc3d1030e3/NDP481-x86-x64-AllOS-ENU.exe";
                break;
            case "4":
                Console.Clear();
                ShowMenu();
                return;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
                ShowMenu();
                return;
        }
        DownloadAndInstall(dotneturl, "DotNetSetup.exe");
    }

    private static void HandleVisualCPlusPlusInstallation()
    {
        Console.Clear();
        Console.WriteLine("Choose the version of Visual C++ Redistributable to install:");
        Console.WriteLine("[1] - Visual C++ Redistributable 15-17-19-22 x64");
        Console.WriteLine("[2] - Visual C++ Redistributable 15-17-19-22 x86");
        Console.WriteLine("[3] - Return to main menu");

        string vcVersionOption = Console.ReadLine();
        string vcUrl = "";

        switch (vcVersionOption)
        {
            case "1":
                vcUrl = "https://aka.ms/vs/17/release/vc_redist.x64.exe";
                break;
            case "2":
                vcUrl = "https://aka.ms/vs/17/release/vc_redist.x86.exe";
                break;
            case "3":
                Console.Clear();
                ShowMenu();
                return;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(2500);
                Console.Clear();
                ShowMenu();
                return;
        }
        DownloadAndInstall(vcUrl, "VCRSetup.exe");
    }
}