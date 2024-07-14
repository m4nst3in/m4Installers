using System.Diagnostics;

class MenuGames
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
  ____                           
 / ___| __ _ _ __ ___   ___  ___ 
| |  _ / _` | '_ ` _ \ / _ \/ __|
| |_| | (_| | | | | | |  __/\__ \
 \____|\__,_|_| |_| |_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - SKLauncher (MC) ");
        Console.WriteLine("[2] - Prisma Launcher (MC) ");
        Console.WriteLine("[3] - Heroic Games Launcher");
        Console.WriteLine("[4] - Playnite");
        Console.WriteLine("[5] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("SKLauncher", "SKLauncherSetup.exe", "https://skmedix.pl/binaries/skl/3.2.8/x64/SKlauncher-3.2.exe");
                break;
            case "2":
                await Installers.DownloadAndInstall("Prisma Launcher", "PrismaSetup.exe", "https://github.com/PrismLauncher/PrismLauncher/releases/download/8.4/PrismLauncher-Windows-MSVC-Setup-8.4.exe");
                break;
            case "3":
                await Installers.DownloadAndInstall("Heroic Games Launcher", "HeroicSetup.exe", "https://github.com/Heroic-Games-Launcher/HeroicGamesLauncher/releases/download/v2.14.1/Heroic-2.14.1-Setup-x64.exe");
                break;
            case "4":
                await Installers.DownloadAndInstall("Playnite", "PlayniteSetup.exe", "https://github.com/JosefNemec/Playnite/releases/download/10.33/Playnite1033.exe");
                break;
            case "5":
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
