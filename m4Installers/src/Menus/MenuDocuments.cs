using System.Diagnostics;

class MenuDocuments
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____                                        _       
|  _ \  ___   ___ _   _ _ __ ___   ___ _ __ | |_ ___ 
| | | |/ _ \ / __| | | | '_ ` _ \ / _ \ '_ \| __/ __|
| |_| | (_) | (__| |_| | | | | | |  __/ | | | |_\__ \
|____/ \___/ \___|\__,_|_| |_| |_|\___|_| |_|\__|___/

");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - OpenOffice ");
        Console.WriteLine("[2] - LibreOffice Writer ");
        Console.WriteLine("[3] - WPS Office ");
        Console.WriteLine("[4] - Obsidian ");
        Console.WriteLine("[5] - Return to Main Menu ");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("OpenOffice", "OpenOfficeSetup.exe", "https://sourceforge.net/projects/openofficeorg.mirror/files/4.1.15/binaries/pt-BR/Apache_OpenOffice_4.1.15_Win_x86_install_pt-BR.exe/download");
                break;
            case "2":
                await Installers.DownloadAndInstall("LibreOffice Writer", "LibreOfficeSetup.msi", "https://download.documentfoundation.org/libreoffice/stable/24.2.5/win/x86_64/LibreOffice_24.2.5_Win_x86-64.msi");
                break;
            case "3":
                await Installers.DownloadAndInstall("WPS Office", "WPSOfficeSetup.exe", "https://wdl1.pcfg.cache.wpscdn.com/wpsdl/wpsoffice/onlinesetup/distsrc/200.1087/wpsinst/wps_office_inst.exe");
                break;
            case "4":
                await Installers.DownloadAndInstall("Obsidian (Vault)", "ObsidianSetup.exe", "https://github.com/obsidianmd/obsidian-releases/releases/download/v1.6.5/Obsidian-1.6.5.exe");
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
