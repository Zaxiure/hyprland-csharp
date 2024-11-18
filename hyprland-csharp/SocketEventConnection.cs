using System.Net.Sockets;
using System.Text;
using Zaxiure.HyprlandCsharp.Helpers;

namespace Zaxiure.HyprlandCsharp;

public class SocketEventConnection
{
    private readonly Socket _socket;
    private Thread? _currentThread;
    private readonly bool _reading = true;
    private readonly IEnumerable<Type> _events;
    private SocketCommandConnection _socketCommand;

    public SocketEventConnection(SocketCommandConnection socketCommand)
    {
        _socketCommand = socketCommand;
        _events = Program.GetTypesWithEventAttribute();
        var unixSocket = Environment.GetEnvironmentVariable("XDG_RUNTIME_DIR") + "/hypr/" + Environment.GetEnvironmentVariable("HYPRLAND_INSTANCE_SIGNATURE") + "/.socket2.sock";
        var unixEp = new UnixDomainSocketEndPoint(unixSocket);

        _socket = new Socket(AddressFamily.Unix, SocketType.Stream, ProtocolType.IP);
        _socket.Connect(unixEp);
    }

    public void StartReader()
    {
        if (_currentThread != null) return;
        _currentThread = new Thread(async () =>
        {
            while (_reading && _socket.Connected)
            {
                var receivedBytes = new byte[1024];
                _socket.Receive(receivedBytes);
                var receivedString = Encoding.UTF8.GetString(receivedBytes);

                var splitReceived = receivedString.Trim().Split("\n");
                foreach (var s in splitReceived)
                {
                    var stringParts = s.Split(">>");

                    var foundEvents = _events.Where(x => string.Equals(x.BaseType?.GetGenericArguments()[0].Name.ToLower().Replace("event", ""), stringParts[0], StringComparison.CurrentCultureIgnoreCase));
                    if (foundEvents.Any())
                    {

                        foreach (var foundEvent in foundEvents)
                        {
                            var classInstance = Activator.CreateInstance(foundEvent);
                            var handleEventMethod = foundEvent.GetMethod("HandleEvent");
                            var createEventObject = foundEvent.GetMethod("CreateEventObject");

                            var createdObject = await createEventObject?.InvokeAsync(classInstance, [_socketCommand, stringParts[1].Split(",")])!;
                            handleEventMethod?.Invoke(classInstance, [createdObject]);
                        }

                    }
                }
            }
        });
        _currentThread.Start();
    }

    public void StopConnection()
    {
        _socket.Disconnect(false);
    }
    
}