using System.Diagnostics;

class MenuBrowsers
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                                      
| __ ) _ __ _____      _____  ___ _ __ ___ 
|  _ \| '__/ _ \ \ /\ / / __|/ _ \ '__/ __|
| |_) | | | (_) \ V  V /\__ \  __/ |  \__ \
|____/|_|  \___/ \_/\_/ |___/\___|_|  |___/                                                                                   


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Brave");
        Console.WriteLine("[2] - Firefox");
        Console.WriteLine("[3] - Vivaldi");
        Console.WriteLine("[4] - Opera");
        Console.WriteLine("[5] - Opera GX");
        Console.WriteLine("[6] - Google Chrome");
        Console.WriteLine("[7] - Microsoft Edge");
        Console.WriteLine("[8] - Thorium");
        Console.WriteLine("[9] - Librewolf");
        Console.WriteLine("[10] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await DownloadAndInstall("https://github.com/brave/brave-browser/releases/download/v1.67.123/BraveBrowserStandaloneSetup.exe", "BraveSetup.exe", "Brave");
                break;

            case "2":
                await DownloadAndInstall("https://download.mozilla.org/?product=firefox-latest&os=win64", "FirefoxSetup.exe", "Firefox");
                break;

            case "3":
                await DownloadAndInstall("https://downloads.vivaldi.com/stable/Vivaldi.6.8.3381.46.x64.exe", "VivaldiSetup.exe", "Vivaldi");
                break;

            case "4":
                await DownloadAndInstall("https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google&utm_medium=ose&utm_campaign=(none)&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/download", "OperaSetup.exe", "Opera");
                break;

            case "5":
                await DownloadAndInstall("https://download3.operacdn.com/pub/opera_gx/100.0.4815.44/win/Opera_GX_100.0.4815.44_Setup_x64.exe", "OperaGXSetup.exe", "OperaGX");
                break;

            case "6":
                await DownloadAndInstall("https://www.dropbox.com/scl/fi/ec46c0o79webh2f3a7i81/ChromeSetup.exe?rlkey=jpj57k653hlqf8zghot6oyej4&st=tuomgeh9&dl=1", "ChromeSetup.exe", "Google Chrome");
                break;

            case "7":
                await DownloadAndInstall("https://c2rsetup.officeapps.live.com/c2r/downloadEdge.aspx?platform=Default&source=EdgeStablePage&Channel=Stable&language=en", "EdgeSetup.exe", "Edge");
                break;

            case "8":
                await DownloadAndInstall("https://github.com/Alex313031/Thorium-Win/releases/download/M124.0.6367.218/thorium_AVX_mini_installer.exe", "ThoriumSetup.exe", "Thorium");
                break;

            case "9":
                await DownloadAndInstall("https://gitlab.com/api/v4/projects/44042130/packages/generic/librewolf/127.0.2-2/librewolf-127.0.2-2-windows-x86_64-setup.exe", "LibrewolfSetup.exe", "Librewolf");
                break;

            case "10":
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

    private static async Task DownloadAndInstall(string downloadUrl, string fileName, string appName)
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
                                    Console.Write(
                                        $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"\n{fileName} was downloaded successfully!");
        Process? installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

        if (installerProcess != null && !installerProcess.HasExited)
        {
            Console.WriteLine("Installing...");

            // Wait until installation process has finished
            installerProcess.WaitForExit();

            if (installerProcess.ExitCode == 0)
            {
                Console.WriteLine("Installation was concluded with success!");
                Console.Clear();
                File.Delete(saveLocation);
            }
            else
            {
                Console.WriteLine("Installation has failed!");
                Console.Clear();
                File.Delete(saveLocation);
            }
        }
        else
        {
            Console.WriteLine($"Failed to download {appName}. Please try again.");
        }
    }
}
