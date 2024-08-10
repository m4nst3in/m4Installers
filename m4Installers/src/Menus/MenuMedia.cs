using System.Diagnostics;

class MenuMedia
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 __  __          _ _       
|  \/  | ___  __| (_) __ _ 
| |\/| |/ _ \/ _` | |/ _` |
| |  | |  __/ (_| | | (_| |
|_|  |_|\___|\__,_|_|\__,_|


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Spotify ");
        Console.WriteLine("[2] - Deezer ");
        Console.WriteLine("[3] - VLC Media Player ");
        Console.WriteLine("[4] - Kodi ");
        Console.WriteLine("[5] - Plex ");
        Console.WriteLine("[6] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Spotify", "spotifySetup.exe", "https://download.scdn.co/SpotifySetup.exe");
                break;
            case "2":
                await Installers.DownloadAndInstall("Deezer", "deezerSetup.exe", "https://www.deezer.com/desktop/download?platform=win32&architecture=x86");
                break;
            case "3":
                await Installers.DownloadAndInstall("VLC Media Player", "vlcSetup.exe", "https://mirror.turbozoneinternet.net.br/videolan/vlc/3.0.21/win32/vlc-3.0.21-win32.exe");
                break;
            case "4":
                await Installers.DownloadAndInstall("Kodi", "kodiSetup.exe", "https://mirrors.kodi.tv/releases/windows/win64/kodi-21.0-Omega-x64.exe?https=1");
                break;
            case "5":
                await Installers.DownloadAndInstall("Plex", "plexSetup.exe", "https://downloads.plex.tv/plex-media-server-new/1.40.4.8679-424562606/windows/PlexMediaServer-1.40.4.8679-424562606-x86_64.exe");
                break;
            case "6":
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
