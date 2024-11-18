using Newtonsoft.Json;

namespace Zaxiure.HyprlandCsharp.Models;

public class WorkspaceModel
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("monitor")]
    public string? Monitor { get; set; }

    [JsonProperty("monitorID")]
    public int? MonitorID { get; set; }

    [JsonProperty("windows")]
    public int? Windows { get; set; }

    [JsonProperty("hasfullscreen")]
    public bool? Hasfullscreen { get; set; }

    [JsonProperty("lastwindow")]
    public string? Lastwindow { get; set; }

    [JsonProperty("lastwindowtitle")]
    public string? Lastwindowtitle { get; set; }
}