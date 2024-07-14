using System.Diagnostics;

class MenuMessaging
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
         __  __                           _             
        |  \/  | ___  ___ ___  __ _  __ _(_)_ __   __ _ 
        | |\/| |/ _ \/ __/ __|/ _` |/ _` | | '_ \ / _` |
        | |  | |  __/\__ \__ \ (_| | (_| | | | | | (_| |
        |_|  |_|\___||___/___/\__,_|\__, |_|_| |_|\__, |
                                    |___/         |___/ 

        ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Discord ");
        Console.WriteLine("[2] - Telegram ");
        Console.WriteLine("[3] - TeamSpeak ");
        Console.WriteLine("[4] - Skype ");
        Console.WriteLine("[5] - Slack ");
        Console.WriteLine("[6] - Signal ");
        Console.WriteLine("[7] - Zoom ");
        Console.WriteLine("[8] - Viber ");
        Console.WriteLine("[9] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Discord", "DiscordSetup.exe", "https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64");
                break;
            case "2":
                await Installers.DownloadAndInstall("Telegram", "TelegramSetup.exe", "https://telegram.org/dl/desktop/win64");
                break;
            case "3":
                await Installers.DownloadAndInstall("Teamspeak", "TeamSpeakSetup.msi", "https://files.teamspeak-services.com/pre_releases/client/5.0.0-beta77/teamspeak-client.msi");
                break;
            case "4":
                await Installers.DownloadAndInstall("Skype", "SkypeSetup.exe", "https://www.dropbox.com/scl/fi/byuvi3phwpg5akdge54ze/Skype-8.123.0.203.exe?rlkey=gvybr84vzg85qprzwo2q28g37&st=bkk9jny8&dl=1");
                break;
            case "5":
                await Installers.DownloadAndInstall("Slack", "SlackSetup.exe", "https://slack.com/api/desktop.latestRelease?arch=x64&variant=exe&redirect=true");
                break;
            case "6":
                await Installers.DownloadAndInstall("Signal", "SignalSetup.exe", "https://updates.signal.org/desktop/signal-desktop-win-7.15.0.exe");
                break;
            case "7":
                await Installers.DownloadAndInstall("Zoom", "ZoomSetup.exe", "https://zoom.us/client/6.1.1.41705/ZoomInstallerFull.exe?archType=x64");
                break;
            case "8":
                await Installers.DownloadAndInstall("Viber", "ViberSetup.exe", "https://download.cdn.viber.com/desktop/windows/ViberSetup.exe");
                break;
            case "9":
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
