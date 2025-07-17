

    ███████╗██╗   ██╗███████╗███████╗ ██████╗ ██████╗  ██████╗ ███████╗
    ██╔════╝╚██╗ ██╔╝██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝ ██╔════╝
    ███████╗ ╚████╔╝ ███████╗█████╗  ██║   ██║██████╔╝██║  ███╗█████╗  
    ╚════██║  ╚██╔╝  ╚════██║██╔══╝  ██║   ██║██╔══██╗██║   ██║██╔══╝  
    ███████║   ██║   ███████║██║     ╚██████╔╝██║  ██║╚██████╔╝███████╗
    ╚══════╝   ╚═╝   ╚══════╝╚═╝      ╚═════╝ ╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                   

  

SysForge is a powerful Windows console tool designed to simplify system administration tasks via a command-driven menu interface. It combines multiple system utilities and commands in one place for quick access and easy management of Windows system info, networking, users, disks, and more.

  
  

## Features

  

 - Show informations about OS and hardware
 - Config IP configuration
 - Config DNS settings
 - Ping, traceroute and nslookup servers
 - Manage users and localgroups
 - Defrag and check health of drives
 - Manage servicess and processess

  

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

  

  



## Development

  

  

- Written in C# using .NET 9

  

- Uses `System.Diagnostics.Process` to execute Windows built-in commands and PowerShell commands

  

- Menus handled via `Console.WriteLine`



- Public IP uses https://api.ipify.org

  
  

## Roadmap

  
 1. Im working on version 1.2.0 which will bring more tools

  
## Contributions

  
Contributions are very welcome! Please fork the repository, make your changes, and submit a pull request.


When reporting issues, please provide detailed steps to reproduce.

  


## License

  
This project is licensed under the MIT License — see the LICENSE file for details.

  


## Contact

  
- Created by Ján Repka Github: JaatrovyKnedlicek.

  
- E-mail: jankorepka888@gmail.com

  
- Discord: @jankogranko123


- Feel free to reach out for questions or suggestions.