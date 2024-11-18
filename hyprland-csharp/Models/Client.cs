using Newtonsoft.Json;

namespace Zaxiure.HyprlandCsharp.Models;

public class Client
{
    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("mapped")]
    public bool Mapped { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }

    [JsonProperty("at")]
    public List<int> At { get; set; }

    [JsonProperty("size")]
    public List<int> Size { get; set; }

    [JsonProperty("workspace")]
    public WorkspaceModel WorkspaceModel { get; set; }

    [JsonProperty("floating")]
    public bool Floating { get; set; }

    [JsonProperty("pseudo")]
    public bool Pseudo { get; set; }

    [JsonProperty("monitor")]
    public int Monitor { get; set; }

    [JsonProperty("class")]
    public string Class { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("initialClass")]
    public string InitialClass { get; set; }

    [JsonProperty("initialTitle")]
    public string InitialTitle { get; set; }

    [JsonProperty("pid")]
    public int Pid { get; set; }

    [JsonProperty("xwayland")]
    public bool Xwayland { get; set; }

    [JsonProperty("pinned")]
    public bool Pinned { get; set; }

    [JsonProperty("fullscreen")]
    public int Fullscreen { get; set; }

    [JsonProperty("fullscreenClient")]
    public int FullscreenClient { get; set; }

    [JsonProperty("grouped")]
    public List<object> Grouped { get; set; }

    [JsonProperty("tags")]
    public List<object> Tags { get; set; }

    [JsonProperty("swallowing")]
    public string Swallowing { get; set; }

    [JsonProperty("focusHistoryID")]
    public int FocusHistoryID { get; set; }
}