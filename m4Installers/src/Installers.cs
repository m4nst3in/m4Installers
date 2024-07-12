class Installers
{
    static void Main(string[] args)
    {
        Console.Title = "m4Installers - Install your essential programs with ease!"; // Set the console title to "m4Installers"

        bool exit = false;

        // Method to clear the console
        static void ClearConsole()
        {
            Console.Clear();
        }

        // Create a directory if it doesn't exist
        Directory.CreateDirectory("C:\\m4Installers");

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
            Console.WriteLine("                              [4] - Runtimes                  [12] - Torrent Clients");
            Console.WriteLine("                              [5] - Text Editors/IDE          [13] - File Storage");
            Console.WriteLine("                              [6] - Anti-Virus                [14] - Youtube Downloader");
            Console.WriteLine("                              [7] - Utilities                 [15] - Photo Editors");
            Console.WriteLine("                              [8] - Games                     [16] - Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ClearConsole();
                    MenuBrowsers.ShowMenu();
                    break;
                case "2":
                    ClearConsole();
                    MenuTools.ShowMenu();
                    break;
                case "3":
                    ClearConsole();
                    MenuClients.ShowMenu();
                    break;
                case "4":
                    ClearConsole();
                    MenuRuntimes.ShowMenu();
                    break;
                case "5":
                    ClearConsole();
                    MenuTextIDE.ShowMenu();
                    break;
                case "6":
                    ClearConsole();
                    MenuAntivirus.ShowMenu();
                    break;
                case "7":
                    ClearConsole();
                    MenuUtilities.ShowMenu();
                    break;
                case "8":
                    ClearConsole();
                    MenuGames.ShowMenu();
                    break;
                case "9":
                    ClearConsole();
                    MenuMessaging.ShowMenu();
                    break;
                case "10":
                    ClearConsole();
                    MenuMedia.ShowMenu();
                    break;
                case "11":
                    ClearConsole();
                    MenuDocuments.ShowMenu();
                    break;
                case "12":
                    ClearConsole();
                    MenuTorrents.ShowMenu();
                    break;
                case "16":
                    exit = true;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try it again.");
                    Thread.Sleep(2500); // Add a delay of 2.5 seconds
                    Console.Clear();
                    break;
            }
        }
    }

    public static void ReturnToMainMenu()
    {
        Console.Clear();
        Main(null);
    }
}
