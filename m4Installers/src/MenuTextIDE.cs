using System.Diagnostics;
using static MenuIDEs;
class MenuTextIDE
{
    public static async Task ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
 _____         _     _____    _ _ _                    _____ ____  _____     
|_   _|____  _| |_  | ____|__| (_) |_ ___  _ __ ___   / /_ _|  _ \| ____|___ 
  | |/ _ \ \/ / __| |  _| / _` | | __/ _ \| '__/ __| / / | || | | |  _| / __|
  | |  __/>  <| |_  | |__| (_| | | || (_) | |  \__ \/ /  | || |_| | |___\__ \
  |_|\___/_/\_\\__| |_____\__,_|_|\__\___/|_|  |___/_/  |___|____/|_____|___/


");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Text Editors");
        Console.WriteLine("[2] - IDEs");
        Console.WriteLine("[3] - Return to Main Menu");

        // Read user input
        var option = Console.ReadLine();
            switch (option)
        {
            case "1":
                await ShowTextEditorsMenu();
                break;
            case "2":
                await ShowPLMenu();
                break;
            case "3":
                await Installers.ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowMenu();
                break;
        }
    }

    private static async Task ShowTextEditorsMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Text Editors:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Sublime Text");
        Console.WriteLine("[2] - Notepad++");
        Console.WriteLine("[3] - Visual Studio Code");
        Console.WriteLine("[4] - Atom Editor");
        Console.WriteLine("[5] - Vim Online");
        Console.WriteLine("[6] - Emacs");
        Console.WriteLine("[7] - NeoVim");
        Console.WriteLine("[8] - Return to Main Menu");

        // Read user input
        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await DownloadAndInstall("Sublime Text", "SublimeTextSetup.exe", "https://download.sublimetext.com/sublime_text_build_4169_x64_setup.exe");
                break;
            case "2":
                await DownloadAndInstall("Notepad++", "NotepadSetup.exe", "https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.6.7/npp.8.6.7.Installer.x64.exe");
                break;
            case "3":
                await DownloadAndInstall("Visual Studio Code", "VSCodeSetup.exe", "https://code.visualstudio.com/sha/download?build=stable&os=win32-x64");
                break;
            case "4":
                await DownloadAndInstall("Atom Editor", "AtomSetup.exe", "https://github.com/atom/atom/releases/download/v1.60.0/AtomSetup-x64.exe");
                break;
            case "5":
                await DownloadAndInstall("Vim Online", "VimSetup.exe", "https://github.com/vim/vim-win32-installer/releases/download/v9.1.0/gvim_9.1.0_x64_signed.exe");
                break;
            case "6":
                await DownloadAndInstall("Emacs", "EmacsSetup.exe", "http://mirror.fcix.net/gnu/emacs/windows/emacs-29/emacs-29.1-installer.exe");
                break;
            case "7":
                await DownloadAndInstall("NeoVim", "NeoVimSetup.msi", "https://github.com/neovim/neovim/releases/latest/download/nvim-win64.msi");
                break;
            case "8":
                await ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowTextEditorsMenu();
                break;
        }
    }

    public static async Task ShowPLMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Select a programming language:");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - C#");
        Console.WriteLine("[2] - Java");
        Console.WriteLine("[3] - Python");
        Console.WriteLine("[4] - JavaScript");
        Console.WriteLine("[5] - C++");
        Console.WriteLine("[6] - Ruby");
        Console.WriteLine("[7] - Go");
        Console.WriteLine("[8] - Return to Main Menu");

        // Read user input
        var option = Console.ReadLine()?.Trim(); // Trim any leading or trailing spaces

        switch (option)
        {
            case "1":
                await ShowCSharpMenu();
                break;
            case "2":
                await ShowJavaMenu();
                break;
            case "3":
                await ShowPythonMenu();
                break;
            case "4":
                await ShowJavaScriptMenu();
                break;
            case "5":
                await ShowCppMenu();
                break;
            case "6":
                await ShowRubyMenu();
                break;
            case "7":
                await ShowGoMenu();
                break;
            case "8":
                await ReturnToMainMenu();
                break;
            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                await ShowPLMenu();
                break;
        }
    }
    public static async Task ReturnToMainMenu()
    {
        Console.Clear();
        await ShowMenu();
    }

    public static async Task DownloadAndInstall(string appName, string fileName, string downloadUrl)
    {
        Console.Clear();
        string saveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", fileName);
        Console.WriteLine($"Downloading {appName}...");

        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(downloadUrl))
            {
                 using (HttpContent content = response.Content)
                {
                    await using (Stream stream = await content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create, FileAccess.Write,
                                   FileShare.None))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;
                            long totalBytesRead = 0;
                            long totalBytes = response.Content.Headers.ContentLength ?? -1;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;

                                if (totalBytes > 0)
                                {
                                    int progress = (int)((totalBytesRead * 100) / totalBytes);
                                    Console.Write(
                                        $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB of {totalBytes / 1024} KB)");
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine($"\n{appName} was downloaded successfully!");
        Process? installerProcess = Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });

        if (installerProcess != null && !installerProcess.HasExited)
        {
            Console.WriteLine("Installing...");
            installerProcess.WaitForExit();

            if (installerProcess.ExitCode == 0)
            {
                Console.WriteLine("Installation was concluded with success!");
                Console.Clear();
                File.Delete(saveLocation); // Delete the setup file
            }
            else
            {
                Console.WriteLine("Installation has failed!");
                Console.Clear();
                File.Delete(saveLocation); // Delete the setup file
            }
        }
        else
        {
            Console.WriteLine($"Failed to download {appName}. Please try again.");
        }
    }
}
