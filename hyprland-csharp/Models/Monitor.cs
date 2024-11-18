using Newtonsoft.Json;

namespace Zaxiure.HyprlandCsharp.Models;

public class Monitor
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("make")]
    public string Make { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("serial")]
    public string Serial { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("refreshRate")]
    public double RefreshRate { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }

    [JsonProperty("activeWorkspace")]
    public WorkspaceModel ActiveWorkspaceModel { get; set; }

    [JsonProperty("specialWorkspace")]
    public WorkspaceModel SpecialWorkspaceModel { get; set; }

    [JsonProperty("reserved")]
    public List<int> Reserved { get; set; }

    [JsonProperty("scale")]
    public double Scale { get; set; }

    [JsonProperty("transform")]
    public int Transform { get; set; }

    [JsonProperty("focused")]
    public bool Focused { get; set; }

    [JsonProperty("dpmsStatus")]
    public bool DpmsStatus { get; set; }

    [JsonProperty("vrr")]
    public bool Vrr { get; set; }

    [JsonProperty("solitary")]
    public string Solitary { get; set; }

    [JsonProperty("activelyTearing")]
    public bool ActivelyTearing { get; set; }

    [JsonProperty("disabled")]
    public bool Disabled { get; set; }

    [JsonProperty("currentFormat")]
    public string CurrentFormat { get; set; }

    [JsonProperty("availableModes")]
    public List<string> AvailableModes { get; set; }
}