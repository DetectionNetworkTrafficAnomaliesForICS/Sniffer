using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sniffer.Models;
using Sniffer.Repositories;
using Sniffer.Services;
using Directory = Sniffer.Models.Directory;

namespace Sniffer.ViewModels;

public partial class SettingViewModel : AViewModel
{
    private readonly ISettingsService _settingsService;
    private readonly INetService _netService;
    private readonly IDirectoryService _directoryService;

    [ObservableProperty]
    private Directory _selectedDirectory;

    [ObservableProperty]
    private NetInterface _selectedNetInterface;

    public List<NetInterface> NetInterfaces { get; private set; }

    public SettingViewModel(
        ISettingsService settingsService, IDirectoryService directoryService, INetService netService)
    {
        _settingsService = settingsService;
        _directoryService = directoryService;
        _netService = netService;

        UploadDefault();
    }

    private void UploadDefault()
    {
        NetInterfaces = _netService.GetAll();
        SelectedNetInterface = _settingsService.NetInterface;
        SelectedDirectory = _settingsService.TrafficDirectory;
    }

    [RelayCommand]
    private void UpdateSettings()
    {
        _settingsService.TrafficDirectory = SelectedDirectory;
        _settingsService.NetInterface = SelectedNetInterface;
    }

    [RelayCommand]
    private async void SelectDirectory()
    {
        var result = await _directoryService.PickDirectory();
        if (result == null)
            return;

        SelectedDirectory = result;
    }
}