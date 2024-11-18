using System.Globalization;
using System.Net.Sockets;
using System.Text;
using Humanizer;
using Zaxiure.HyprlandCsharp.Events;
using Zaxiure.HyprlandCsharp.Events.Models;
using Zaxiure.HyprlandCsharp.Helpers;
using Zaxiure.HyprlandCsharp.Interfaces;
using Newtonsoft.Json;
using Zaxiure.HyprlandCsharp.Models;
using Monitor = Zaxiure.HyprlandCsharp.Models.Monitor;

namespace Zaxiure.HyprlandCsharp;

using Monitor = Models.Monitor;

public class SocketCommandConnection
{
    public Socket _socket;
    private Thread? _currentThread;
    private readonly bool _reading = true;
    private readonly IEnumerable<Type> _events;

    public SocketCommandConnection()
    {
        _events = Program.GetTypesWithEventAttribute();
    }

    private async Task Connect()
    {
         var unixSocket = Environment.GetEnvironmentVariable("XDG_RUNTIME_DIR") + "/hypr/" + Environment.GetEnvironmentVariable("HYPRLAND_INSTANCE_SIGNATURE") + "/.socket.sock";
         var unixEp = new UnixDomainSocketEndPoint(unixSocket);
         _socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.IP);
         await _socket.ConnectAsync(unixEp);
    }

    public async Task<Client[]> GetClients()
    {
        var returnedJson = await SendCommand("[--batch-j]/clients");
        var result =  JsonConvert.DeserializeObject<Client[]>(returnedJson) ?? [];
        return result;
    }

    public async Task<Client?> GetActiveWindow()
    {
        var returnedJson = await SendCommand("[--batch-j]/activewindow");
        return JsonConvert.DeserializeObject<Client>(returnedJson);;
    }

    public async Task<Monitor[]> GetMonitors()
    {
        var returnedJson = await SendCommand("[--batch-j]/monitors");
        var result =  JsonConvert.DeserializeObject<Monitor[]>(returnedJson) ?? [];
        return result;
    }

    public async Task<WorkspaceModel[]> GetWorkspaces()
    {
        var returnedJson = await SendCommand("[--batch-j]/workspaces");
        var result =  JsonConvert.DeserializeObject<WorkspaceModel[]>(returnedJson) ?? [];
        return result;
    }

    public async Task<string> SendCommand(string command)
    {
        await Connect();
        await _socket.SendAsync(Encoding.UTF8.GetBytes(command));

        Thread.Sleep(50);

        var bytes = _socket.ReceiveAll();
        await _socket.DisconnectAsync(false);

        return Encoding.UTF8.GetString(bytes);
    }

    public void StopConnection()
    {
        _socket.Disconnect(false);
    }
    
}
