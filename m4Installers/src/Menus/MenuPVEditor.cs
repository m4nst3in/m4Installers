using System.Diagnostics;
class MenuPVEditor
{
    public static async Task ShowMenu()
    {

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 ____  _           _           __     ___     _              _____    _ _ _   
|  _ \| |__   ___ | |_ ___     \ \   / (_) __| | ___  ___   | ____|__| (_) |_ ___  _ __ ___  
| |_) | '_ \ / _ \| __/ _ \ ____\ \ / /| |/ _` |/ _ \/ _ \  |  _| / _` | | __/ _ \| '__/ __|
|  __/| | | | (_) | || (_) |_____\ V / | | (_| |  __/ (_) | | |__| (_| | | || (_) | |  \__ \
|_|   |_| |_|\___/ \__\___/       \_/  |_|\__,_|\___|\___/  |_____\__,_|_|\__\___/|_|  |___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - GIMP");
        Console.WriteLine("[2] - Paint.NET");
        Console.WriteLine("[3] - OpenShot");
        Console.WriteLine("[4] - Krita");
        Console.WriteLine("[5] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await Installers.DownloadAndInstall("GIMP", "GIMPSetup.exe", "https://download.gimp.org/gimp/v2.10/windows/gimp-2.10.38-setup.exe");
                break;

            case "2":
                await Installers.DownloadAndInstall("Paint.NET", "PaintDotNetSetup.exe", "https://www.dropbox.com/scl/fi/q490njix95u49b10f2xnp/paint.net.5.0.13.install.anycpu.web.exe?rlkey=u06viwqd1jh7mjl7rclg3z4x9&st=7upuevwe&dl=1");
                break;

            case "3":
                await Installers.DownloadAndInstall("OpenShot", "OpenShotSetup.exe", "https://github.com/OpenShot/openshot-qt/releases/download/v3.2.1/OpenShot-v3.2.1-x86_64.exe");
                break;

            case "4":
                await Installers.DownloadAndInstall("Krita", "KritaSetup.exe", "https://download.kde.org/stable/krita/4.4.5/krita-x64-4.4.5-setup.exe");
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
