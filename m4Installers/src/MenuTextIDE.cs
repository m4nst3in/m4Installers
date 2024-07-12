using System.Diagnostics;

class MenuTextIDE
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Text Editors/IDEs \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Sublime Text");
        Console.WriteLine("[2] - Notepad++");
        Console.WriteLine("[3] - Visual Studio Code");
        Console.WriteLine("[4] - JetBrains IDEs");
        Console.WriteLine("[5] - Return to Main Menu");

        // Read user input
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string sublimeUrl =
                    "https://download.sublimetext.com/sublime_text_build_4169_x64_setup.exe";
                string sublimeSaveLocation = "C:\\m4Installers\\SublimeTextSetup.exe";
                Console.WriteLine("Downloading Sublime Text...");

                // Download Sublime Text installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(sublimeUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(sublimeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Read the response stream and write to file
                                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, bytesRead);
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

                Console.WriteLine("\nSublime Text was downloaded successfully!");
                Process sublimeInstallerProcess = Process.Start(new ProcessStartInfo(sublimeSaveLocation) { UseShellExecute = true });

                if (sublimeInstallerProcess != null && !sublimeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    sublimeInstallerProcess.WaitForExit();

                    if (sublimeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(sublimeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(sublimeSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string notepadUrl = "https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.6.7/npp.8.6.7.Installer.x64.exe";
                string notepadSaveLocation = "C:\\m4Installers\\NotepadSetup.exe";
                Console.WriteLine("Downloading Notepad++...");

                // Download Notepad++ installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(notepadUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(notepadSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Read the response stream and write to file
                                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, bytesRead);
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

                Console.WriteLine("\nNotepad++ was downloaded successfully!");
                Process notepadInstallerProcess = Process.Start(new ProcessStartInfo(notepadSaveLocation) { UseShellExecute = true });

                if (notepadInstallerProcess != null && !notepadInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    notepadInstallerProcess.WaitForExit();

                    if (notepadInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(notepadSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(notepadSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "3":
                Console.Clear();
                string vscodeUrl = "https://code.visualstudio.com/sha/download?build=stable&os=win32-x64-user";
                string vscodeSaveLocation = "C:\\m4Installers\\VSCodeSetup.exe";
                Console.WriteLine("Downloading Visual Studio Code...");

                // Download Visual Studio Code installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(vscodeUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(vscodeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Read the response stream and write to file
                                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, bytesRead);
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

                Console.WriteLine("\nVisual Studio Code was downloaded successfully!");
                Process vscodeInstallerProcess = Process.Start(new ProcessStartInfo(vscodeSaveLocation) { UseShellExecute = true });

                if (vscodeInstallerProcess != null && !vscodeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    vscodeInstallerProcess.WaitForExit();

                    if (vscodeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(vscodeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(vscodeSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "4":
                Console.Clear();
                string jetbrainsUrl =
                    "https://download.jetbrains.com/toolbox/jetbrains-toolbox-2.4.0.32175.exe";
                string jetbrainsSaveLocation = "C:\\m4Installers\\JetBrainsIDESetup.exe";
                Console.WriteLine("Downloading JetBrains Toolbox...");

                // Download JetBrains Toolbox installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(jetbrainsUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(jetbrainsSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Read the response stream and write to file
                                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        fileStream.Write(buffer, 0, bytesRead);
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

                Console.WriteLine("\nJetBrains Toolbox was downloaded successfully!");
                Process jetbrainsInstallerProcess = Process.Start(new ProcessStartInfo(jetbrainsSaveLocation) { UseShellExecute = true });

                if (jetbrainsInstallerProcess != null && !jetbrainsInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    jetbrainsInstallerProcess.WaitForExit();

                    if (jetbrainsInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(jetbrainsSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(jetbrainsSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
