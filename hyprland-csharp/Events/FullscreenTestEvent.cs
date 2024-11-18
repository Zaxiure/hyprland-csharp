using Zaxiure.HyprlandCsharp.Events.Models;
using Zaxiure.HyprlandCsharp.Interfaces;

namespace Zaxiure.HyprlandCsharp.Events;

public class FullscreenTestEvent : HyprEvent<FullscreenEvent>
{

    public override void HandleEvent(FullscreenEvent eventData)
    {
        Console.WriteLine(eventData.CurrentWindow?.Title);
    }

}