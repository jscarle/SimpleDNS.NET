using System.Net;
using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class IpAlias : ICommittable
{
    [JsonIgnore]
    public bool Changed => _extChanged | _intChanged;

    public void Commit()
    {
        _extChanged = false;
        _intChanged = false;
    }

    [JsonProperty("Ext")]
    public IPAddress Ext { get => _extValue;
        set { _extChanged = true; _extValue = value; } }
    private IPAddress _extValue;
    private bool _extChanged;

    [JsonProperty("Int")]
    public IPAddress Int { get => _intValue;
        set { _intChanged = true; _intValue = value; } }
    private IPAddress _intValue;
    private bool _intChanged;
}