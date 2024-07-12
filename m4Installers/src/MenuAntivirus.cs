using System.Diagnostics;

class MenuAntivirus
{
    public static void ShowMenu()
    {
        Console.WriteLine("Antivirus");
        Console.WriteLine("1 - Avast");
        Console.WriteLine("2 - Kaspersky");
        Console.WriteLine("3 - MalwareBytes");
        Console.WriteLine("4 - Bitdefender");
        Console.WriteLine("5 - Return to Main Menu");

        string option = Console.ReadLine();

        if (option == "1")
        {
            string url =
                "https://bits.avcdn.net/productfamily_ANTIVIRUS/insttype_FREE/platform_WIN/installertype_FULL/build_RELEASE/";
            string saveLocation = "C:\\m4Installers\\AvastSetup.exe";
            Console.WriteLine("Downloading Avast...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nAvast was downloaded succesfully!");
            Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });
        }
        else if (option == "2")
        {
            string url = "https://pdc4.trt.pdc.kaspersky.com/DownloadManagers/cb/cbf6b1d8-4ae7-4b33-927f-fdd727060f03/startup.exe";
            string saveLocation = "C:\\m4Installers\\KasperskySetup.exe";
            Console.WriteLine("Downloading Kaspersky...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nKaspersky was downloaded successfully!");
            Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });
        }
        else if (option == "3")
        {
            string url = "https://www.malwarebytes.com/api/downloads/mb-windows?filename=MBSetup.exe&t=1720763650278";
            string saveLocation = "C:\\m4Installers\\Malwarebytesetup.exe";
            Console.WriteLine("Downloading Malwarebytes...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nMalwarebytes was downloaded succesfully!");
            Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });
        }
        else if (option == "4")
        {
            string url =
                "https://download.bitdefender.com/windows/installer/pt-br/bitdefender_avfree.exe";
            string saveLocation = "C:\\m4Installers\\BitdefenderSetup.exe";
            Console.WriteLine("Downloading Bitdefender...");
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        using (Stream stream = content.ReadAsStreamAsync().Result)
                        {
                            using (FileStream fileStream = new FileStream(saveLocation, FileMode.Create,
                                       FileAccess.Write, FileShare.None))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesRead = 0;
                                long totalBytes = response.Content.Headers.ContentLength ?? -1;

                                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                    totalBytesRead += bytesRead;

                                    if (totalBytes > 0)
                                    {
                                        int progress = (int)((totalBytesRead * 100) / totalBytes);
                                        Console.Write(
                                            $"\rDownloading... {progress}% ({totalBytesRead / 1024} KB de {totalBytes / 1024} KB)");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nBitdefender was downloaded succesfully!");
            Process.Start(new ProcessStartInfo(saveLocation) { UseShellExecute = true });
        }
        else if (option == "5")
        {
            Installers.ReturnToMainMenu();
        }
        else
        {
            Console.WriteLine("Invalid option. Try it again.");
        }
    }
}
