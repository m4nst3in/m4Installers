using System.Diagnostics;

class MenuDownloaders
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                      _                 _               
|  _ \  _____      ___ __ | | ___   __ _  __| | ___ _ __ ___ 
| | | |/ _ \ \ /\ / / '_ \| |/ _ \ / _` |/ _` |/ _ \ '__/ __|
| |_| | (_) \ V  V /| | | | | (_) | (_| | (_| |  __/ |  \__ \
|____/ \___/ \_/\_/ |_| |_|_|\___/ \__,_|\__,_|\___|_|  |___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - uTorrent ");
        Console.WriteLine("[2] - BitTorrent ");
        Console.WriteLine("[3] - qBittorrent ");
        Console.WriteLine("[4] - Transmission ");
        Console.WriteLine("[5] - Vuze ");
        Console.WriteLine("[6] - Deluge ");
        Console.WriteLine("[7] - Free Download Manager ");
        Console.WriteLine("[8] - JDownloader ");
        Console.WriteLine("[9] - Internet Download Manager ");
        Console.WriteLine("[10] - Return to Main Menu ");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("uTorrent", "uTorrentSetup.exe", "https://download-hr.utorrent.com/track/beta/endpoint/utorrent/os/windows");
                break;

            case "2":
                await Installers.DownloadAndInstall("BitTorrent", "BitTorrentSetup.exe", "https://download-new.utorrent.com/endpoint/bittorrent/os/windows/track/stable/");
                break;

            case "3":
                await Installers.DownloadAndInstall("qBittorrent", "qBittorrentSetup.exe", "https://www.dropbox.com/scl/fi/bbthely0e6m64nmmav0yj/qbittorrent_4.6.5_x64_setup.exe?rlkey=qg8wt0lll4l0ppda094todubk&st=7ee8soaw&dl=1");
                break;

            case "4":
                await Installers.DownloadAndInstall("Transmission", "TransmissionSetup.msi", "https://github.com/transmission/transmission/releases/download/4.0.6/transmission-4.0.6-x64.msi");
                break;

            case "5":
                await Installers.DownloadAndInstall("Vuze", "VuzeSetup.exe", "https://cf1.vuze.com/installers/VuzeBittorrentClientInstaller.exe");
                break;

            case "6":
                await Installers.DownloadAndInstall("Deluge", "DelugeSetup.exe", "https://ftp.osuosl.org/pub/deluge/windows/deluge-2.1.1-win64-setup.exe");
                break;

            case "7":
                await Installers.DownloadAndInstall("Free Download Manager", "FDMSetup.exe", "https://files2.freedownloadmanager.org/6/latest/fdm_x64_setup.exe");
                break;

            case "8":
                await Installers.DownloadAndInstall("JDownloader", "JDownloaderSetup.exe", "https://sdl.adaware.com/?bundleid=JD003&savename=JDownloaderSetup.exe");
                break;

            case "9":
                await Installers.DownloadAndInstall("Internet Download Manager", "IDMSetup.exe", "https://mirror2.internetdownloadmanager.com/idman642build14.exe?v=lt&filename=idman642build14.exe");
                break;

            case "10":
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
}
