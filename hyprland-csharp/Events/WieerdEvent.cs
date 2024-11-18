using Newtonsoft.Json;
using Zaxiure.HyprlandCsharp.Events.Models;
using Zaxiure.HyprlandCsharp.Interfaces;

namespace Zaxiure.HyprlandCsharp.Events;

public class WieerdEvent : HyprEvent<ActiveWindowEvent>
{

    public override void HandleEvent(ActiveWindowEvent eventData)
    {
        Console.WriteLine(eventData.WindowClass);
        Console.WriteLine(eventData.CurrentClient);
    }

}