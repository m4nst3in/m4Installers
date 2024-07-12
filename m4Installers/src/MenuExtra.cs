using System.Diagnostics;

class MenuExtra
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Extra \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Discord");
        Console.WriteLine("[2] - Telegram");
        Console.WriteLine("[3] - GitHub Desktop");
        Console.WriteLine("[4] - Paint.NET");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string discordUrl =
                    "https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x64";
                string discordSaveLocation = "C:\\m4Installers\\DiscordSetup.exe";
                Console.WriteLine("Downloading Discord...");

                // Download Discord installer
                using (HttpClient discordClient = new HttpClient())
                {
                    using (HttpResponseMessage discordResponse = discordClient.GetAsync(discordUrl).Result)
                    {
                        using (HttpContent discordContent = discordResponse.Content)
                        {
                            using (Stream discordStream = discordContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream discordFileStream = new FileStream(discordSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] discordBuffer = new byte[1024];
                                    int discordBytesRead;
                                    long discordTotalBytesRead = 0;
                                    long discordTotalBytes = discordResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Discord installer file
                                    while ((discordBytesRead = discordStream.Read(discordBuffer, 0, discordBuffer.Length)) > 0)
                                    {
                                        discordFileStream.Write(discordBuffer, 0, discordBytesRead);
                                        discordTotalBytesRead += discordBytesRead;

                                        if (discordTotalBytes > 0)
                                        {
                                            int discordProgress = (int)((discordTotalBytesRead * 100) / discordTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {discordProgress}% ({discordTotalBytesRead / 1024} KB of {discordTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nDiscord was downloaded successfully!");
                Process discordInstallerProcess = Process.Start(new ProcessStartInfo(discordSaveLocation) { UseShellExecute = true });

                if (discordInstallerProcess != null && !discordInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    discordInstallerProcess.WaitForExit();

                    if (discordInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(discordSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "2":
                Console.Clear();
                string telegramUrl = "https://telegram.org/dl/desktop/win64";
                string telegramSaveLocation = "C:\\m4Installers\\TelegramSetup.exe";
                Console.WriteLine("Downloading Telegram...");

                // Download Telegram installer
                using (HttpClient telegramClient = new HttpClient())
                {
                    using (HttpResponseMessage telegramResponse = telegramClient.GetAsync(telegramUrl).Result)
                    {
                        using (HttpContent telegramContent = telegramResponse.Content)
                        {
                            using (Stream telegramStream = telegramContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream telegramFileStream = new FileStream(telegramSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] telegramBuffer = new byte[1024];
                                    int telegramBytesRead;
                                    long telegramTotalBytesRead = 0;
                                    long telegramTotalBytes = telegramResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Telegram installer file
                                    while ((telegramBytesRead = telegramStream.Read(telegramBuffer, 0, telegramBuffer.Length)) > 0)
                                    {
                                        telegramFileStream.Write(telegramBuffer, 0, telegramBytesRead);
                                        telegramTotalBytesRead += telegramBytesRead;

                                        if (telegramTotalBytes > 0)
                                        {
                                            int telegramProgress = (int)((telegramTotalBytesRead * 100) / telegramTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {telegramProgress}% ({telegramTotalBytesRead / 1024} KB of {telegramTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nTelegram was downloaded successfully!");
                Process telegramInstallerProcess = Process.Start(new ProcessStartInfo(telegramSaveLocation) { UseShellExecute = true });

                if (telegramInstallerProcess != null && !telegramInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    telegramInstallerProcess.WaitForExit();

                    if (telegramInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(telegramSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "3":
                Console.Clear();
                string githubUrl = "https://central.github.com/deployments/desktop/desktop/latest/win32";
                string githubSaveLocation = "C:\\m4Installers\\GitHubSetup.exe";
                Console.WriteLine("Downloading GitHub Desktop...");

                // Download GitHub Desktop installer
                using (HttpClient githubClient = new HttpClient())
                {
                    using (HttpResponseMessage githubResponse = githubClient.GetAsync(githubUrl).Result)
                    {
                        using (HttpContent githubContent = githubResponse.Content)
                        {
                            using (Stream githubStream = githubContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream githubFileStream = new FileStream(githubSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] githubBuffer = new byte[1024];
                                    int githubBytesRead;
                                    long githubTotalBytesRead = 0;
                                    long githubTotalBytes = githubResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write GitHub Desktop installer file
                                    while ((githubBytesRead = githubStream.Read(githubBuffer, 0, githubBuffer.Length)) > 0)
                                    {
                                        githubFileStream.Write(githubBuffer, 0, githubBytesRead);
                                        githubTotalBytesRead += githubBytesRead;

                                        if (githubTotalBytes > 0)
                                        {
                                            int githubProgress = (int)((githubTotalBytesRead * 100) / githubTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {githubProgress}% ({githubTotalBytesRead / 1024} KB of {githubTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGitHub Desktop was downloaded successfully!");
                Process githubInstallerProcess = Process.Start(new ProcessStartInfo(githubSaveLocation) { UseShellExecute = true });

                if (githubInstallerProcess != null && !githubInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    githubInstallerProcess.WaitForExit();

                    if (githubInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(githubSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "4":
                Console.Clear();
                string paintnetUrl =
                    "https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip";
                string paintnetSaveLocation = "C:\\m4Installers\\PaintNETSetup.exe";
                Console.WriteLine("Downloading Paint.NET...");

                // Download Paint.NET installer
                using (HttpClient paintnetClient = new HttpClient())
                {
                    using (HttpResponseMessage paintnetResponse = paintnetClient.GetAsync(paintnetUrl).Result)
                    {
                        using (HttpContent paintnetContent = paintnetResponse.Content)
                        {
                            using (Stream paintnetStream = paintnetContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream paintnetFileStream = new FileStream(paintnetSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] paintnetBuffer = new byte[1024];
                                    int paintnetBytesRead;
                                    long paintnetTotalBytesRead = 0;
                                    long paintnetTotalBytes = paintnetResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Paint.NET installer file
                                    while ((paintnetBytesRead = paintnetStream.Read(paintnetBuffer, 0, paintnetBuffer.Length)) > 0)
                                    {
                                        paintnetFileStream.Write(paintnetBuffer, 0, paintnetBytesRead);
                                        paintnetTotalBytesRead += paintnetBytesRead;

                                        if (paintnetTotalBytes > 0)
                                        {
                                            int paintnetProgress = (int)((paintnetTotalBytesRead * 100) / paintnetTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {paintnetProgress}% ({paintnetTotalBytesRead / 1024} KB of {paintnetTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nPaint.NET was downloaded successfully!");
                Process paintnetInstallerProcess = Process.Start(new ProcessStartInfo(paintnetSaveLocation) { UseShellExecute = true });

                if (paintnetInstallerProcess != null && !paintnetInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    paintnetInstallerProcess.WaitForExit();

                    if (paintnetInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(paintnetSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try it again.");
                System.Threading.Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
