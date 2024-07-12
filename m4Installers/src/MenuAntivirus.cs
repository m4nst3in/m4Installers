using System.Diagnostics;

class MenuAntivirus
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"
    _          _   _       _                
   / \   _ __ | |_(_)_   _(_)_ __ _   _ ___ 
  / _ \ | '_ \| __| \ \ / / | '__| | | / __|
 / ___ \| | | | |_| |\ V /| | |  | |_| \__ \
/_/   \_\_| |_|\__|_| \_/ |_|_|   \__,_|___/

");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Avast");
        Console.WriteLine("[2] - Kaspersky");
        Console.WriteLine("[3] - MalwareBytes");
        Console.WriteLine("[4] - Bitdefender");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string avastUrl = "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN/installertype_FULL/build_RELEASE/";
                string avastSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "AvastSetup.exe");
                Console.WriteLine("Downloading Avast...");

                // Download Avast installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(avastUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(avastSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
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

                Console.WriteLine("\nAvast was downloaded successfully!");
                Process avastInstallerProcess = Process.Start(new ProcessStartInfo(avastSaveLocation) { UseShellExecute = true });

                if (avastInstallerProcess != null && !avastInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    avastInstallerProcess.WaitForExit();

                    if (avastInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(avastSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(avastSaveLocation);
                    }
                }
                break;

            case "2":
                Console.Clear();
                string kasperskyUrl = "https://www.dropbox.com/scl/fi/mz69m452jlwbsjxedub7h/KasperskySetup.exe?rlkey=rw3nbq698ua3s9is53mt9zs1m&st=lvho0p8p&dl=1";
                string kasperskySaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "KasperskySetup.exe");
                Console.WriteLine("Downloading Kaspersky...");

                // Download Kaspersky installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(kasperskyUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(kasperskySaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
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

                Console.WriteLine("\nKaspersky was downloaded successfully!");
                Process kasperskyInstallerProcess = Process.Start(new ProcessStartInfo(kasperskySaveLocation) { UseShellExecute = true });

                if (kasperskyInstallerProcess != null && !kasperskyInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    kasperskyInstallerProcess.WaitForExit();

                    if (kasperskyInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(kasperskySaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(kasperskySaveLocation);
                    }
                }

                break;

            case "3":
                Console.Clear();
                string malwarebytesUrl = "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe&t=1720763650278";
                string malwarebytesSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "Malwarebytesetup.exe");
                Console.WriteLine("Downloading Malwarebytes...");

                // Download Malwarebytes installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(malwarebytesUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(malwarebytesSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
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

                Console.WriteLine("\nMalwarebytes was downloaded successfully!");
                Process malwarebytesInstallerProcess = Process.Start(new ProcessStartInfo(malwarebytesSaveLocation) { UseShellExecute = true });

                if (malwarebytesInstallerProcess != null && !malwarebytesInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    malwarebytesInstallerProcess.WaitForExit();

                    if (malwarebytesInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(malwarebytesSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(malwarebytesSaveLocation);
                    }
                }
                break;

            case "4":
                Console.Clear();
                string bitdefenderUrl = "https://download.bitdefender.com/windows/installer/pt-br/bitdefender_avfree.exe";
                string bitdefenderSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "BitdefenderSetup.exe");
                Console.WriteLine("Downloading Bitdefender...");

                // Download Bitdefender installer
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(bitdefenderUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            using (Stream stream = content.ReadAsStreamAsync().Result)
                            {
                                using (FileStream fileStream = new FileStream(bitdefenderSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] buffer = new byte[1024];
                                    int bytesRead;
                                    long totalBytesRead = 0;
                                    long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                    // Write downloaded data to file
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

                Console.WriteLine("\nBitdefender was downloaded successfully!");
                Process bitdefenderInstallerProcess = Process.Start(new ProcessStartInfo(bitdefenderSaveLocation) { UseShellExecute = true });

                if (bitdefenderInstallerProcess != null && !bitdefenderInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    bitdefenderInstallerProcess.WaitForExit();

                    if (bitdefenderInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(bitdefenderSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(bitdefenderSaveLocation);
                    }
                }
                break;

            case "5":
                Installers.ReturnToMainMenu();
                break;

            default:
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(2500); // Add a delay of 2.5 seconds
                Console.Clear();
                ShowMenu();
                break;
        }
    }
}
