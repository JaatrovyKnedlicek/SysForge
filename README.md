    ███████╗██╗   ██╗███████╗███████╗ ██████╗ ██████╗  ██████╗ ███████╗
    ██╔════╝╚██╗ ██╔╝██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝ ██╔════╝
    ███████╗ ╚████╔╝ ███████╗█████╗  ██║   ██║██████╔╝██║  ███╗█████╗  
    ╚════██║  ╚██╔╝  ╚════██║██╔══╝  ██║   ██║██╔══██╗██║   ██║██╔══╝  
    ███████║   ██║   ███████║██║     ╚██████╔╝██║  ██║╚██████╔╝███████╗
    ╚══════╝   ╚═╝   ╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                       
SysForge is a powerful Windows console tool designed to simplify system administration tasks via a command-driven menu interface. It combines multiple system utilities and commands in one place for quick access and easy management of Windows system info, networking, users, disks, and more.

## Features
-   **Intuitive menu-driven interface** for running system commands
-   System information display: OS version, system details, CPU architecture
-   Network tools: IP and MAC address lookup, ping, tracert, DNS, Wi-Fi networks
-   User and group management: create users, change passwords, manage groups, activate/deactivate accounts
-   Disk management: list disks, check disks, defragment
-   Supports both traditional CMD commands and PowerShell commands
-   Clean console output with error handling and pause prompts

## Getting started
### Running from precompiled (.exe) from Releases:

 1. Download the latest `.zip` archive from Releases section.
 2. Extract is and save it anywhere in your computer.
 3. Double-click the `SysForge.exe` file or run it via Command Prompt:
~~~
./SysForge.exe
~~~

4. The console application will run and show the main menu

### Running from source (after cloning the repository):
1. Clone the repositroy
~~~
git clone https://github.com/JaatrovyKnedlicek/SysForge.git
cd SysForge
~~~
2. Make sure you have .NET 9 installed
3. Build the project
~~~
dotnet build
~~~
4. Run the project
~~~
dotnet run
~~~
5. The console app will start and show the main menu

## Commands implemented
### System info

 - `ver`
 - `systeminfo`
 - `echo %processor_architecture%`

### Network and internet

 - `ipconfig`
 - `getmac`
 - `ping`, `tracert`, `nslookup`, `netsh`
 - https://api.ipify.org

### Users and groups

 - `net user`
 - `net localgroup`

### Disk and drives

 - `wmic`
 - `chkdsk`
 - `defrag`

## Development

 - Written in C# using .NET 9
 - Uses `System.Diagnostics.Process` to execute Windows built-in commands and PowerShell commands
 - Menus handled via `Console.WriteLine`
 - Public IP uses https://api.ipify.org

## Roadmap

 - New features
 - Make it more intuitive
 - Add more advanced tools

## Contributions
Contributions are very welcome! Please fork the repository, make your changes, and submit a pull request.
When reporting issues, please provide detailed steps to reproduce.

## License
This project is licensed under the MIT License — see the LICENSE file for details.

## Contact
Created by Ján Repka Github: JaatrovyKnedlicek.
E-mail: jankorepka888@gmail.com
Discord: @jankogranko123
Feel free to reach out for questions or suggestions.