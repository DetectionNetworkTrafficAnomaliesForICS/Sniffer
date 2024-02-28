using Sniffer.Lib.Models;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.CLI.Commands;

public class SettingCommands
{
    private readonly ISettingsService _settingsService;

    public SettingCommands(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(">>Menu Setting:");
            Console.WriteLine("1. Main Folder");
            Console.WriteLine("2. Device");
            Console.WriteLine("3. Exit");

            Console.Write(">>Enter your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SettingFolder();
                    break;
                case "2":

                    break;
                case "3":
                    Console.WriteLine("Exiting Setting.");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    private void SettingFolder()
    {
        while (true)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine(">>>Menu Main Folder:");
            Console.WriteLine("1. Read");
            Console.WriteLine("2. ReWrite");
            Console.WriteLine("3. Exit");
            Console.Write(">>>Enter your choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine(_settingsService.TrafficFolder);
                    break;
                case "2":
                    Console.Write("Enter path: ");
                    var path = Console.ReadLine();
                    if (path != null) _settingsService.TrafficFolder = new Folder(path);
                    break;
                case "3":
                    Console.WriteLine("Exiting Setting.");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}