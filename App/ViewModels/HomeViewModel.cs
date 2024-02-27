using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Sniffer.ViewModels;

public partial class HomeViewModel : AViewModel
{
    private bool _isTimerRunning;
    
    [ObservableProperty]
    private Stopwatch _stopwatch = new();

    [ObservableProperty]
    private bool _isStartButtonEnabled = true;
    
    [ObservableProperty]
    private bool _isStopButtonEnabled;

    
    private string _timerText = "00:00:000";
    public string TimerText
    {
        get => _timerText;
        private set
        {
            if (_timerText == value) return;
            _timerText = value;
            OnPropertyChanged();
        }
    }
    
    [RelayCommand]
    private void StartSniffer()
    {
        _isTimerRunning = true;
        IsStartButtonEnabled = false;
        IsStopButtonEnabled = true;
        
        Stopwatch.Restart();
        Application.Current?.Dispatcher.StartTimer(TimeSpan.FromMilliseconds(100), UpdateTimer);
    }

    [RelayCommand]
    private void StopSniffer()
    {
        _isTimerRunning = false;
        IsStartButtonEnabled = true;
        IsStopButtonEnabled = false;
    }
    

     
    private bool UpdateTimer()
    {
        if (_isTimerRunning)
        {
            Application.Current?.Dispatcher.Dispatch(UpdateTimerText);
        }

        return _isTimerRunning;
    }

    private void UpdateTimerText()
    {
        var elapsed = Stopwatch.Elapsed;
        TimerText = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}:{elapsed.Milliseconds:D3}";
    }
}