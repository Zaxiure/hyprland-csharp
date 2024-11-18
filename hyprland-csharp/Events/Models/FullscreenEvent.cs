using Zaxiure.HyprlandCsharp.Models;

namespace Zaxiure.HyprlandCsharp.Events.Models;

public class FullscreenEvent : EventType
{
     public bool IsFullscreen { get; set; }
     public Client? CurrentWindow { get; set; }

     public override async Task AfterObjectCreation(SocketCommandConnection socket)
     {
         CurrentWindow = await socket.GetActiveWindow();
     }
}