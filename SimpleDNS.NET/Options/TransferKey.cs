using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options;

public class TransferKey : ICommittable
{
    [JsonIgnore]
    public bool Changed => _nameChanged | _algorithmChanged | _secretChanged;

    public void Commit()
    {
        _nameChanged = false;
        _algorithmChanged = false;
        _secretChanged = false;
    }

    [JsonProperty("Name")]
    public string Name { get => _nameValue;
        set { _nameChanged = true; _nameValue = value; } }
    private string _nameValue;
    private bool _nameChanged;

    [JsonProperty("Algorithm")]
    public TsigAlgorithm Algorithm { get => _algorithmValue;
        set { _algorithmChanged = true; _algorithmValue = value; } }
    private TsigAlgorithm _algorithmValue;
    private bool _algorithmChanged;

    [JsonProperty("Secret")]
    public string Secret { get => _secretValue;
        set { _secretChanged = true; _secretValue = value; } }
    private string _secretValue;
    private bool _secretChanged;
}