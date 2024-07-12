using System.Diagnostics;


class MenuMessaging
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Messaging Apps \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Discord ");
        Console.WriteLine("[2] - Telegram ");
        Console.WriteLine("[3] - TeamSpeak ");
        Console.WriteLine("[4] - Skype ");
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
                        File.Delete(discordSaveLocation); // Delete the setup file
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
                        File.Delete(telegramSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string teamspeakUrl = "https://files.teamspeak-services.com/pre_releases/client/5.0.0-beta77/teamspeak-client.msi";
                string teamspeakSaveLocation = "C:\\m4Installers\\TeamSpeakSetup.msi";
                Console.WriteLine("Downloading Teamspeak...");

                // Download teamspeak installer
                using (HttpClient teamspeakClient = new HttpClient())
                {
                    using (HttpResponseMessage teamspeakResponse = teamspeakClient.GetAsync(teamspeakUrl).Result)
                    {
                        using (HttpContent teamspeakContent = teamspeakResponse.Content)
                        {
                            using (Stream teamspeakStream = teamspeakContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream teamspeakFileStream = new FileStream(teamspeakSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] teamspeakBuffer = new byte[1024];
                                    int teamspeakBytesRead;
                                    long teamspeakTotalBytesRead = 0;
                                    long teamspeakTotalBytes = teamspeakResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((teamspeakBytesRead = teamspeakStream.Read(teamspeakBuffer, 0, teamspeakBuffer.Length)) > 0)
                                    {
                                        teamspeakFileStream.Write(teamspeakBuffer, 0, teamspeakBytesRead);
                                        teamspeakTotalBytesRead += teamspeakBytesRead;

                                        if (teamspeakTotalBytes > 0)
                                        {
                                            int teamspeakProgress = (int)((teamspeakTotalBytesRead * 100) / teamspeakTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {teamspeakProgress}% ({teamspeakTotalBytesRead / 1024} KB of {teamspeakTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nTeamSpeak was downloaded successfully!");
                Process teamspeakInstallerProcess = Process.Start(new ProcessStartInfo(teamspeakSaveLocation) { UseShellExecute = true });

                if (teamspeakInstallerProcess != null && !teamspeakInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    teamspeakInstallerProcess.WaitForExit();

                    if (teamspeakInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(teamspeakSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(teamspeakSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "4":
                Console.Clear();
                string skypeUrl = "https://download.skype.com/s4l/download/win/Skype-8.123.0.203.exe";
                string skypeSaveLocation = "C:\\m4Installers\\SkypeSetup.exe";
                Console.WriteLine("Downloading skype...");

                // Download skype installer
                using (HttpClient skypeClient = new HttpClient())
                {
                    using (HttpResponseMessage skypeResponse = skypeClient.GetAsync(skypeUrl).Result)
                    {
                        using (HttpContent skypeContent = skypeResponse.Content)
                        {
                            using (Stream skypeStream = skypeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream skypeFileStream = new FileStream(skypeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] skypeBuffer = new byte[1024];
                                    int skypeBytesRead;
                                    long skypeTotalBytesRead = 0;
                                    long skypeTotalBytes = skypeResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((skypeBytesRead = skypeStream.Read(skypeBuffer, 0, skypeBuffer.Length)) > 0)
                                    {
                                        skypeFileStream.Write(skypeBuffer, 0, skypeBytesRead);
                                        skypeTotalBytesRead += skypeBytesRead;

                                        if (skypeTotalBytes > 0)
                                        {
                                            int skypeProgress = (int)((skypeTotalBytesRead * 100) / skypeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {skypeProgress}% ({skypeTotalBytesRead / 1024} KB of {skypeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nskype was downloaded successfully!");
                Process skypeInstallerProcess = Process.Start(new ProcessStartInfo(skypeSaveLocation) { UseShellExecute = true });

                if (skypeInstallerProcess != null && !skypeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    skypeInstallerProcess.WaitForExit();

                    if (skypeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(skypeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(skypeSaveLocation); // Delete the setup file

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
