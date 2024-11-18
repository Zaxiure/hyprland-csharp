using Monitor = Zaxiure.HyprlandCsharp.Models.Monitor;

namespace Zaxiure.HyprlandCsharp.Events.Models;
using HyprlandCsharp.Models;

public class FocusedMonEvent : EventType
{
    public string? MonitorName { get; set; }
    public string? WorkspaceName { get; set; }

    public Monitor? CurrentMonitor { get; set; }

    public override async Task AfterObjectCreation(SocketCommandConnection socket)
    {
        var monitors = await socket.GetMonitors();
        var workspaces = await socket.GetWorkspaces();
        CurrentMonitor = monitors.FirstOrDefault(x => x.Name == MonitorName);
        if (CurrentMonitor != null)
        {
            var activeWorkspace = workspaces.FirstOrDefault(x => x.Id == CurrentMonitor?.ActiveWorkspaceModel.Id);
            var specialWorkspace = workspaces.FirstOrDefault(x => x.Id == CurrentMonitor?.ActiveWorkspaceModel.Id);
            if (activeWorkspace != null)
            {
                CurrentMonitor.ActiveWorkspaceModel = activeWorkspace;
            }
            if (specialWorkspace != null)
            {
                CurrentMonitor.SpecialWorkspaceModel = specialWorkspace;
            }
        }
    }

}