using System;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using PcapDotNet.Core;
using Sniffer.Lib.Configuration;
using Sniffer.Lib.Models;

namespace Sniffer.Core.Models;

public class PcapCaptureDevice : INetCaptureDevice
{
    private readonly IPacketDevice _captureDevice;

    public NetConfiguration NetConfiguration { get; }

    public PcapCaptureDevice(IPacketDevice captureDevice)
    {
        _captureDevice = captureDevice;

        NetConfiguration = new NetConfiguration(captureDevice.Name);
    }


    public void Dispose()
    {
    }

    public override string ToString()
    {
        return _captureDevice.Description;
    }

    public async void Capture(CancellationToken cancellationToken, INetCapture.PacketEventHandler onPacketArrival)
    {
        PacketCommunicator? communicator = null;
        try
        {
            await Task.Run(() =>
            {
                communicator = _captureDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000);
                communicator.SetFilter("tcp");
                do
                {
                    var result = communicator.ReceivePacket(out var packet);
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout:
                            continue;
                        case PacketCommunicatorReceiveResult.Ok:
                        {
                            if (packet.IpV4.Tcp.PayloadLength > 0)
                            {
                                onPacketArrival.Invoke(new PcapPacket(packet));
                            }
                        }
                            break;
                        case PacketCommunicatorReceiveResult.Eof:
                        case PacketCommunicatorReceiveResult.BreakLoop:
                        case PacketCommunicatorReceiveResult.None:
                        default:
                            throw new InvalidOperationException("PacketCommunicator InvalidOperationException");
                    }
                } while (!cancellationToken.IsCancellationRequested);
            });
        }
        finally
        {
            communicator?.Break();
            communicator?.Dispose();
        }
    }
}