﻿class Installers
{
    static async Task Main(string[] args)
    {
        Console.Title = "m4Installers - Install your essential programs with ease!"; // Set the console title to "m4Installers"

        bool exit = false;

        // Method to clear the console
        static void ClearConsole()
        {
            Console.Clear();
        }

        // Create a directory if it doesn't exist
        string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers");
        Directory.CreateDirectory(appDataPath);

        while (!exit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
            ███╗   ███╗██╗  ██╗██╗███╗   ██╗███████╗████████╗ █████╗ ██╗     ██╗     ███████╗██████╗ ███████╗
            ████╗ ████║██║  ██║██║████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║     ██║     ██╔════╝██╔══██╗██╔════╝
            ██╔████╔██║███████║██║██╔██╗ ██║███████╗   ██║   ███████║██║     ██║     █████╗  ██████╔╝███████╗
            ██║╚██╔╝██║╚════██║██║██║╚██╗██║╚════██║   ██║   ██╔══██║██║     ██║     ██╔══╝  ██╔══██╗╚════██║
            ██║ ╚═╝ ██║     ██║██║██║ ╚████║███████║   ██║   ██║  ██║███████╗███████╗███████╗██║  ██║███████║
            ╚═╝     ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝╚══════╝


                                                Select an option: 

");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                              [1] - Browsers                  [9]  - Messaging");
            Console.WriteLine("                              [2] - Tools                     [10] - Media");
            Console.WriteLine("                              [3] - Game Clients              [11] - Documents");
            Console.WriteLine("                              [4] - Runtimes                  [12] - Downloader Clients");
            Console.WriteLine("                              [5] - Text Editors/IDE          [13] - File Storage");
            Console.WriteLine("                              [6] - Anti-Virus                [14] - Recorders/Live Software");
            Console.WriteLine("                              [7] - Utilities                 [15] - Photo/Video Editors");
            Console.WriteLine("                              [8] - Games                     [16] - Exit");

            var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

            switch (option)
            {
                case "1":
                    ClearConsole();
                    await MenuBrowsers.ShowMenu();
                    break;
                case "2":
                    ClearConsole();
                    await MenuTools.ShowMenu();
                    break;
                case "3":
                    ClearConsole();
                    await MenuClients.ShowMenu();
                    break;
                case "4":
                    ClearConsole();
                    await MenuRuntimes.ShowMenu();
                    break;
                case "5":
                    ClearConsole();
                    await MenuTextIDE.ShowMenu();
                    break;
                case "6":
                    ClearConsole();
                    await MenuAntivirus.ShowMenu();
                    break;
                case "7":
                    ClearConsole();
                    await MenuUtilities.ShowMenu();
                    break;
                case "8":
                    ClearConsole();
                    await MenuGames.ShowMenu();
                    break;
                case "9":
                    ClearConsole();
                    await MenuMessaging.ShowMenu();
                    break;
                case "10":
                    ClearConsole();
                    await MenuMedia.ShowMenu();
                    break;
                case "11":
                    ClearConsole();
                    await MenuDocuments.ShowMenu();
                    break;
                case "12":
                    ClearConsole();
                    await MenuDownloaders.ShowMenu();
                    break;
                case "13":
                    ClearConsole();
                    await MenuStorage.ShowMenu();
                    break;
                case "14":
                    ClearConsole();
                    await MenuRecorders.ShowMenu();
                    break;
                case "15":
                    ClearConsole();
                    await MenuPVEditor.ShowMenu();
                    break;
                case "16":
                    exit = true;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try it again.");
                    await Task.Delay(2500); // Add a delay of 2.5 seconds
                    Console.Clear();
                    break;
            }
        }
    }

    public static async Task ReturnToMainMenu()
    {
        Console.Clear();
        await Main(null);
    }
}

// _____        _                                
// | ____|   _  | |_ ___    __ _ _ __ ___   ___   
// |  _|| | | | | __/ _ \  / _` | '_ ` _ \ / _ \  
// | |__| |_| | | ||  __/ | (_| | | | | | | (_) | 
// |_____\__,_|  \__\___|  \__,_|_| |_| |_|\___( )
// | |   _   _  __ _ _ __   __ _               |/ 
// | |  | | | |/ _` | '_ \ / _` |                 
// | |__| |_| | (_| | | | | (_| |_                
// |_____\__,_|\__,_|_| |_|\__,_(_) 
