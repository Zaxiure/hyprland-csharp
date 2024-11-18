using Zaxiure.HyprlandCsharp.Models;

namespace Zaxiure.HyprlandCsharp.Events.Models;
using HyprlandCsharp.Models;

public class WorkspaceV2Event : EventType
{
    public int WorkspaceId { get; set; }
    public string WorkspaceName { get; set; }

    public WorkspaceModel? CurrentWorkspace { get; set; }

    public override async Task AfterObjectCreation(SocketCommandConnection socket)
    {
        var workspaces = await socket.GetWorkspaces();
        CurrentWorkspace = workspaces.FirstOrDefault(x => x.Id == WorkspaceId);
    }

}