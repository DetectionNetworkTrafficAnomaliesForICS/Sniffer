using System.Diagnostics;
using System.Threading.Channels;
using Sniffer.Lib.Services.Interfaces;

namespace Sniffer.Core.Services.Impl;

public class ShellLauncherServiceImpl : IShellLauncherService
{
    public async void ExecuteShellCommand(string command, string argument, ChannelReader<string> input,
        ChannelWriter<string> output,
        CancellationToken cancellationToken)
    {
        using var process = new Process();
        process.StartInfo.FileName = command;
        process.StartInfo.Arguments = argument;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.CreateNoWindow = true;

        var (redirectOut, redirectErr) = (
            process.StartInfo.RedirectStandardOutput,
            process.StartInfo.RedirectStandardError
        );

        if (!process.Start())
        {
            throw new InvalidOperationException();
        }

        if (redirectOut)
        {
            process.OutputDataReceived += async (sender, e) =>
            {
                if (e.Data != null)
                {
                    await output.WriteAsync(e.Data, cancellationToken);
                }
            };
            process.BeginOutputReadLine();
        }

        if (redirectErr)
        {
            process.BeginErrorReadLine();
        }


        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var request = await input.ReadAsync(cancellationToken);
                await process.StandardInput.WriteLineAsync(request);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        process.Kill();
    }
}