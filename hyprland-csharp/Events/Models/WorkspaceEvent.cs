using Zaxiure.HyprlandCsharp.Models;

namespace Zaxiure.HyprlandCsharp.Events.Models;
using HyprlandCsharp.Models;

public class WorkspaceEvent : EventType
{
    public string WorkspaceName { get; set; }

    public WorkspaceModel? CurrentWorkspace { get; set; }

    public override async Task AfterObjectCreation(SocketCommandConnection socket)
    {
        var workspaces = await socket.GetWorkspaces();
        Console.WriteLine(WorkspaceName);
        CurrentWorkspace = workspaces.FirstOrDefault(x => x.Name == WorkspaceName);
    }

}