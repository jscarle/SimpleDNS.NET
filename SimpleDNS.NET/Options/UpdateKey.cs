using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options;

public class UpdateKey : ICommittable
{
    public UpdateKey()
    {
        _domainsValue = new StringList();
    }

    [JsonIgnore]
    public bool Changed => _keyNameChanged | _algorithmChanged | _secretChanged | _updateChanged | _domainsChanged | _domainsValue.Changed;

    public void Commit()
    {
        _keyNameChanged = false;
        _algorithmChanged = false;
        _secretChanged = false;
        _updateChanged = false;
        _domainsChanged = false;

        _domainsValue.Commit();
    }

    [JsonProperty("KeyName")]
    public string KeyName { get => _keyNameValue;
        set { _keyNameChanged = true; _keyNameValue = value; } }
    private string _keyNameValue;
    private bool _keyNameChanged;

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

    [JsonProperty("Update")]
    public string Update { get => _updateValue;
        set { _updateChanged = true; _updateValue = value; } }
    private string _updateValue;
    private bool _updateChanged;

    [JsonProperty("Domains")]
    public StringList Domains { get => _domainsValue;
        set { _domainsChanged = true; _domainsValue = value; } }
    private StringList _domainsValue;
    private bool _domainsChanged;
}