﻿using System.Diagnostics;

class MenuRuntimes
{

    public static async Task ShowMenu()
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
        Console.WriteLine("[5] - OpenJDK");
        Console.WriteLine("[6] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await DownloadAndInstall("https://www.dropbox.com/scl/fi/0ugbs3rdcxmqlo9ufgl0d/aio-runtimes_v2.5.0.exe?rlkey=sdq9n2k79eezegvd4u58v5tev&st=29r8wkzg&dl=1", "AIOSetup.exe", "AllInOneRuntimes");
                break;

            case "2":
                await HandleDotNetFrameworkInstallation();
                break;

            case "3":
                await HandleVisualCPlusPlusInstallation();
                break;

            case "4":
                await DownloadAndInstall("https://download.microsoft.com/download/1/7/1/1718CCC4-6315-4D8E-9543-8E28A4E18C4C/dxwebsetup.exe", "DXWebSetup.exe", "DirectX");
                break;

            case "5":
                await HandleOpenJDKInstallation();
                break;

            case "6":
                await Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500);
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

        using var client = new HttpClient();
        using var response = await client.GetAsync(downloadUrl);
        using var stream = await response.Content.ReadAsStreamAsync();
        using var fs = new FileStream(saveLocation, FileMode.Create);

        byte[] buffer = new byte[8192];
        int bytesRead;
        long totalBytesRead = 0;
        long totalBytes = response.Content.Headers.ContentLength ?? -1;

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await fs.WriteAsync(buffer, 0, bytesRead);
            totalBytesRead += bytesRead;

            if (totalBytes > 0)
            {
                int progress = (int)((totalBytesRead * 100) / totalBytes);
                Console.Write($"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
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
        else
        {
            Console.WriteLine($"Failed to download {appName}. Please try again later.");
            await Task.Delay(2500);
            Console.Clear();
            await ShowMenu();
        }
    }

private static async Task HandleDotNetFrameworkInstallation()
    {
        Console.Clear();
        Console.WriteLine("Choose the version of .NET Framework to install:");
        Console.WriteLine("[1] - .NET Framework 4.5.1");
        Console.WriteLine("[2] - .NET Framework 4.6.1");
        Console.WriteLine("[3] - .NET Framework 4.8.1");
        Console.WriteLine("[4] - Return to main menu");

        var dotnetVersionOption = Console.ReadLine();
        string dotnetUrl = "";

        switch (dotnetVersionOption)
        {
            case "1":
                dotnetUrl = "https://download.microsoft.com/download/1/6/7/167F0D79-9317-48AE-AEDB-17120579F8E2/NDP451-KB2858728-x86-x64-AllOS-ENU.exe";
                break;
            case "2":
                dotnetUrl = "https://download.microsoft.com/download/E/4/1/E4173890-A24A-4936-9FC9-AF930FE3FA40/NDP461-KB3102436-x86-x64-AllOS-ENU.exe";
                break;
            case "3":
                dotnetUrl = "https://download.microsoft.com/download/4/b/2/cd00d4ed-ebdd-49ee-8a33-eabc3d1030e3/NDP481-x86-x64-AllOS-ENU.exe";
                break;
            case "4":
                Console.Clear();
                await ShowMenu();
                return;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500);
                Console.Clear();
                await ShowMenu();
                return;
        }
        await DownloadAndInstall(dotnetUrl, "DotNetSetup.exe", ".NET Framework");
    }

