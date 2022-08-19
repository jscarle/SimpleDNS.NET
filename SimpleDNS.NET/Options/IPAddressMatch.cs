using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options;

public class IpAddressMatch : ICommittable
{
    public IpAddressMatch()
    {
        _itemsValue = new IpAddressRangeList();
    }

    [JsonIgnore]
    public bool Changed => _matchChanged | _itemsChanged | _itemsValue.Changed;

    public void Commit()
    {
        _matchChanged = false;
        _itemsChanged = false;

        _itemsValue.Commit();
    }

    [JsonProperty("Match")]
    public MatchType Match { get => _matchValue;
        set { _matchChanged = true; _matchValue = value; } }
    private MatchType _matchValue;
    private bool _matchChanged;

    [JsonProperty("Items")]
    public IpAddressRangeList Items { get => _itemsValue;
        set { _itemsChanged = true; _itemsValue = value; } }
    private IpAddressRangeList _itemsValue;
    private bool _itemsChanged;
}