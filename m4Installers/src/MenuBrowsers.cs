using System.Diagnostics;


class MenuBrowsers
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Browsers\n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Brave");
        Console.WriteLine("[2] - Firefox");
        Console.WriteLine("[3] - Vivaldi");
        Console.WriteLine("[4] - Opera GX");
        Console.WriteLine("[5] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                string braveUrl =
                    "https://github.com/brave/brave-browser/releases/download/v1.67.123/BraveBrowserStandaloneSetup.exe";
                string braveSaveLocation = "C:\\m4Installers\\BraveSetup.exe";
                Console.WriteLine("Downloading Brave...");
                using (HttpClient braveClient = new HttpClient())
                {
                    using (HttpResponseMessage braveResponse = braveClient.GetAsync(braveUrl).Result)
                    {
                        using (HttpContent braveContent = braveResponse.Content)
                        {
                            using (Stream braveStream = braveContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream braveFileStream = new FileStream(braveSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] braveBuffer = new byte[1024];
                                    int braveBytesRead;
                                    long braveTotalBytesRead = 0;
                                    long braveTotalBytes = braveResponse.Content.Headers.ContentLength ?? -1;

                                    while ((braveBytesRead = braveStream.Read(braveBuffer, 0, braveBuffer.Length)) > 0)
                                    {
                                        braveFileStream.Write(braveBuffer, 0, braveBytesRead);
                                        braveTotalBytesRead += braveBytesRead;

                                        if (braveTotalBytes > 0)
                                        {
                                            int braveProgress = (int)((braveTotalBytesRead * 100) / braveTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {braveProgress}% ({braveTotalBytesRead / 1024} KB de {braveTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nBrave was downloaded succesfully!");
                Process braveInstallerProcess = Process.Start(new ProcessStartInfo(braveSaveLocation) { UseShellExecute = true });

                if (braveInstallerProcess != null && !braveInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    braveInstallerProcess.WaitForExit();

                    if (braveInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "2":
                string firefoxUrl = "https://download.mozilla.org/?product=firefox-latest&os=win64";
                string firefoxSaveLocation = "C:\\m4Installers\\FirefoxSetup.exe";
                Console.WriteLine("Downloading Firefox...");
                using (HttpClient firefoxClient = new HttpClient())
                {
                    using (HttpResponseMessage firefoxResponse = firefoxClient.GetAsync(firefoxUrl).Result)
                    {
                        using (HttpContent firefoxContent = firefoxResponse.Content)
                        {
                            using (Stream firefoxStream = firefoxContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream firefoxFileStream = new FileStream(firefoxSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] firefoxBuffer = new byte[1024];
                                    int firefoxBytesRead;
                                    long firefoxTotalBytesRead = 0;
                                    long firefoxTotalBytes = firefoxResponse.Content.Headers.ContentLength ?? -1;

                                    while ((firefoxBytesRead = firefoxStream.Read(firefoxBuffer, 0, firefoxBuffer.Length)) > 0)
                                    {
                                        firefoxFileStream.Write(firefoxBuffer, 0, firefoxBytesRead);
                                        firefoxTotalBytesRead += firefoxBytesRead;

                                        if (firefoxTotalBytes > 0)
                                        {
                                            int firefoxProgress = (int)((firefoxTotalBytesRead * 100) / firefoxTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {firefoxProgress}% ({firefoxTotalBytesRead / 1024} KB de {firefoxTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nFirefox was downloaded succesfully!");
                Process firefoxInstallerProcess = Process.Start(new ProcessStartInfo(firefoxSaveLocation) { UseShellExecute = true });

                if (firefoxInstallerProcess != null && !firefoxInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    firefoxInstallerProcess.WaitForExit();

                    if (firefoxInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "3":
                string vivaldiUrl = "https://downloads.vivaldi.com/stable/Vivaldi.6.8.3381.46.x64.exe";
                string vivaldiSaveLocation = "C:\\m4Installers\\VivaldiSetup.exe";
                Console.WriteLine("Downloading Vivaldi...");
                using (HttpClient vivaldiClient = new HttpClient())
                {
                    using (HttpResponseMessage vivaldiResponse = vivaldiClient.GetAsync(vivaldiUrl).Result)
                    {
                        using (HttpContent vivaldiContent = vivaldiResponse.Content)
                        {
                            using (Stream vivaldiStream = vivaldiContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream vivaldiFileStream = new FileStream(vivaldiSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] vivaldiBuffer = new byte[1024];
                                    int vivaldiBytesRead;
                                    long vivaldiTotalBytesRead = 0;
                                    long vivaldiTotalBytes = vivaldiResponse.Content.Headers.ContentLength ?? -1;

                                    while ((vivaldiBytesRead = vivaldiStream.Read(vivaldiBuffer, 0, vivaldiBuffer.Length)) > 0)
                                    {
                                        vivaldiFileStream.Write(vivaldiBuffer, 0, vivaldiBytesRead);
                                        vivaldiTotalBytesRead += vivaldiBytesRead;

                                        if (vivaldiTotalBytes > 0)
                                        {
                                            int vivaldiProgress = (int)((vivaldiTotalBytesRead * 100) / vivaldiTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {vivaldiProgress}% ({vivaldiTotalBytesRead / 1024} KB de {vivaldiTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nVivaldi was downloaded succesfully!");
                Process vivaldiInstallerProcess = Process.Start(new ProcessStartInfo(vivaldiSaveLocation) { UseShellExecute = true });

                if (vivaldiInstallerProcess != null && !vivaldiInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    vivaldiInstallerProcess.WaitForExit();

                    if (vivaldiInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }
                break;

            case "4":
                string operaGXUrl =
                    "https://download3.operacdn.com/pub/opera_gx/100.0.4815.44/win/Opera_GX_100.0.4815.44_Setup_x64.exe";
                string operaGXSaveLocation = "C:\\m4Installers\\OperaGXSetup.exe";
                Console.WriteLine("Downloading OperaGX...");
                using (HttpClient operaGXClient = new HttpClient())
                {
                    using (HttpResponseMessage operaGXResponse = operaGXClient.GetAsync(operaGXUrl).Result)
                    {
                        using (HttpContent operaGXContent = operaGXResponse.Content)
                        {
                            using (Stream operaGXStream = operaGXContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream operaGXFileStream = new FileStream(operaGXSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] operaGXBuffer = new byte[1024];
                                    int operaGXBytesRead;
                                    long operaGXTotalBytesRead = 0;
                                    long operaGXTotalBytes = operaGXResponse.Content.Headers.ContentLength ?? -1;

                                    while ((operaGXBytesRead = operaGXStream.Read(operaGXBuffer, 0, operaGXBuffer.Length)) > 0)
                                    {
                                        operaGXFileStream.Write(operaGXBuffer, 0, operaGXBytesRead);
                                        operaGXTotalBytesRead += operaGXBytesRead;

                                        if (operaGXTotalBytes > 0)
                                        {
                                            int operaGXProgress = (int)((operaGXTotalBytesRead * 100) / operaGXTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {operaGXProgress}% ({operaGXTotalBytesRead / 1024} KB de {operaGXTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOperaGX was downloaded succesfully!");
                Process operaGXInstallerProcess = Process.Start(new ProcessStartInfo(operaGXSaveLocation) { UseShellExecute = true });

                if (operaGXInstallerProcess != null && !operaGXInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    operaGXInstallerProcess.WaitForExit();

                    if (operaGXInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
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
