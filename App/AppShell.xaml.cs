﻿using Sniffer.Pages;

namespace Sniffer;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
    }
}