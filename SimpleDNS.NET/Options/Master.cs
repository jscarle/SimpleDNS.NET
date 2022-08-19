using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class Master : ICommittable
{
    public Master()
    {
        _sigKeyValue = new Key();
    }

    [JsonIgnore]
    public bool Changed => _ipChanged | _sigKeyChanged | _sigKeyValue.Changed;

    public void Commit()
    {
        _ipChanged = false;
        _sigKeyChanged = false;

        _sigKeyValue.Commit();
    }

    [JsonProperty("IP")]
    public IPAddress Ip { get => _ipValue;
        set { _ipChanged = true; _ipValue = value; } }
    private IPAddress _ipValue;
    private bool _ipChanged;

    [JsonProperty("TSigKey")]
    public Key SigKey { get => _sigKeyValue;
        set { _sigKeyChanged = true; _sigKeyValue = value; } }
    private Key _sigKeyValue;
    private bool _sigKeyChanged;
}