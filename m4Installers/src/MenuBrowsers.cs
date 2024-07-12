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
        Console.WriteLine("[4] - Opera");
        Console.WriteLine("[5] - Opera GX");
        Console.WriteLine("[6] - Google Chrome");
        Console.WriteLine("[7] - Microsoft Edge");
        Console.WriteLine("[8] - Thorium");
        Console.WriteLine("[9] - Librewolf");
        Console.WriteLine("[10] - Return to Main Menu");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string braveUrl =
                    "https://github.com/brave/brave-browser/releases/download/v1.67.123/BraveBrowserStandaloneSetup.exe";
                string braveSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "BraveSetup.exe"); ;
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
                        File.Delete(braveSaveLocation);
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
                string firefoxUrl = "https://download.mozilla.org/?product=firefox-latest&os=win64";
                string firefoxSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "FirefoxSetup.exe"); ;
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
                        File.Delete(firefoxSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(firefoxSaveLocation);
                break;

            case "3":
                Console.Clear();
                string vivaldiUrl = "https://downloads.vivaldi.com/stable/Vivaldi.6.8.3381.46.x64.exe";
                string vivaldiSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "VivaldiSetup.exe"); ;
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
                        File.Delete(vivaldiSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(vivaldiSaveLocation);
                break;
            case "4":
                Console.Clear();
                string operaUrl =
                    "https://net.geo.opera.com/opera/stable/windows?utm_tryagain=yes&utm_source=google&utm_medium=ose&utm_campaign=(none)&http_referrer=https%3A%2F%2Fwww.google.com%2F&utm_site=opera_com&&utm_lastpage=opera.com/download";
                string operaSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "OperaSetup.exe"); ;
                Console.WriteLine("Downloading Opera...");
                using (HttpClient operaClient = new HttpClient())
                {
                    using (HttpResponseMessage operaResponse = operaClient.GetAsync(operaUrl).Result)
                    {
                        using (HttpContent operaContent = operaResponse.Content)
                        {
                            using (Stream operaStream = operaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream operaFileStream = new FileStream(operaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] operaBuffer = new byte[1024];
                                    int operaBytesRead;
                                    long operaTotalBytesRead = 0;
                                    long operaTotalBytes = operaResponse.Content.Headers.ContentLength ?? -1;

                                    while ((operaBytesRead = operaStream.Read(operaBuffer, 0, operaBuffer.Length)) > 0)
                                    {
                                        operaFileStream.Write(operaBuffer, 0, operaBytesRead);
                                        operaTotalBytesRead += operaBytesRead;

                                        if (operaTotalBytes > 0)
                                        {
                                            int operaProgress = (int)((operaTotalBytesRead * 100) / operaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {operaProgress}% ({operaTotalBytesRead / 1024} KB de {operaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOpera was downloaded succesfully!");
                Process operaInstallerProcess = Process.Start(new ProcessStartInfo(operaSaveLocation) { UseShellExecute = true });

                if (operaInstallerProcess != null && !operaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    operaInstallerProcess.WaitForExit();

                    if (operaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(operaSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(operaSaveLocation);
                break;

            case "5":
                Console.Clear();
                string operaGXUrl =
                    "https://download3.operacdn.com/pub/opera_gx/100.0.4815.44/win/Opera_GX_100.0.4815.44_Setup_x64.exe";
                string operaGXSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "OperaGXSetup.exe"); ;
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
                        File.Delete(operaGXSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(operaGXSaveLocation);
                break;
            case "6":
                Console.Clear();
                string chromeUrl =
                    "https://www.dropbox.com/scl/fi/ec46c0o79webh2f3a7i81/ChromeSetup.exe?rlkey=jpj57k653hlqf8zghot6oyej4&st=tuomgeh9&dl=1";
                string chromeSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "ChromeSetup.exe"); ;
                Console.WriteLine("Downloading Google Chrome...");
                using (HttpClient chromeClient = new HttpClient())
                {
                    using (HttpResponseMessage chromeResponse = chromeClient.GetAsync(chromeUrl).Result)
                    {
                        using (HttpContent chromeContent = chromeResponse.Content)
                        {
                            using (Stream chromeStream = chromeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream chromeFileStream = new FileStream(chromeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] chromeBuffer = new byte[1024];
                                    int chromeBytesRead;
                                    long chromeTotalBytesRead = 0;
                                    long chromeTotalBytes = chromeResponse.Content.Headers.ContentLength ?? -1;

                                    while ((chromeBytesRead = chromeStream.Read(chromeBuffer, 0, chromeBuffer.Length)) > 0)
                                    {
                                        chromeFileStream.Write(chromeBuffer, 0, chromeBytesRead);
                                        chromeTotalBytesRead += chromeBytesRead;

                                        if (chromeTotalBytes > 0)
                                        {
                                            int chromeProgress = (int)((chromeTotalBytesRead * 100) / chromeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {chromeProgress}% ({chromeTotalBytesRead / 1024} KB de {chromeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGoogle Chrome was downloaded succesfully!");
                Process chromeInstallerProcess = Process.Start(new ProcessStartInfo(chromeSaveLocation) { UseShellExecute = true });

                if (chromeInstallerProcess != null && !chromeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    chromeInstallerProcess.WaitForExit();

                    if (chromeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(chromeSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(chromeSaveLocation);
                break;
            case "7":
                Console.Clear();
                string edgeUrl =
                    "https://c2rsetup.officeapps.live.com/c2r/downloadEdge.aspx?platform=Default&source=EdgeStablePage&Channel=Stable&language=en";
                string edgeSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "EdgeSetup.exe");
                Console.WriteLine("Downloading Microsoft Edge...");
                using (HttpClient edgeClient = new HttpClient())
                {
                    using (HttpResponseMessage edgeResponse = edgeClient.GetAsync(edgeUrl).Result)
                    {
                        using (HttpContent edgeContent = edgeResponse.Content)
                        {
                            using (Stream edgeStream = edgeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream edgeFileStream = new FileStream(edgeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] edgeBuffer = new byte[1024];
                                    int edgeBytesRead;
                                    long edgeTotalBytesRead = 0;
                                    long edgeTotalBytes = edgeResponse.Content.Headers.ContentLength ?? -1;

                                    while ((edgeBytesRead = edgeStream.Read(edgeBuffer, 0, edgeBuffer.Length)) > 0)
                                    {
                                        edgeFileStream.Write(edgeBuffer, 0, edgeBytesRead);
                                        edgeTotalBytesRead += edgeBytesRead;

                                        if (edgeTotalBytes > 0)
                                        {
                                            int edgeProgress = (int)((edgeTotalBytesRead * 100) / edgeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {edgeProgress}% ({edgeTotalBytesRead / 1024} KB de {edgeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nMicrosoft Edge was downloaded succesfully!");
                Process edgeInstallerProcess = Process.Start(new ProcessStartInfo(edgeSaveLocation) { UseShellExecute = true });

                if (edgeInstallerProcess != null && !edgeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    edgeInstallerProcess.WaitForExit();

                    if (edgeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(edgeSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(edgeSaveLocation);
                break;
            case "8":
                Console.Clear();
                string thoriumUrl =
                    "https://github.com/Alex313031/Thorium-Win/releases/download/M124.0.6367.218/thorium_AVX_mini_installer.exe";
                string thoriumSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "ThoriumSetup.exe"); ;
                Console.WriteLine("Downloading Thorium...");
                using (HttpClient thoriumClient = new HttpClient())
                {
                    using (HttpResponseMessage thoriumResponse = thoriumClient.GetAsync(thoriumUrl).Result)
                    {
                        using (HttpContent thoriumContent = thoriumResponse.Content)
                        {
                            using (Stream thoriumStream = thoriumContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream thoriumFileStream = new FileStream(thoriumSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] thoriumBuffer = new byte[1024];
                                    int thoriumBytesRead;
                                    long thoriumTotalBytesRead = 0;
                                    long thoriumTotalBytes = thoriumResponse.Content.Headers.ContentLength ?? -1;

                                    while ((thoriumBytesRead = thoriumStream.Read(thoriumBuffer, 0, thoriumBuffer.Length)) > 0)
                                    {
                                        thoriumFileStream.Write(thoriumBuffer, 0, thoriumBytesRead);
                                        thoriumTotalBytesRead += thoriumBytesRead;

                                        if (thoriumTotalBytes > 0)
                                        {
                                            int thoriumProgress = (int)((thoriumTotalBytesRead * 100) / thoriumTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {thoriumProgress}% ({thoriumTotalBytesRead / 1024} KB de {thoriumTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nThorium was downloaded succesfully!");
                Process thoriumInstallerProcess = Process.Start(new ProcessStartInfo(thoriumSaveLocation) { UseShellExecute = true });

                if (thoriumInstallerProcess != null && !thoriumInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    thoriumInstallerProcess.WaitForExit();

                    if (thoriumInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(thoriumSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(thoriumSaveLocation);
                break;
            case "9":
                Console.Clear();
                string librewolfUrl =
                    "https://c2rsetup.officeapps.live.com/c2r/downloadlibrewolf.aspx?platform=Default&source=librewolfStablePage&Channel=Stable&language=en";
                string librewolfSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "m4Installers", "LibrewolfSetup.exe"); ;
                Console.WriteLine("Downloading Librewolf...");
                using (HttpClient librewolfClient = new HttpClient())
                {
                    using (HttpResponseMessage librewolfResponse = librewolfClient.GetAsync(librewolfUrl).Result)
                    {
                        using (HttpContent librewolfContent = librewolfResponse.Content)
                        {
                            using (Stream librewolfStream = librewolfContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream librewolfFileStream = new FileStream(librewolfSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] librewolfBuffer = new byte[1024];
                                    int librewolfBytesRead;
                                    long librewolfTotalBytesRead = 0;
                                    long librewolfTotalBytes = librewolfResponse.Content.Headers.ContentLength ?? -1;

                                    while ((librewolfBytesRead = librewolfStream.Read(librewolfBuffer, 0, librewolfBuffer.Length)) > 0)
                                    {
                                        librewolfFileStream.Write(librewolfBuffer, 0, librewolfBytesRead);
                                        librewolfTotalBytesRead += librewolfBytesRead;

                                        if (librewolfTotalBytes > 0)
                                        {
                                            int librewolfProgress = (int)((librewolfTotalBytesRead * 100) / librewolfTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {librewolfProgress}% ({librewolfTotalBytesRead / 1024} KB de {librewolfTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nLibrewolf was downloaded succesfully!");
                Process librewolfInstallerProcess = Process.Start(new ProcessStartInfo(librewolfSaveLocation) { UseShellExecute = true });

                if (librewolfInstallerProcess != null && !librewolfInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    librewolfInstallerProcess.WaitForExit();

                    if (librewolfInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(librewolfSaveLocation);
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                    }
                }

                // Delete the setup file
                File.Delete(librewolfSaveLocation);
                break;

            case "10":
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
