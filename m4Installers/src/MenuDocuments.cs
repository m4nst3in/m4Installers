using System.Diagnostics;
class MenuDocuments
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Document Apps \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - Microsoft Word ");
        Console.WriteLine("[2] - Google Docs ");
        Console.WriteLine("[3] - Adobe Acrobat Reader ");
        Console.WriteLine("[4] - LibreOffice Writer ");
        Console.WriteLine("[5] - WPS Office "); 
        Console.WriteLine("[6] - Obsidian ");
        Console.WriteLine("[6] - Return to Main Menu ");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string wordUrl =
                    "https://go.microsoft.com/fwlink/?linkid=525133";
                string wordSaveLocation = "C:\\m4Installers\\WordSetup.exe";
                Console.WriteLine("Downloading Microsoft Word...");

                // Download Word installer
                using (HttpClient wordClient = new HttpClient())
                {
                    using (HttpResponseMessage wordResponse = wordClient.GetAsync(wordUrl).Result)
                    {
                        using (HttpContent wordContent = wordResponse.Content)
                            
                        {
                            using (Stream wordStream = wordContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream wordFileStream = new FileStream(wordSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] wordBuffer = new byte[1024];
                                    int wordBytesRead;
                                    long wordTotalBytesRead = 0;
                                    long wordTotalBytes = wordResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Word installer file
                                    while ((wordBytesRead = wordStream.Read(wordBuffer, 0, wordBuffer.Length)) > 0)
                                    {
                                        wordFileStream.Write(wordBuffer, 0, wordBytesRead);
                                        wordTotalBytesRead += wordBytesRead;

                                        if (wordTotalBytes > 0)
                                        {
                                            int wordProgress = (int)((wordTotalBytesRead * 100) / wordTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {wordProgress}% ({wordTotalBytesRead / 1024} KB of {wordTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nMicrosoft Word was downloaded successfully!");
                Process wordInstallerProcess = Process.Start(new ProcessStartInfo(wordSaveLocation) { UseShellExecute = true });

                if (wordInstallerProcess != null && !wordInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    wordInstallerProcess.WaitForExit();

                    if (wordInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(wordSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(wordSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string googleDocsUrl = "https://www.google.com/docs/about/download/";
                string googleDocsSaveLocation = "C:\\m4Installers\\GoogleDocsSetup.exe";
                Console.WriteLine("Downloading Google Docs...");

                // Download Google Docs installer
                using (HttpClient googleDocsClient = new HttpClient())
                {
                    using (HttpResponseMessage googleDocsResponse = googleDocsClient.GetAsync(googleDocsUrl).Result)
                    {
                        using (HttpContent googleDocsContent = googleDocsResponse.Content)
                        {
                            using (Stream googleDocsStream = googleDocsContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream googleDocsFileStream = new FileStream(googleDocsSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] googleDocsBuffer = new byte[1024];
                                    int googleDocsBytesRead;
                                    long googleDocsTotalBytesRead = 0;
                                    long googleDocsTotalBytes = googleDocsResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Google Docs installer file
                                    while ((googleDocsBytesRead = googleDocsStream.Read(googleDocsBuffer, 0, googleDocsBuffer.Length)) > 0)
                                    {
                                        googleDocsFileStream.Write(googleDocsBuffer, 0, googleDocsBytesRead);
                                        googleDocsTotalBytesRead += googleDocsBytesRead;

                                        if (googleDocsTotalBytes > 0)
                                        {
                                            int googleDocsProgress = (int)((googleDocsTotalBytesRead * 100) / googleDocsTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {googleDocsProgress}% ({googleDocsTotalBytesRead / 1024} KB of {googleDocsTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGoogle Docs was downloaded successfully!");
                Process googleDocsInstallerProcess = Process.Start(new ProcessStartInfo(googleDocsSaveLocation) { UseShellExecute = true });

                if (googleDocsInstallerProcess != null && !googleDocsInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    googleDocsInstallerProcess.WaitForExit();

                    if (googleDocsInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(googleDocsSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(googleDocsSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string acrobatUrl = "https://get.adobe.com/reader/";
                string acrobatSaveLocation = "C:\\m4Installers\\AcrobatReaderSetup.exe";
                Console.WriteLine("Downloading Adobe Acrobat Reader...");

                // Download Adobe Acrobat Reader installer
                using (HttpClient acrobatClient = new HttpClient())
                {
                    using (HttpResponseMessage acrobatResponse = acrobatClient.GetAsync(acrobatUrl).Result)
                    {
                        using (HttpContent acrobatContent = acrobatResponse.Content)
                        {
                            using (Stream acrobatStream = acrobatContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream acrobatFileStream = new FileStream(acrobatSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] acrobatBuffer = new byte[1024];
                                    int acrobatBytesRead;
                                    long acrobatTotalBytesRead = 0;
                                    long acrobatTotalBytes = acrobatResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Adobe Acrobat Reader installer file
                                    while ((acrobatBytesRead = acrobatStream.Read(acrobatBuffer, 0, acrobatBuffer.Length)) > 0)
                                    {
                                        acrobatFileStream.Write(acrobatBuffer, 0, acrobatBytesRead);
                                        acrobatTotalBytesRead += acrobatBytesRead;

                                        if (acrobatTotalBytes > 0)
                                        {
                                            int acrobatProgress = (int)((acrobatTotalBytesRead * 100) / acrobatTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {acrobatProgress}% ({acrobatTotalBytesRead / 1024} KB of {acrobatTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nAdobe Acrobat Reader was downloaded successfully!");
                Process acrobatInstallerProcess = Process.Start(new ProcessStartInfo(acrobatSaveLocation) { UseShellExecute = true });

                if (acrobatInstallerProcess != null && !acrobatInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    acrobatInstallerProcess.WaitForExit();

                    if (acrobatInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(acrobatSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(acrobatSaveLocation); // Delete the setup file

                    }
                }
                break;

            case "4":
                Console.Clear();
                string libreOfficeUrl = "https://www.libreoffice.org/download/download/";
                string libreOfficeSaveLocation = "C:\\m4Installers\\LibreOfficeSetup.exe";
                Console.WriteLine("Downloading LibreOffice Writer...");

                // Download LibreOffice Writer installer
                using (HttpClient libreOfficeClient = new HttpClient())
                {
                    using (HttpResponseMessage libreOfficeResponse = libreOfficeClient.GetAsync(libreOfficeUrl).Result)
                    {
                        using (HttpContent libreOfficeContent = libreOfficeResponse.Content)
                        {
                            using (Stream libreOfficeStream = libreOfficeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream libreOfficeFileStream = new FileStream(libreOfficeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] libreOfficeBuffer = new byte[1024];
                                    int libreOfficeBytesRead;
                                    long libreOfficeTotalBytesRead = 0;
                                    long libreOfficeTotalBytes = libreOfficeResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write LibreOffice Writer installer file
                                    while ((libreOfficeBytesRead = libreOfficeStream.Read(libreOfficeBuffer, 0, libreOfficeBuffer.Length)) > 0)
                                    {
                                        libreOfficeFileStream.Write(libreOfficeBuffer, 0, libreOfficeBytesRead);
                                        libreOfficeTotalBytesRead += libreOfficeBytesRead;

                                        if (libreOfficeTotalBytes > 0)
                                        {
                                            int libreOfficeProgress = (int)((libreOfficeTotalBytesRead * 100) / libreOfficeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {libreOfficeProgress}% ({libreOfficeTotalBytesRead / 1024} KB of {libreOfficeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nLibreOffice Writer was downloaded successfully!");
                Process libreOfficeInstallerProcess = Process.Start(new ProcessStartInfo(libreOfficeSaveLocation) { UseShellExecute = true });

                if (libreOfficeInstallerProcess != null && !libreOfficeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    libreOfficeInstallerProcess.WaitForExit();

                    if (libreOfficeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(libreOfficeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(libreOfficeSaveLocation); // Delete the setup file

                    }
                }
                break;
            case "5":
                Console.Clear();
                string wpsOfficeUrl = "https://www.wps.com/office-free";
                string wpsOfficeSaveLocation = "C:\\m4Installers\\WPSOfficeSetup.exe";
                Console.WriteLine("Downloading WPS Office...");

                // Download WPS Office installer
                using (HttpClient wpsOfficeClient = new HttpClient())
                {
                    using (HttpResponseMessage wpsOfficeResponse = wpsOfficeClient.GetAsync(wpsOfficeUrl).Result)
                    {
                        using (HttpContent wpsOfficeContent = wpsOfficeResponse.Content)
                        {
                            using (Stream wpsOfficeStream = wpsOfficeContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream wpsOfficeFileStream = new FileStream(wpsOfficeSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] wpsOfficeBuffer = new byte[1024];
                                    int wpsOfficeBytesRead;
                                    long wpsOfficeTotalBytesRead = 0;
                                    long wpsOfficeTotalBytes = wpsOfficeResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write WPS Office installer file
                                    while ((wpsOfficeBytesRead = wpsOfficeStream.Read(wpsOfficeBuffer, 0, wpsOfficeBuffer.Length)) > 0)
                                    {
                                        wpsOfficeFileStream.Write(wpsOfficeBuffer, 0, wpsOfficeBytesRead);
                                        wpsOfficeTotalBytesRead += wpsOfficeBytesRead;

                                        if (wpsOfficeTotalBytes > 0)
                                        {
                                            int wpsOfficeProgress = (int)((wpsOfficeTotalBytesRead * 100) / wpsOfficeTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {wpsOfficeProgress}% ({wpsOfficeTotalBytesRead / 1024} KB of {wpsOfficeTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nWPS Office was downloaded successfully!");
                Process wpsOfficeInstallerProcess = Process.Start(new ProcessStartInfo(wpsOfficeSaveLocation) { UseShellExecute = true });

                if (wpsOfficeInstallerProcess != null && !wpsOfficeInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    wpsOfficeInstallerProcess.WaitForExit();

                    if (wpsOfficeInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(wpsOfficeSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(wpsOfficeSaveLocation); // Delete the setup file
                    }
                }
                break;
            case "6":
                Console.Clear();
                string obsidianUrl = "https://github.com/obsidianmd/obsidian-releases/releases/download/v1.6.5/Obsidian-1.6.5.exe";
                string obsidianSaveLocation = "C:\\m4Installers\\ObsidianSetup.exe";
                Console.WriteLine("Downloading Obsidian (Vault)...");

                // Download Obsidian installer
                using (HttpClient obsidianClient = new HttpClient())
                {
                    using (HttpResponseMessage obsidianResponse = obsidianClient.GetAsync(obsidianUrl).Result)
                    {
                        using (HttpContent obsidianContent = obsidianResponse.Content)
                        {
                            using (Stream obsidianStream = obsidianContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream obsidianFileStream = new FileStream(obsidianSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] obsidianBuffer = new byte[1024];
                                    int obsidianBytesRead;
                                    long obsidianTotalBytesRead = 0;
                                    long obsidianTotalBytes = obsidianResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Obsidian installer file
                                    while ((obsidianBytesRead = obsidianStream.Read(obsidianBuffer, 0, obsidianBuffer.Length)) > 0)
                                    {
                                        obsidianFileStream.Write(obsidianBuffer, 0, obsidianBytesRead);
                                        obsidianTotalBytesRead += obsidianBytesRead;

                                        if (obsidianTotalBytes > 0)
                                        {
                                            int obsidianProgress = (int)((obsidianTotalBytesRead * 100) / obsidianTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {obsidianProgress}% ({obsidianTotalBytesRead / 1024} KB of {obsidianTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nObsidian (Vault) was downloaded successfully!");
                Process obsidianInstallerProcess = Process.Start(new ProcessStartInfo(obsidianSaveLocation) { UseShellExecute = true });

                if (obsidianInstallerProcess != null && !obsidianInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    obsidianInstallerProcess.WaitForExit();

                    if (obsidianInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(obsidianSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(obsidianSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "7":
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
