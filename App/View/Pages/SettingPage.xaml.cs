using Sniffer.ViewModels;

namespace Sniffer.View.Pages;

public partial class SettingPage : ContentPage
{
    public SettingPage(SettingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}