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
        Console.WriteLine("[10] - Floorp");
        Console.WriteLine("[11] - Arc Browser");
        Console.WriteLine("[12] - Waterfox");
        Console.WriteLine("[13] - Tor Browser");
        Console.WriteLine("[14] - Tempest Browser");
        Console.WriteLine("[15] - Ungoogled Chromium");
        Console.WriteLine("[16] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Brave", "BraveSetup.exe", "https://github.com/brave/brave-browser/releases/download/v1.67.123/BraveBrowserStandaloneSetup.exe");
                break;

            case "2":
                await Installers.DownloadAndInstall("Firefox", "FirefoxSetup.exe", "https://download.mozilla.org/?product=firefox-latest&os=win64");
                break;

            case "3":
                await Installers.DownloadAndInstall("Vivaldi", "VivaldiSetup.exe", "https://downloads.vivaldi.com/stable/Vivaldi.6.8.3381.46.x64.exe");
                break;

            case "4":
                await Installers.DownloadAndInstall("Opera", "OperaSetup.exe", "https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google&utm_medium=ose&utm_campaign=(none)&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/download");
                break;

            case "5":
                await Installers.DownloadAndInstall("OperaGX", "OperaGXSetup.exe", "https://download3.operacdn.com/pub/opera_gx/100.0.4815.44/win/Opera_GX_100.0.4815.44_Setup_x64.exe");
                break;

            case "6":
                await Installers.DownloadAndInstall("Google Chrome", "ChromeSetup.exe", "https://www.dropbox.com/scl/fi/ec46c0o79webh2f3a7i81/ChromeSetup.exe?rlkey=jpj57k653hlqf8zghot6oyej4&st=tuomgeh9&dl=1");
                break;

            case "7":
                await Installers.DownloadAndInstall("Edge", "EdgeSetup.exe", "https://c2rsetup.officeapps.live.com/c2r/downloadEdge.aspx?platform=Default&source=EdgeStablePage&Channel=Stable&language=en");
                break;

            case "8":
                await Installers.DownloadAndInstall("Thorium", "ThoriumSetup.exe", "https://github.com/Alex313031/Thorium-Win/releases/download/M124.0.6367.218/thorium_AVX_mini_installer.exe");
                break;

            case "9":
                await Installers.DownloadAndInstall("Librewolf", "LibrewolfSetup.exe", "https://gitlab.com/api/v4/projects/44042130/packages/generic/librewolf/127.0.2-2/librewolf-127.0.2-2-windows-x86_64-setup.exe");
                break;

            case "10":
                await Installers.DownloadAndInstall("Floorp", "FloorpSetup.exe", "https://github.com/Floorp-Projects/Floorp/releases/download/v11.15.0/floorp-win64.installer.exe");
                break;

            case "11":
                await Installers.DownloadAndInstall("Arc Browser", "ArcBrowserSetup.exe", "https://releases.arc.net/windows/ArcInstaller.exe");
                break;

            case "12":
                await Installers.DownloadAndInstall("Waterfox", "WaterfoxSetup.exe", "https://cdn1.waterfox.net/waterfox/releases/G6.0.17/WINNT_x86_64/Waterfox%20Setup%20G6.0.17.exe");
                break;

            case "13":
                await Installers.DownloadAndInstall("Tor Browser", "TorSetup.exe", "https://www.torproject.org/dist/torbrowser/13.5.1/tor-browser-windows-x86_64-portable-13.5.1.exe");
                break;

            case "14":
                await Installers.DownloadAndInstall("Tempest Browser", "TempestBrowserSetup.exe", "https://downloads.tempest.com/tempestinstaller.exe");
                break;
            
            case "15":
                await Installers.DownloadAndInstall("Ungoogled Chromium", "UnChromium.exe", "https://github.com/ungoogled-software/ungoogled-chromium-windows/releases/download/127.0.6533.72-1.1/ungoogled-chromium_127.0.6533.72-1.1_installer_x64.exe");
                break;
            
            case "16":
                await Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                await Task.Delay(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }
}
