using System.Diagnostics;


class MenuGames
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Games \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - SKLauncher (MC) ");
        Console.WriteLine("[2] - Prisma Launcher (MC) ");
        Console.WriteLine("[3] - Heroic Games Launcher");
        Console.WriteLine("[4] - Playnite");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string sklauncherUrl = "https://skmedix.pl/binaries/skl/3.2.8/x64/SKlauncher-3.2.exe";
                string sklauncherSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "SKLauncherSetup.exe");
                Console.WriteLine("Downloading SKLauncher...");

                // Download sklauncher installer
                using (HttpClient sklauncherClient = new HttpClient())
                {
                    using (HttpResponseMessage sklauncherResponse = sklauncherClient.GetAsync(sklauncherUrl).Result)
                    {
                        using (HttpContent sklauncherContent = sklauncherResponse.Content)
                        {
                            using (Stream sklauncherStream = sklauncherContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream sklauncherFileStream = new FileStream(sklauncherSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] sklauncherBuffer = new byte[1024];
                                    int sklauncherBytesRead;
                                    long sklauncherTotalBytesRead = 0;
                                    long sklauncherTotalBytes = sklauncherResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((sklauncherBytesRead = sklauncherStream.Read(sklauncherBuffer, 0, sklauncherBuffer.Length)) > 0)
                                    {
                                        sklauncherFileStream.Write(sklauncherBuffer, 0, sklauncherBytesRead);
                                        sklauncherTotalBytesRead += sklauncherBytesRead;

                                        if (sklauncherTotalBytes > 0)
                                        {
                                            int sklauncherProgress = (int)((sklauncherTotalBytesRead * 100) / sklauncherTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {sklauncherProgress}% ({sklauncherTotalBytesRead / 1024} KB of {sklauncherTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nSKLauncher was downloaded successfully!");
                Process sklauncherInstallerProcess = Process.Start(new ProcessStartInfo(sklauncherSaveLocation) { UseShellExecute = true });

                if (sklauncherInstallerProcess != null && !sklauncherInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    sklauncherInstallerProcess.WaitForExit();

                    if (sklauncherInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(sklauncherSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(sklauncherSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "2":
                Console.Clear();
                string prismaUrl = "https://github.com/PrismLauncher/PrismLauncher/releases/download/8.4/PrismLauncher-Windows-MSVC-Setup-8.4.exe";
                string prismaSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "PrismaSetup.exe");
                Console.WriteLine("Downloading Prisma Launcher...");

                // Download prisma installer
                using (HttpClient prismaClient = new HttpClient())
                {
                    using (HttpResponseMessage prismaResponse = prismaClient.GetAsync(prismaUrl).Result)
                    {
                        using (HttpContent prismaContent = prismaResponse.Content)
                        {
                            using (Stream prismaStream = prismaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream prismaFileStream = new FileStream(prismaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] prismaBuffer = new byte[1024];
                                    int prismaBytesRead;
                                    long prismaTotalBytesRead = 0;
                                    long prismaTotalBytes = prismaResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((prismaBytesRead = prismaStream.Read(prismaBuffer, 0, prismaBuffer.Length)) > 0)
                                    {
                                        prismaFileStream.Write(prismaBuffer, 0, prismaBytesRead);
                                        prismaTotalBytesRead += prismaBytesRead;

                                        if (prismaTotalBytes > 0)
                                        {
                                            int prismaProgress = (int)((prismaTotalBytesRead * 100) / prismaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {prismaProgress}% ({prismaTotalBytesRead / 1024} KB of {prismaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nPrisma Launcher was downloaded successfully!");
                Process prismaInstallerProcess = Process.Start(new ProcessStartInfo(prismaSaveLocation) { UseShellExecute = true });

                if (prismaInstallerProcess != null && !prismaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    prismaInstallerProcess.WaitForExit();

                    if (prismaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(prismaSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(prismaSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "3":
                Console.Clear();
                string heroicUrl = "https://github.com/Heroic-Games-Launcher/HeroicGamesLauncher/releases/download/v2.14.1/Heroic-2.14.1-Setup-x64.exe";
                string heroicSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "HeroicSetup.exe");
                Console.WriteLine("Downloading Heroic Games Launcher...");

                // Download Heroic installer
                using (HttpClient heroicClient = new HttpClient())
                {
                    using (HttpResponseMessage heroicResponse = heroicClient.GetAsync(heroicUrl).Result)
                    {
                        using (HttpContent heroicContent = heroicResponse.Content)
                        {
                            using (Stream heroicStream = heroicContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream heroicFileStream = new FileStream(heroicSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] heroicBuffer = new byte[1024];
                                    int heroicBytesRead;
                                    long heroicTotalBytesRead = 0;
                                    long heroicTotalBytes = heroicResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((heroicBytesRead = heroicStream.Read(heroicBuffer, 0, heroicBuffer.Length)) > 0)
                                    {
                                        heroicFileStream.Write(heroicBuffer, 0, heroicBytesRead);
                                        heroicTotalBytesRead += heroicBytesRead;

                                        if (heroicTotalBytes > 0)
                                        {
                                            int heroicProgress = (int)((heroicTotalBytesRead * 100) / heroicTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {heroicProgress}% ({heroicTotalBytesRead / 1024} KB of {heroicTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nHeroic Games Launcher was downloaded successfully!");
                Process heroicInstallerProcess = Process.Start(new ProcessStartInfo(heroicSaveLocation) { UseShellExecute = true });

                if (heroicInstallerProcess != null && !heroicInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    heroicInstallerProcess.WaitForExit();

                    if (heroicInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(heroicSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(heroicSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "4":
                Console.Clear();
                string playniteUrl = "https://github.com/JosefNemec/Playnite/releases/download/10.33/Playnite1033.exe";
                string playniteSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "PlayniteSetup.exe");
                Console.WriteLine("Downloading Playnite...");

                // Download Playnite installer
                using (HttpClient playniteClient = new HttpClient())
                {
                    using (HttpResponseMessage playniteResponse = playniteClient.GetAsync(playniteUrl).Result)
                    {
                        using (HttpContent playniteContent = playniteResponse.Content)
                        {
                            using (Stream playniteStream = playniteContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream playniteFileStream = new FileStream(playniteSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] playniteBuffer = new byte[1024];
                                    int playniteBytesRead;
                                    long playniteTotalBytesRead = 0;
                                    long playniteTotalBytes = playniteResponse.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
                                    while ((playniteBytesRead = playniteStream.Read(playniteBuffer, 0, playniteBuffer.Length)) > 0)
                                    {
                                        playniteFileStream.Write(playniteBuffer, 0, playniteBytesRead);
                                        playniteTotalBytesRead += playniteBytesRead;

                                        if (playniteTotalBytes > 0)
                                        {
                                            int playniteProgress = (int)((playniteTotalBytesRead * 100) / playniteTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {playniteProgress}% ({playniteTotalBytesRead / 1024} KB of {playniteTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nPlaynite was downloaded successfully!");
                Process playniteInstallerProcess = Process.Start(new ProcessStartInfo(playniteSaveLocation) { UseShellExecute = true });

                if (playniteInstallerProcess != null && !playniteInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    playniteInstallerProcess.WaitForExit();

                    if (playniteInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(playniteSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(playniteSaveLocation); // Delete the setup file

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
