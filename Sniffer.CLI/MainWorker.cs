﻿using Microsoft.Extensions.Hosting;
using Sniffer.CLI.Commands;

namespace Sniffer.CLI;

public class MainWorker : BackgroundService
{
    private readonly SettingCommands _settingCommands;
    private readonly SnifferCommands _snifferCommands;
    private readonly AnalysisCommands _analysisCommands;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public MainWorker(SettingCommands settingCommands, SnifferCommands snifferCommands,
        IHostApplicationLifetime applicationLifetime, AnalysisCommands analysisCommands)
    {
        _settingCommands = settingCommands;
        _snifferCommands = snifferCommands;
        _applicationLifetime = applicationLifetime;
        _analysisCommands = analysisCommands;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Launch of the program \"Sniffer\"");
        Console.WriteLine("A component of a bachelor's degree NSU Information Technology Department");
        Console.WriteLine("Student: Kotov Rodion");
        Console.WriteLine("Organization: Institute of Automation and Electrometry of the Siberian Branch of the RAS");
        Console.WriteLine("\n");

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine(">Menu:");
            Console.WriteLine("1. Start Sniffer");
            Console.WriteLine("2. Analysis");
            Console.WriteLine("3. Setting");
            Console.WriteLine("4. Exit");

            Console.Write(">Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _snifferCommands.Run();
                    break;
                case "2":
                    _analysisCommands.Run();
                    break;
                case "3":
                    _settingCommands.Run();
                    break;
                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    _applicationLifetime.StopApplication();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }

        return Task.CompletedTask;
    }
}