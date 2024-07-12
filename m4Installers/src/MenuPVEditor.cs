using System.Diagnostics;
class MenuPVEditor
{
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Photo/Video Editors \n");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("[1] - GIMP");
        Console.WriteLine("[2] - Paint.NET");
        Console.WriteLine("[3] - OpenShot");
        Console.WriteLine("[4] - Krita");
        Console.WriteLine("[5] - Return to Main Menu");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();
                string gimpUrl = "https://download.gimp.org/gimp/v2.10/windows/gimp-2.10.38-setup.exe";
                string gimpSaveLocation = "C:\\m4Installers\\GIMPSetup.exe";
                Console.WriteLine("Downloading GIMP...");

                // Download GIMP installer
                using (HttpClient gimpClient = new HttpClient())
                {
                    using (HttpResponseMessage gimpResponse = gimpClient.GetAsync(gimpUrl).Result)
                    {
                        using (HttpContent gimpContent = gimpResponse.Content)
                        {
                            using (Stream gimpStream = gimpContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream gimpFileStream = new FileStream(gimpSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] gimpBuffer = new byte[1024];
                                    int gimpBytesRead;
                                    long gimpTotalBytesRead = 0;
                                    long gimpTotalBytes = gimpResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write GIMP installer file
                                    while ((gimpBytesRead = gimpStream.Read(gimpBuffer, 0, gimpBuffer.Length)) > 0)
                                    {
                                        gimpFileStream.Write(gimpBuffer, 0, gimpBytesRead);
                                        gimpTotalBytesRead += gimpBytesRead;

                                        if (gimpTotalBytes > 0)
                                        {
                                            int gimpProgress = (int)((gimpTotalBytesRead * 100) / gimpTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {gimpProgress}% ({gimpTotalBytesRead / 1024} KB of {gimpTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nGIMP was downloaded successfully!");
                Process gimpInstallerProcess = Process.Start(new ProcessStartInfo(gimpSaveLocation) { UseShellExecute = true });

                if (gimpInstallerProcess != null && !gimpInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    gimpInstallerProcess.WaitForExit();

                    if (gimpInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(gimpSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(gimpSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "2":
                Console.Clear();
                string paintDotNetUrl = "https://github.com/paintdotnet/release/releases/download/v5.0.13/paint.net.5.0.13.install.anycpu.web.zip";
                string paintDotNetSaveLocation = "C:\\m4Installers\\PaintDotNetSetup.zip";
                Console.WriteLine("Downloading Paint.NET...");

                // Download Paint.NET installer
                using (HttpClient paintDotNetClient = new HttpClient())
                {
                    using (HttpResponseMessage paintDotNetResponse = paintDotNetClient.GetAsync(paintDotNetUrl).Result)
                    {
                        using (HttpContent paintDotNetContent = paintDotNetResponse.Content)
                        {
                            using (Stream paintDotNetStream = paintDotNetContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream paintDotNetFileStream = new FileStream(paintDotNetSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] paintDotNetBuffer = new byte[1024];
                                    int paintDotNetBytesRead;
                                    long paintDotNetTotalBytesRead = 0;
                                    long paintDotNetTotalBytes = paintDotNetResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Paint.NET installer file
                                    while ((paintDotNetBytesRead = paintDotNetStream.Read(paintDotNetBuffer, 0, paintDotNetBuffer.Length)) > 0)
                                    {
                                        paintDotNetFileStream.Write(paintDotNetBuffer, 0, paintDotNetBytesRead);
                                        paintDotNetTotalBytesRead += paintDotNetBytesRead;

                                        if (paintDotNetTotalBytes > 0)
                                        {
                                            int paintDotNetProgress = (int)((paintDotNetTotalBytesRead * 100) / paintDotNetTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {paintDotNetProgress}% ({paintDotNetTotalBytesRead / 1024} KB of {paintDotNetTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nPaint.NET was downloaded successfully!");
                Process paintDotNetInstallerProcess = Process.Start(new ProcessStartInfo(paintDotNetSaveLocation) { UseShellExecute = true });

                if (paintDotNetInstallerProcess != null && !paintDotNetInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    paintDotNetInstallerProcess.WaitForExit();

                    if (paintDotNetInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(paintDotNetSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(paintDotNetSaveLocation); // Delete the setup file
                    }
                }
                break;

            case "3":
                Console.Clear();
                string openshotUrl = "https://github.com/OpenShot/openshot-qt/releases/download/v3.2.1/OpenShot-v3.2.1-x86_64.exe";
                string openshotSaveLocation = "C:\\m4Installers\\OpenShotSetup.exe";
                Console.WriteLine("Downloading OpenShot...");

                // Download OpenShot installer
                using (HttpClient openshotClient = new HttpClient())
                {
                    using (HttpResponseMessage openshotResponse = openshotClient.GetAsync(openshotUrl).Result)
                    {
                        using (HttpContent openshotContent = openshotResponse.Content)
                        {
                            using (Stream openshotStream = openshotContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream openshotFileStream = new FileStream(openshotSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] openshotBuffer = new byte[1024];
                                    int openshotBytesRead;
                                    long openshotTotalBytesRead = 0;
                                    long openshotTotalBytes = openshotResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write OpenShot installer file
                                    while ((openshotBytesRead = openshotStream.Read(openshotBuffer, 0, openshotBuffer.Length)) > 0)
                                    {
                                        openshotFileStream.Write(openshotBuffer, 0, openshotBytesRead);
                                        openshotTotalBytesRead += openshotBytesRead;

                                        if (openshotTotalBytes > 0)
                                        {
                                            int openshotProgress = (int)((openshotTotalBytesRead * 100) / openshotTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {openshotProgress}% ({openshotTotalBytesRead / 1024} KB of {openshotTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nOpenShot was downloaded successfully!");
                Process openshotInstallerProcess = Process.Start(new ProcessStartInfo(openshotSaveLocation) { UseShellExecute = true });

                if (openshotInstallerProcess != null && !openshotInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    openshotInstallerProcess.WaitForExit();

                    if (openshotInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(openshotSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(openshotSaveLocation); // Delete the setup file
                    }
                }
                break;


            case "4":
                Console.Clear();
                string kritaUrl = "https://download.kde.org/stable/krita/4.4.5/krita-x64-4.4.5-setup.exe";
                string kritaSaveLocation = "C:\\m4Installers\\KritaSetup.exe";
                Console.WriteLine("Downloading Krita...");

                // Download Krita installer
                using (HttpClient kritaClient = new HttpClient())
                {
                    using (HttpResponseMessage kritaResponse = kritaClient.GetAsync(kritaUrl).Result)
                    {
                        using (HttpContent kritaContent = kritaResponse.Content)
                        {
                            using (Stream kritaStream = kritaContent.ReadAsStreamAsync().Result)
                            {
                                using (FileStream kritaFileStream = new FileStream(kritaSaveLocation, FileMode.Create,
                                           FileAccess.Write, FileShare.None))
                                {
                                    byte[] kritaBuffer = new byte[1024];
                                    int kritaBytesRead;
                                    long kritaTotalBytesRead = 0;
                                    long kritaTotalBytes = kritaResponse.Content.Headers.ContentLength ?? -1;

                                    // Read and write Krita installer file
                                    while ((kritaBytesRead = kritaStream.Read(kritaBuffer, 0, kritaBuffer.Length)) > 0)
                                    {
                                        kritaFileStream.Write(kritaBuffer, 0, kritaBytesRead);
                                        kritaTotalBytesRead += kritaBytesRead;

                                        if (kritaTotalBytes > 0)
                                        {
                                            int kritaProgress = (int)((kritaTotalBytesRead * 100) / kritaTotalBytes);
                                            Console.Write(
                                                $"\rDownloading... {kritaProgress}% ({kritaTotalBytesRead / 1024} KB of {kritaTotalBytes / 1024} KB)");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nKrita was downloaded successfully!");
                Process kritaInstallerProcess = Process.Start(new ProcessStartInfo(kritaSaveLocation) { UseShellExecute = true });

                if (kritaInstallerProcess != null && !kritaInstallerProcess.HasExited)
                {
                    Console.WriteLine("Installing...");

                    // Wait until installation process has finished
                    kritaInstallerProcess.WaitForExit();

                    if (kritaInstallerProcess.ExitCode == 0)
                    {
                        Console.WriteLine("Installation was concluded with success!");
                        Console.Clear();
                        File.Delete(kritaSaveLocation); // Delete the setup file
                    }
                    else
                    {
                        Console.WriteLine("Installation has failed!");
                        Console.Clear();
                        File.Delete(kritaSaveLocation); // Delete the setup file
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
