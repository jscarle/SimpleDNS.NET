using Newtonsoft.Json;

namespace SimpleDNS.Options;

public class Forward : ICommittable
{
    public Forward()
    {
        _ipValue = new IpAddressList();
    }

    [JsonIgnore]
    public bool Changed => _domainChanged | _extendedChanged | _shadowChanged | _shadowAaChanged | _ipChanged | _ipValue.Changed;

    public void Commit()
    {
        _domainChanged = false;
        _extendedChanged = false;
        _shadowChanged = false;
        _shadowAaChanged = false;
        _ipChanged = false;

        _ipValue.Commit();
    }

    [JsonProperty("Domain")]
    public string Domain { get => _domainValue;
        set { _domainChanged = true; _domainValue = value; } }
    private string _domainValue;
    private bool _domainChanged;

    [JsonProperty("Extended")]
    public bool Extended { get => _extendedValue;
        set { _extendedChanged = true; _extendedValue = value; } }
    private bool _extendedValue;
    private bool _extendedChanged;

    [JsonProperty("Shadow")]
    public bool Shadow { get => _shadowValue;
        set { _shadowChanged = true; _shadowValue = value; } }
    private bool _shadowValue;
    private bool _shadowChanged;

    [JsonProperty("ShadowAA")]
    public bool ShadowAa { get => _shadowAaValue;
        set { _shadowAaChanged = true; _shadowAaValue = value; } }
    private bool _shadowAaValue;
    private bool _shadowAaChanged;

    [JsonProperty("IP")]
    public IpAddressList Ip { get => _ipValue;
        set { _ipChanged = true; _ipValue = value; } }
    private IpAddressList _ipValue;
    private bool _ipChanged;
}