using Newtonsoft.Json;
using Zaxiure.HyprlandCsharp.Events.Models;
using Zaxiure.HyprlandCsharp.Interfaces;

namespace Zaxiure.HyprlandCsharp.Events;

public class FocusedMonitor : HyprEvent<WorkspaceV2Event>
{

    public override void HandleEvent(WorkspaceV2Event eventData)
    {
        Console.WriteLine(eventData.CurrentWorkspace?.Hasfullscreen);
    }
}