using System.Diagnostics;

class MenuClients
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
              ____                         ____ _ _            _       
             / ___| __ _ _ __ ___   ___   / ___| (_) ___ _ __ | |_ ___ 
            | |  _ / _` | '_ ` _ \ / _ \ | |   | | |/ _ \ '_ \| __/ __|
            | |_| | (_| | | | | | |  __/ | |___| | |  __/ | | | |_\__ \
             \____|\__,_|_| |_| |_|\___|  \____|_|_|\___|_| |_|\__|___/



            ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Steam");
        Console.WriteLine("[2] - Epic Games Launcher");
        Console.WriteLine("[3] - EA App (Origin)");
        Console.WriteLine("[4] - GOG");
        Console.WriteLine("[5] - Ubisoft Connect");
        Console.WriteLine("[6] - Battle.net");
        Console.WriteLine("[7] - Xbox App");
        Console.WriteLine("[8] - Itch.io");
        Console.WriteLine("[9] - Rockstar Launcher");
        Console.WriteLine("[10] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Steam", "SteamSetup.exe", "https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe");
                break;
            case "2":
                await Installers.DownloadAndInstall("Epic Games Launcher", "EGSSetup.msi", "https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi");
                break;
            case "3":
                await Installers.DownloadAndInstall("EA App", "OriginSetup.exe", "https://origin-a.akamaihd.net/EA-Desktop-Client-Download/installer-releases/EAappInstaller.exe");
                break;
            case "4":
                await Installers.DownloadAndInstall("GOG Galaxy", "GOGSetup.exe", "https://cdn.gog.com/open/galaxy/client/2.0.74.352/setup_galaxy_2.0.74.352.exe");
                break;
            case "5":
                await Installers.DownloadAndInstall("Ubisoft Connect", "UbiConnectSetup.exe", "https://ubi.li/4vxt9");
                break;
            case "6":
                await Installers.DownloadAndInstall("Battle.net", "BattleNetSetup.exe", "https://downloader.battle.net//download/getInstallerForGame?os=win&gameProgram=BATTLENET_APP&version=Live");
                break;
            case "7":
                await Installers.DownloadAndInstall("Xbox App", "XboxAppSetup.exe", "https://assets.xbox.com/installer/20190628.8/anycpu/XboxInstaller.exe");
                break;
            case "8":
                await Installers.DownloadAndInstall("Itch.io", "ItchIOSetup.exe", "https://www.dropbox.com/scl/fi/xz9f99o403o2i00gxdci7/itch-setup.exe?rlkey=5ri0faw8hr22qoykqvvscjhsr&st=wov1z2d6&dl=1");
                break;
            case "9":
                await Installers.DownloadAndInstall("Rockstar Launcher", "RockstarLauncherSetup.exe", "https://gamedownloads.rockstargames.com/public/installer/Rockstar-Games-Launcher.exe");
                break;
            case "10":
                await Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                await Task.Delay(3000); // Add a delay of 3 Thread.Sleep
                Console.Clear();
                await ShowMenu();
                break;
        }
    }
}

