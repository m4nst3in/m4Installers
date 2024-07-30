using System.Diagnostics;

class MenuStorage
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____  _                             
/ ___|| |_ ___  _ __ __ _  __ _  ___ 
\___ \| __/ _ \| '__/ _` |/ _` |/ _ \
 ___) | || (_) | | | (_| | (_| |  __/
|____/ \__\___/|_|  \__,_|\__, |\___|
                          |___/      


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Dropbox ");
        Console.WriteLine("[2] - MEGA ");
        Console.WriteLine("[3] - SugarSync ");
        Console.WriteLine("[4] - Google Drive ");
        Console.WriteLine("[5] - OneDrive ");
        Console.WriteLine("[6] - Return to Main Menu ");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Dropbox", "DropboxSetup.exe", "https://www.dropbox.com/download?plat=win&type=full");
                break;

            case "2":
                await Installers.DownloadAndInstall("MEGA", "MEGASyncSetup.exe", "https://mega.nz/MEGAsyncSetup.exe");
                break;

            case "3":
                await Installers.DownloadAndInstall("SugarSync", "SugarSyncSetup.exe", "https://sugarsync.com/downloads/p/SugarSyncSetup.exe");
                break;

            case "4":
                await Installers.DownloadAndInstall("Google Drive", "GoogleDriveSetup.exe", "https://dl.google.com/drive-file-stream/GoogleDriveSetup.exe");
                break;

            case "5":
                await Installers.DownloadAndInstall("OneDrive", "OneDriveSetup.exe", "https://oneclient.sfx.ms/Win/Installers/24.126.0623.0001/amd64/OneDriveSetup.exe");
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
