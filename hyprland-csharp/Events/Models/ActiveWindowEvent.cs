using Zaxiure.HyprlandCsharp.Models;

namespace Zaxiure.HyprlandCsharp.Events.Models;

public class ActiveWindowEvent : EventType
{

    public string? WindowClass { get; set; }
    public string? WindowTitle { get; set; }
    public Client? CurrentClient { get; set; }

    public override async Task AfterObjectCreation(SocketCommandConnection socket)
    {
        var clients = await socket.GetClients();
        CurrentClient = clients.FirstOrDefault(x => x.Class == WindowClass);
    }
}