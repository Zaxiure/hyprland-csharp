using Zaxiure.HyprlandCsharp.Events.Models;
using Zaxiure.HyprlandCsharp.Interfaces;

namespace Zaxiure.HyprlandCsharp.Events;

public class Test : HyprEvent<ActiveWindowEvent>
{

    public override void HandleEvent(ActiveWindowEvent eventData)
    {
    }

}