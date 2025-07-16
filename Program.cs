using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
                Console.WriteLine("Working...");
                var proc = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(proc);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.Clear();
                Console.WriteLine(output);
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
                Console.WriteLine("Working...");
                var proc = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"" + psCommand + "\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(proc);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(output);
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
            Console.WriteLine("1.0-alpha WORK IN PROGRESS!\n");
            Console.WriteLine("1. System info\n2. Network and internet\n3. Users and Groups");

            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                SystemInfoMenu();
            }
            else if (ans == 2)
            {
                NetworkMenu();
            }
            else if (ans == 3)
            {
                Users();
            }
        }
        public static void SystemInfoMenu()
        {
            Console.Clear();
            Console.WriteLine("System info\n\n1. OS version\n2. System informations\n3. CPU architecture\n0. Back\n");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                RunCommand("ver");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == 2)
            {
                RunCommand("systeminfo");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == 3)
            {
                RunCommand("echo %PROCESSOR_ARCHITECTURE%");
                PATC();
                SystemInfoMenu();
            }
            else if (ans == 0)
            {
                MainMenu();
            }
        }
        public static void NetworkMenu()
        {
            Console.Clear();
            Console.WriteLine("Network and internet\n\n1.Get IP address\n2. Get MAC address\n3. Ping\n4. Tracert\n5. DNS info\n6. Show Wi-Fi networks\n7. Get public IP\n0. Back");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                RunCommand("ipconfig");
                PATC();
                NetworkMenu();
            }
            else if (ans == 2)
            {
                RunCommand("getmac");
                PATC();
                NetworkMenu();
            }
            else if (ans == 3)
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("ping " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == 4)
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("tracert " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == 5)
            {
                Console.WriteLine("IP: ");
                string IP = Console.ReadLine();
                RunCommand("nslookup " + IP);
                PATC();
                NetworkMenu();
            }
            else if (ans == 6)
            {
                RunCommand("netsh wlan show networks");
                PATC();
                NetworkMenu();
            }
            else if (ans == 7)
            {
                RunPowershellCommand("(Invoke-WebRequest -Uri 'https://api.ipify.org').Content");
                PATC();
                NetworkMenu();
            }
            else if (ans == 0)
            {
                MainMenu();
            }
        }
        public static void Users()
        {
            Console.Clear();
            Console.WriteLine("1. Show all users\n2. Create new user\n3. Change password\n4. Add user to localgroup\n5. Remove user from localgroup\n6. Activate account\n7. Deactivate account\n8. Remove user\n0. Back");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                RunCommand("net user");
                PATC();
                Users();
            }
            else if (ans == 2)
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
            else if (ans == 3)
            {
                Console.WriteLine("Username of the account: ");
                string username = Console.ReadLine();
                Console.WriteLine("New password:");
                string password = Console.ReadLine();

                RunCommand("net user " + username + " " + password);
                PATC();
                Users();
            }
            else if (ans == 4)
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Localgroup:");
                string localgorup = Console.ReadLine();
                RunCommand("net localgorup " + localgorup + " " + username + " /add");
                PATC();
                Users();
            }
            else if (ans == 5)
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Localgroup");
                string localgorup = Console.ReadLine();
                RunCommand("net localgroup" + localgorup + " " + username + " /remove");
                PATC();
                Users();
            }
            else if (ans == 6)
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user " + username + " /active:yes");
                PATC();
                Users();
            }
            else if (ans == 7)
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user" + username + " /active:no");
                PATC();
                Users();
            }
            else if (ans == 8)
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                RunCommand("net user " + username + "/delete");
                PATC();
                Users();
            }
            else if (ans == 0)
            {
                MainMenu();
            }
        }
    }
}