    private static async Task HandleVisualCPlusPlusInstallation()
    {
        Console.Clear();
        Console.WriteLine("Choose the version of Visual C++ Redistributable to install:");
        Console.WriteLine("[1] - Visual C++ Redistributable 15-17-19-22 x64");
        Console.WriteLine("[2] - Visual C++ Redistributable 15-17-19-22 x86");
        Console.WriteLine("[3] - Return to main menu");

        var vcVersionOption = Console.ReadLine();
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
                await ShowMenu();
                return;
            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500);
                Console.Clear();
                await ShowMenu();
                return;
        }
        await DownloadAndInstall(vcUrl, "VCRSetup.exe", "Visual C++ Redistributable");
    }

    private static async Task HandleOpenJDKInstallation()
    {
        Console.Clear();
        Console.WriteLine("Choose the type of OpenJDK to install:");
        Console.WriteLine("[1] - OpenJDK JRE");
        Console.WriteLine("[2] - OpenJDK SDK");
        Console.WriteLine("[3] - Return to main menu");

        var OpenJDKTypeOption = Console.ReadLine();
        string OpenJDKUrl = "";

        switch (OpenJDKTypeOption)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("Choose the version of OpenJDK JRE to install:");
                Console.WriteLine("[1] - OpenJDK 8 JRE (x64)");
                Console.WriteLine("[2] - OpenJDK 8 JRE (x86)");
                Console.WriteLine("[3] - OpenJDK 11 JRE (x64)");
                Console.WriteLine("[4] - OpenJDK 17 JRE (x64)");
                Console.WriteLine("[5] - OpenJDK 21 JRE (x64)");
                Console.WriteLine("[6] - Return to main menu");

                var OpenJDKVersionOption = Console.ReadLine();

                switch (OpenJDKVersionOption)
                {
                    case "1":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk-jre/8u412-b08/openlogic-openjdk-jre-8u412-b08-windows-x64.msi";
                        break;
                    case "2":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk-jre/8u412-b08/openlogic-openjdk-jre-8u412-b08-windows-x32.msi";
                        break;
                    case "3":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk-jre/11.0.23+9/openlogic-openjdk-jre-11.0.23+9-windows-x64.msi";
                        break;
                    case "4":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk-jre/17.0.11+9/openlogic-openjdk-jre-17.0.11+9-windows-x64.msi";
                        break;
                    case "5":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk-jre/21.0.3+9/openlogic-openjdk-jre-21.0.3+9-windows-x64.msi";
                        break;
                    case "6":
                        Console.Clear();
                        await ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try it again.");
                        await Task.Delay(2500);
                        Console.Clear();
                        await ShowMenu();
                        return;
                }
                await DownloadAndInstall(OpenJDKUrl, "OpenJDKSetup.msi", "OpenJDK JRE");
                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Choose the version of OpenJDK JDK to install:");
                Console.WriteLine("[1] - OpenJDK 8 JDK (x64)");
                Console.WriteLine("[2] - OpenJDK 8 JDK (x86)");
                Console.WriteLine("[3] - OpenJDK 11 JDK (x64)");
                Console.WriteLine("[4] - OpenJDK 17 JDK (x64)");
                Console.WriteLine("[5] - OpenJDK 21 JDK (x64)");
                Console.WriteLine("[6] - Return to main menu");

                var OpenJDKSdkVersionOption = Console.ReadLine();

                switch (OpenJDKSdkVersionOption)
                {
                    case "1":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk/8u412-b08/openlogic-openjdk-8u412-b08-windows-x64.msi";
                        break;
                    case "2":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk/8u412-b08/openlogic-openjdk-8u412-b08-windows-x32.msi";
                        break;
                    case "3":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk/11.0.23+9/openlogic-openjdk-11.0.23+9-windows-x64.msi";
                        break;
                    case "4":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk/17.0.11+9/openlogic-openjdk-17.0.11+9-windows-x64.msi";
                        break;
                    case "5":
                        OpenJDKUrl = "https://builds.openlogic.com/downloadJDK/openlogic-openjdk/21.0.3+9/openlogic-openjdk-21.0.3+9-windows-x64.msi";
                        break;
                    case "6":
                        Console.Clear();
                        await ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try it again.");
                        await Task.Delay(2500);
                        Console.Clear();
                        await ShowMenu();
                        return;
                }
                await DownloadAndInstall(OpenJDKUrl, "OpenJDKSetup.msi", "OpenJDK JDK");
                break;

            case "3":
                Console.Clear();
                await ShowMenu();
                return;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500);
                Console.Clear();
                await ShowMenu();
                return;
        }
    }
}