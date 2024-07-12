using System.Diagnostics;


class Installers
{
    static void Main(string[] args)
    {
        bool exit = false;

        static void ClearConsole()
        {
            Console.Clear();
        }

        Directory.CreateDirectory("C:\\m4Installers");
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("[1] - Browsers");
            Console.WriteLine("[2] - Tools");
            Console.WriteLine("[3] - Game Clients");
            Console.WriteLine("[4] - Runtimes");
            Console.WriteLine("[5] - Text Editors/IDE");
            Console.WriteLine("[6] - Anti-Virus");
            Console.WriteLine("[7] - Extra");
            Console.WriteLine("[8] - Exit");

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
                    MenuExtra.ShowMenu();
                    break;
                case "8":
                    exit = true;
                    Environment.Exit(0); // Add this line to exit the console
                    break;
                default:
                    Console.WriteLine("Invalid option. Try it again.");
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
