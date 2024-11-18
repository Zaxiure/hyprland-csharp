using Newtonsoft.Json;
using Zaxiure.HyprlandCsharp.Models;

namespace Zaxiure.HyprlandCsharp.Events.Models;

public class ActiveWindowV2Event : EventType
{
    public string? WindowAddress { get; set; }
    public Client? CurrentClient { get; set; }

    public override async Task AfterObjectCreation(SocketCommandConnection socket)
    {
        var clients = await socket.GetClients();
        CurrentClient = clients.FirstOrDefault(x => x.Address == "0x" + WindowAddress);
    }

}