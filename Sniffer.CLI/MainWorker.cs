﻿using Microsoft.Extensions.Hosting;
using Sniffer.CLI.Commands;

namespace Sniffer.CLI;

public class MainWorker : BackgroundService
{
    private readonly SettingCommands _settingCommands;
    private readonly SnifferCommands _snifferCommands;

    public MainWorker(SettingCommands settingCommands, SnifferCommands snifferCommands)
    {
        _settingCommands = settingCommands;
        _snifferCommands = snifferCommands;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Hello, this CLI program Sniffer!");

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(">Menu:");
            Console.WriteLine("1. Start Sniffer");
            Console.WriteLine("2. Setting");
            Console.WriteLine("3. Exit");

            Console.Write(">Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _snifferCommands.Run();
                    break;
                case "2":
                    _settingCommands.Run();
                    break;
                case "3":
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }

        return Task.CompletedTask;
    }
}