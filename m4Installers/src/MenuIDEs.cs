
class MenuIDEs
{
    public static async Task ShowCSharpMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("C# IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Visual Studio");
        Console.WriteLine("[2] - IntelliJ Rider");
        Console.WriteLine("[3] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("Visual Studio", "VisualStudioSetup.exe", "https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022");
                break;
            case "2":
                await MenuTextIDE.DownloadAndInstall("IntelliJ Rider", "RiderSetup.exe", "https://download.jetbrains.com/rider/JetBrains.Rider-2024.1.4.exe");
                break;
            case "3":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowCSharpMenu();
                break;
        }
    }

    public static async Task ShowJavaMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Java IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Eclipse");
        Console.WriteLine("[2] - IntelliJ IDEA Community Edition");
        Console.WriteLine("[3] - IntelliJ IDEA Ultimate");
        Console.WriteLine("[4] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("Eclipse", "EclipseSetup.exe", "https://www.eclipse.org/downloads/download.php?file=/technology/epp/downloads/release/2024-06/R/eclipse-java-2024-06-R-win32-x86_64.zip");
                break;
            case "2":
                await MenuTextIDE.DownloadAndInstall("IntelliJ IDEA Community Edition", "IntelliJCSetup.exe", "https://download.jetbrains.com/idea/ideaIC-2024.1.4.exe");
                break;
            case "3":
                await MenuTextIDE.DownloadAndInstall("IntelliJ IDEA Ultimate Edition", "IntelliJUSetup.exe", "https://download.jetbrains.com/idea/ideaIU-2024.1.4.exe");
                break;
            case "4":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowJavaMenu();
                break;
        }
    }

    public static async Task ShowPythonMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Python IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - PyCharm Professional");
        Console.WriteLine("[2] - PyCharm Community Edition");
        Console.WriteLine("[3] - Spyder");
        Console.WriteLine("[4] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("PyCharm Professional", "PyCharmPSetup.exe", "https://download.jetbrains.com/python/pycharm-professional-2024.1.4.exe");
                break;
            case "2":
                await MenuTextIDE.DownloadAndInstall("PyCharm Community Edition", "PyCharmCSetup.exe", "https://download.jetbrains.com/python/pycharm-community-2024.1.4.exe");
                break;
            case "3":
                await MenuTextIDE.DownloadAndInstall("Spyder", "SpyderSetup.exe", "https://github.com/spyder-ide/spyder/releases/latest/download/Spyder_64bit_full.exe");
                break;
            case "4":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowPythonMenu();
                break;
        }
    }

    public static async Task ShowJavaScriptMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("JavaScript IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Eclipse");
        Console.WriteLine("[2] - WebStorm");
        Console.WriteLine("[3] - Visual Studio");
        Console.WriteLine("[4] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("Eclipse", "EclipseSetup.exe", "https://www.eclipse.org/downloads/download.php?file=/technology/epp/downloads/release/2024-06/R/eclipse-java-2024-06-R-win32-x86_64.zip");
                break;
            case "2":
                await MenuTextIDE.DownloadAndInstall("WebStorm", "WebStormSetup.exe", "https://download.jetbrains.com/webstorm/WebStorm-2024.1.5.exe");
                break;
            case "3":
                await MenuTextIDE.DownloadAndInstall("Visual Studio", "VisualStudioSetup.exe", "https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022");
                break;
            case "4":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowJavaScriptMenu();
                break;
        }
    }

    public static async Task ShowCppMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("C++ IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Visual Studio");
        Console.WriteLine("[2] - CLion");
        Console.WriteLine("[3] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("Visual Studio", "VisualStudioSetup.exe", "https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022");
                break;
            case "2":
                await MenuTextIDE.DownloadAndInstall("CLion", "CLionSetup.exe", "https://download.jetbrains.com/cpp/CLion-2024.1.4.exe");
                break;
            case "3":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowCppMenu();
                break;
        }
    }

    public static async Task ShowRubyMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Ruby IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - RubyMine");
        Console.WriteLine("[2] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("RubyMine", "RubyMineSetup.exe", "https://download.jetbrains.com/ruby/RubyMine-2024.1.4.exe");
                break;
            case "2":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowRubyMenu();
                break;
        }
    }

    public static async Task ShowGoMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Go IDEs:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - GoLand");
        Console.WriteLine("[2] - Return to Main Menu");

        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await MenuTextIDE.DownloadAndInstall("GoLand", "GoLandSetup.exe", "https://download.jetbrains.com/go/goland-2024.1.4.exe");
                break;
            case "2":
                await MenuTextIDE.ShowPLMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowGoMenu();
                break;
        }
    }
}
