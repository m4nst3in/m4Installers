using System.Diagnostics;

class MenuAntivirus
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
    _          _   _       _                
   / \   _ __ | |_(_)_   _(_)_ __ _   _ ___ 
  / _ \ | '_ \| __| \ \ / / | '__| | | / __|
 / ___ \| | | | |_| |\ V /| | |  | |_| \__ \
/_/   \_\_| |_|\__|_| \_/ |_|_|   \__,_|___/

");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Avast");
        Console.WriteLine("[2] - Kaspersky");
        Console.WriteLine("[3] - MalwareBytes");
        Console.WriteLine("[4] - Bitdefender");
        Console.WriteLine("[5] - AVG");
        Console.WriteLine("[6] - Avira");
        Console.WriteLine("[7] - SUPERAntiSpyware");
        Console.WriteLine("[8] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("Avast", "AvastSetup.exe", "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN/installertype_FULL/build_RELEASE/");
                break;

            case "2":
                await Installers.DownloadAndInstall("Kaspersky", "KasperskySetup.exe", "https://www.dropbox.com/scl/fi/mz69m452jlwbsjxedub7h/KasperskySetup.exe?rlkey=rw3nbq698ua3s9is53mt9zs1m&st=lvho0p8p&dl=1");
                break;

            case "3":
                await Installers.DownloadAndInstall("Malwarebytes", "Malwarebytesetup.exe", "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe&t=1720763650278");
                break;

            case "4":
                await Installers.DownloadAndInstall("Bitdefender", "BitdefenderSetup.exe", "https://download.bitdefender.com/windows/installer/pt-br/bitdefender_avfree.exe");
                break;

            case "5":
                await Installers.DownloadAndInstall("AVG", "AVGSetup.exe", "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN_AVG/installertype_ONLINE/build_RELEASE");
                break;

            case "6":
                await Installers.DownloadAndInstall("Avira", "AviraSetup.exe", "https://package.avira.com/download/spotlight-windows-bootstrapper/avira_en_sptl1_316508c615bffe3f__ws-spotlight-release.exe");
                break;

            case "7":
                await Installers.DownloadAndInstall("SUPERAntiSpyware", "SUPERAntiSpywareSetup.exe", "https://secure.superantispyware.com/SUPERAntiSpyware.exe");
                break;

            case "8":
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
