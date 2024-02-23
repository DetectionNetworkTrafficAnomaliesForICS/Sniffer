using Sniffer.ViewModels;

namespace Sniffer.View.Pages;

public partial class AboutPage : ContentPage
{
    public AboutPage(AboutViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}