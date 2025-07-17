using System.Diagnostics;

namespace SysForge
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MainMenu();
        }
        public static void RunCommand(string command)
        {
            try
            {
                Console.Clear();
                var startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }
                    process.WaitForExit();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:\n" + ex.Message);
                PATC();
                MainMenu();
            }
        }
        public static void RunPowershellCommand(string psCommand)
        {
            try
            {
                Console.Clear();
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"" + psCommand + "\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = startInfo })
                {
                    process.Start();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        string line = process.StandardOutput.ReadLine();
                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(ex.Message);
                PATC();
                MainMenu();
            }
        }
        public static void PATC()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("   ▄████████ ▄██   ▄      ▄████████    ▄████████  ▄██████▄     ▄████████    ▄██████▄     ▄████████ \n  ███    ███ ███   ██▄   ███    ███   ███    ███ ███    ███   ███    ███   ███    ███   ███    ███ \n  ███    █▀  ███▄▄▄███   ███    █▀    ███    █▀  ███    ███   ███    ███   ███    █▀    ███    █▀  \n  ███        ▀▀▀▀▀▀███   ███         ▄███▄▄▄     ███    ███  ▄███▄▄▄▄██▀  ▄███         ▄███▄▄▄     \n▀███████████ ▄██   ███ ▀███████████ ▀▀███▀▀▀     ███    ███ ▀▀███▀▀▀▀▀   ▀▀███ ████▄  ▀▀███▀▀▀     \n         ███ ███   ███          ███   ███        ███    ███ ▀███████████   ███    ███   ███    █▄  \n   ▄█    ███ ███   ███    ▄█    ███   ███        ███    ███   ███    ███   ███    ███   ███    ███ \n ▄████████▀   ▀█████▀   ▄████████▀    ███         ▀██████▀    ███    ███   ████████▀    ██████████ \n                                                              ███    ███                           ");
            Console.WriteLine("1.1.0\n");
            Console.WriteLine("1. Hardware and system info\n2. Network and internet\n3. Users and Groups\n4. Disks and drives\n5. Services and procesess\n0. Exit");

            string ans = Console.ReadLine();
            if (ans == "1")
            {
                SystemInfoMenu();
            }
            else if (ans == "2")
            {
                NetworkMenu();
            }
            else if (ans == "3")
            {
                Users();
            }
            else if (ans == "4")
            {
                Disks();
            }
            else if (ans == "5")
            {
                Procesess();
            }
            else if (ans == "0")
            {
                Environment.Exit(0);
            }
            else { MainMenu(); }
        }
        public static void SystemInfoMenu()
        {
            Console.Clear();
            Console.WriteLine("1. OS info\n2. CPU info\n3. RAM info\n4. Disk info\n5. GPU info\n6. Battery status\n0. Back");

            string ans = Console.ReadLine();
            if (ans == "1")
            {
                RunCommand("systeminfo");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "2")
            {
                RunPowershellCommand("Get-CimInstance Win32_Processor");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "3")
            {
                RunPowershellCommand("Get-CimInstance Win32_PhysicalMemory");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "4")
            {
                RunCommand("wmic logicaldisk get size,freespace,caption");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "5")
            {
                RunPowershellCommand("Get-CimInstance Win32_VideoController");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "6")
            {
                RunCommand("powercfg /batteryreport");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == "0")
            {
                MainMenu();
            }
            else { SystemInfoMenu(); }

        }
        public static void NetworkMenu()
        {
            Console.Clear();
            Console.WriteLine("Network and internet\n\n1.Get IP address\n2. Get MAC address\n3. Ping\n4. Tracert\n5. DNS info\n6. Show Wi-Fi networks\n7. Get public IP\n8. Show full IP configuration\n9. Release IPv4 and IPv6\n10. Renew IPv4 and IPv6\n11. Flush DNS\n12. Refresh DNS\n13. Display DNS\n0. Back");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                RunCommand("ipconfig");
                PATC();
                NetworkMenu();
            }
            else if (ans == "2")
            {
                RunCommand("getmac");
                PATC();
                NetworkMenu();
            }
            else if (ans == "3")
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("ping " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == "4")
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("tracert " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == "5")
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("nslookup " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == "6")
            {
                RunCommand("netsh wlan show networks");
                PATC();
                NetworkMenu();
            }
            else if (ans == "7")
            {
                RunPowershellCommand("(Invoke-WebRequest -Uri 'https://api.ipify.org').Content");
                PATC();
                NetworkMenu();
            }
            else if (ans == "8")
            {
                RunCommand("ipconfig /all");
                PATC();
                NetworkMenu();
            }
            else if (ans == "9")
            {
                RunCommand("ipconfig /release");
                RunCommand("ipconfig /release6");
                PATC();
                NetworkMenu();
            }
            else if (ans == "10")
            {
                RunCommand("ipconfig /renew");
                RunCommand("ipconfig /renew6");
                PATC();
                NetworkMenu();
            }
            else if (ans == "11")
            {
                RunCommand("ipconfig /flushdns");
                PATC();
                NetworkMenu();
            }
            else if (ans == "12")
            {
                RunCommand("ipconfig /registerdns");
                PATC();
                NetworkMenu();
            }
            else if (ans == "13")
            {
                RunCommand("ipconfig /displaydns");
                PATC();
                NetworkMenu();
            }
            else if (ans == "0")
            {
                MainMenu();
            }
            else { NetworkMenu(); }
        }
        public static void Users()
        {
            Console.Clear();
            Console.WriteLine("1. Show all users\n2. Create new user\n3. Change password\n4. Add user to localgroup\n5. Remove user from localgroup\n6. Activate account\n7. Deactivate account\n8. Remove user\n0. Back");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                RunCommand("net user");
                PATC();
                Users();
            }
            else if (ans == "2")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password");
                string password = Console.ReadLine();

                RunCommand("net user " + username + " " + password + " /add");
                Console.Clear();
                Console.WriteLine("Select localgroup for " + username + ":");
                Console.WriteLine("1. Administrator\n2. User\n3. Other\n4. No localgroup");
                int ans1 = int.Parse(Console.ReadLine());
                if (ans1 == 1)
                {
                    RunCommand("net localgroup Administrators " + username + " /add");
                    PATC();
                    Users();
                }
                else if (ans1 == 2)
                {
                    RunCommand("net localgroup Users " + username + " /add");
                    PATC();
                    Users();
                }
                else if (ans1 == 3)
                {
                    Console.WriteLine("Write localgroup to which you want to add the " + username);
                    int localgroup = int.Parse(Console.ReadLine());
                    RunCommand("net localgroup" + localgroup + " " + username + " /add");
                    PATC();
                    Users();
                }
                else if (ans1 == 4)
                {
                    Users();
                }

            }
            else if (ans == "3")
            {
                Console.WriteLine("Username of the account: ");
                string username = Console.ReadLine();
                Console.WriteLine("New password:");
                string password = Console.ReadLine();

                RunCommand("net user " + username + " " + password);
                PATC();
                Users();
            }
            else if (ans == "4")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Localgroup:");
                string localgorup = Console.ReadLine();
                RunCommand("net localgorup " + localgorup + " " + username + " /add");
                PATC();
                Users();
            }
            else if (ans == "5")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Localgroup");
                string localgorup = Console.ReadLine();
                RunCommand("net localgroup" + localgorup + " " + username + " /remove");
                PATC();
                Users();
            }
            else if (ans == "6")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user " + username + " /active:yes");
                PATC();
                Users();
            }
            else if (ans == "7")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user" + username + " /active:no");
                PATC();
                Users();
            }
            else if (ans == "8")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user " + username + "/delete");
                PATC();
                Users();
            }
            else if (ans == "0")
            {
                MainMenu();
            }
            else { Users(); }
        }
        public static void Disks()
        {
            Console.Clear();
            Console.WriteLine("1. Show all disks\n2. Check disk\n3. Defrag disk\n0. Back");
            string ans = Console.ReadLine();
            if (ans == "1")
            {
                RunCommand("wmic logicaldisk get name,size,freespace,description");
                PATC();
                Disks();
            }
            else if (ans == "2")
            {
                Console.WriteLine("Write partition you want to check (example C: or D:)");
                string partition = Console.ReadLine();
                RunCommand("chkdsk " + partition);
                PATC();
                Disks();
            }
            else if (ans == "3")
            {
                Console.WriteLine("Write partition you want to defrag (exapmle C: or D:)");
                string partition = Console.ReadLine();
                RunCommand("chkdsk " + partition);
                PATC();
                Disks();
            }
            else if (ans == "0")
            {
                MainMenu();
            }
            else { Disks(); }
        }
        public static void Procesess()
        {
            Console.Clear();
            Console.WriteLine("1. Show all processess\n2. End process\n3. Show all services\n4. Start service\n5. Stop service\n6. Restart service\n0. Back");

            string ans = Console.ReadLine();
            if (ans == "1")
            {
                RunCommand("tasklist");
                PATC();
                Procesess();
            }
            else if (ans == "2")
            {
                Console.WriteLine("Write name of the process you want to end (with .exe):");
                string process = Console.ReadLine();
                RunCommand("taskkill -f -im " + process);
                PATC();
                Procesess();
            }
            else if (ans == "3")
            {
                RunPowershellCommand("Get-Service");
                PATC();
                Procesess();
            }
            else if (ans == "4")
            {
                Console.WriteLine("Write name of the service:");
                string service = Console.ReadLine();
                RunPowershellCommand("Start-Service -Name " + service);
                PATC();
                Procesess();
            }
            else if (ans == "5")
            {
                Console.WriteLine("Write name of the service:");
                string service = Console.ReadLine();
                RunPowershellCommand("Stop-Service -Name " + service);
                PATC();
                Procesess();
            }
            else if (ans == "6")
            {
                Console.WriteLine("Write name of the service");
                string service = Console.ReadLine();
                RunPowershellCommand("Restart-Service -Name " + service);
                PATC();
                Procesess();
            }
            else if (ans == "0")
            {
                MainMenu();
            }
            else
            {
                Procesess();
            }
        }
    }
}