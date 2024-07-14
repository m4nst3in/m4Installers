using System.Diagnostics;

class MenuUtilities
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _   _ _   _ _ _ _   _           
| | | | |_(_) (_) |_(_) ___  ___ 
| | | | __| | | | __| |/ _ \/ __|
| |_| | |_| | | | |_| |  __/\__ \
 \___/ \__|_|_|_|\__|_|\___||___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - CCleaner");
        Console.WriteLine("[2] - PuTTY");
        Console.WriteLine("[3] - Filezilla");
        Console.WriteLine("[4] - Recuva");
        Console.WriteLine("[5] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("CCleaner", "CCleanerInstaller.exe", "https://www.dropbox.com/scl/fi/5ytqjerss5wpmi2mz48vf/ccsetup625.exe?rlkey=rnr3b0r4pvwpoxbchlitw267s&st=ks9kk1lv&dl=1");
                break;
            case "2":
                await Installers.DownloadAndInstall("PuTTY", "PuttyInstaller.msi", "https://the.earth.li/~sgtatham/putty/latest/w64/putty-64bit-0.81-installer.msi");
                break;
            case "3":
                await Installers.DownloadAndInstall("Filezilla", "FilezillaInstaller.exe", "https://www.dropbox.com/scl/fi/ff5czb4u1c3tonxl5ozim/FileZilla_3.67.1_win64_sponsored2-setup.exe?rlkey=8o2is5rh7yobjqe26khj5d1o0&st=dxbcftmg&dl=1");
                break;
            case "4":
                await Installers.DownloadAndInstall("Recuva", "RecuvaInstaller.exe", "https://download.ccleaner.com/rcsetup154.exe");
                break;
            case "5":
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
