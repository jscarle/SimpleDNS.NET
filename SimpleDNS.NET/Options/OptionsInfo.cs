using System.Net;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options;

// https://simpledns.com/swagger-ui/
public class OptionsInfo : ICommittable
{
    public OptionsInfo()
    {
        _dnsInIPsValue = new IpAddressList();
        _dnsRecursionAllowValue = new IpAddressMatch();
        _dnsRespFilterRemoveValue = new IpAddressRangeList();
        _dnsRespFilterTrustValue = new IpAddressRangeList();
        _dnsZoneTransferKeysValue = new TransferKeyList();
        _dnsZoneTransferIPsValue = new IpAddressMatch();
        _dnsMasterSlaveSlavesValue = new IpAddressRangeList();
        _dnsMasterSlaveMastersValue = new MasterList();
        _dnsTsigUpdateKeysValue = new UpdateKeyList();
        _dnsForwardValue = new ForwardList();
        _dnsNxDomainExceptDomainsValue = new StringList();
        _dnsNxDomainExceptIPsValue = new IpAddressRangeList();
        _dnsNatipAliasAliasesValue = new IpAliasList();
        _dnsNatipAliasLaniPsValue = new IpAddressRangeList();
        _httpapiCorsOriginsValue = new StringList();
        _logWinEventsExcludeValue = new WindowsEventsList();
    }

    [JsonIgnore]
    public bool Changed =>
        _changed |
        _generalNameChanged |
        _generalTrayBarChanged |
        _dnsInListenAllChanged |
        _dnsInIPsChanged |
        _dnsInPortChanged |
        _dnsInMaxTcpChanged |
        _dnsOutViaIPv4Changed |
        _dnsOutViaIPv6Changed |
        _dnsOutFromIPv4Changed |
        _dnsOutFromIPv6Changed |
        _dnsOutPortUdpRandomChanged |
        _dnsOutPortUdpChanged |
        _dnsOutEdnsChanged |
        _dnsRecursionAllowChanged |
        _dnsRecursionMaxParallelChanged |
        _dnsRecursionMatchRespIpChanged |
        _dnsRecursionIgnoreNoQSectChanged |
        _dnsRecursionDns0X20Changed |
        _dnsRespFilterEnableChanged |
        _dnsRespFilterRemoveChanged |
        _dnsRespFilterTrustChanged |
        _dnsCacheEnableChanged |
        _dnsCacheMaxTtlChanged |
        _dnsCacheMaxNegativeTtlChanged |
        _dnsCacheMaxRecordsChanged |
        _dnsCacheReloadChanged |
        _dnsCacheMinTtlChanged |
        _dnsZoneTransferKeysChanged |
        _dnsZoneTransferIPsChanged |
        _dnsZoneTransferOneRecChanged |
        _dnsMasterSlaveSlavesChanged |
        _dnsMasterSlaveUnsignedChanged |
        _dnsMasterSlaveMastersChanged |
        _dnsMasterSlaveVerifyIvChanged |
        _dnsSecondaryRefreshPerSecChanged |
        _dnsSecondaryMaxParallelChanged |
        _dnsSecondaryExpiredRetryChanged |
        _dnsSecondaryUseIxfrChanged |
        _dnsSecondaryOnlyPrimIpNotifyChanged |
        _dnsSecondaryMinSoaRefreshChanged |
        _dnsSecondaryMinSoaRetryChanged |
        _dnsSecondaryMinSoaExpireChanged |
        _dnsSuspZoneActionChanged |
        _dnsSuspZoneSynthAChanged |
        _dnsSuspZoneSynthAaaaChanged |
        _dnsSuspZoneSynthMxChanged |
        _dnsAutoSpfEnableChanged |
        _dnsAutoSpfDataChanged |
        _dnsAutoSpfTtlChanged |
        _dnsTsigUpdateKeysChanged |
        _dnsZoneVersionsChanged |
        _dnsForwardChanged |
        _dnsLameActionChanged |
        _dnsLameSynthAChanged |
        _dnsLameSynthAaaaChanged |
        _dnsLameSynthMxChanged |
        _dnsNxDomainEnableChanged |
        _dnsNxDomainIPv4Changed |
        _dnsNxDomainIPv6Changed |
        _dnsNxDomainOnlyWwwChanged |
        _dnsNxDomainExceptAaChanged |
        _dnsNxDomainExceptDnsblChanged |
        _dnsNxDomainExceptDomainsChanged |
        _dnsNxDomainExceptIPsChanged |
        _dnsNatipAliasEnableChanged |
        _dnsNatipAliasAliasesChanged |
        _dnsNatipAliasLaniPsChanged |
        _dnsNatipAliasSelfOnLanChanged |
        _dnsMiscRoundRobinChanged |
        _dnsMiscSendNotifyChanged |
        _dnsMiscAutoUpdateRootChanged |
        _dnsMiscStandardEmptyZonesChanged |
        _dnsMiscEdnsPayLoadChanged |
        _dnsMiscBindVerChanged |
        _dnsMiscBindVerTxtChanged |
        _dnsMiscLccChanged |
        _dnsMiscLccMaxChanged |
        _dnsMiscUdpRootProcChanged |
        _dnsMiscUdpRootLogChanged |
        _dnsMiscUdpAnyProcChanged |
        _dnsMiscUdpAnyLogChanged |
        _httpapiEnableChanged |
        _httpapiPrefixChanged |
        _httpapiAuthChanged |
        _httpapiWinUserChanged |
        _httpapiUserIdChanged |
        _httpapiPasswordChanged |
        _httpapiCorsEnableChanged |
        _httpapiCorsOriginsChanged |
        _httpapiEnableV1Changed |
        _logDetailsRecordsChanged |
        _logDetailsEdns0Changed |
        _logDetailsOutgoingChanged |
        _logDetailsBlockedChanged |
        _logDetailsOnlyErrorsChanged |
        _logDetailsIdnNativeChanged |
        _logFilesBeginChanged |
        _logFilesRecycleChanged |
        _logFilesRawChanged |
        _logFilesHttpFullReqChanged |
        _logFilesPathChanged |
        _logSyslogEnableChanged |
        _logSyslogIpChanged |
        _logSyslogPortChanged |
        _logActiveLogLinesChanged |
        _logActiveLogBufferChanged |
        _logWinEventsEnableChanged |
        _logWinEventsExcludeChanged |
        _remoteEnableChanged |
        _remotePortChanged |
        _remotePasswordChanged;

    private bool _changed;
    public void Commit()
    {
        _changed = false;

        _generalNameChanged = false;
        _generalTrayBarChanged = false;
        _dnsInListenAllChanged = false;
        _dnsInIPsChanged = false;
        _dnsInPortChanged = false;
        _dnsInMaxTcpChanged = false;
        _dnsOutViaIPv4Changed = false;
        _dnsOutViaIPv6Changed = false;
        _dnsOutFromIPv4Changed = false;
        _dnsOutFromIPv6Changed = false;
        _dnsOutPortUdpRandomChanged = false;
        _dnsOutPortUdpChanged = false;
        _dnsOutEdnsChanged = false;
        _dnsRecursionAllowChanged = false;
        _dnsRecursionMaxParallelChanged = false;
        _dnsRecursionMatchRespIpChanged = false;
        _dnsRecursionIgnoreNoQSectChanged = false;
        _dnsRecursionDns0X20Changed = false;
        _dnsRespFilterEnableChanged = false;
        _dnsRespFilterRemoveChanged = false;
        _dnsRespFilterTrustChanged = false;
        _dnsCacheEnableChanged = false;
        _dnsCacheMaxTtlChanged = false;
        _dnsCacheMaxNegativeTtlChanged = false;
        _dnsCacheMaxRecordsChanged = false;
        _dnsCacheReloadChanged = false;
        _dnsCacheMinTtlChanged = false;
        _dnsZoneTransferKeysChanged = false;
        _dnsZoneTransferIPsChanged = false;
        _dnsZoneTransferOneRecChanged = false;
        _dnsMasterSlaveSlavesChanged = false;
        _dnsMasterSlaveUnsignedChanged = false;
        _dnsMasterSlaveMastersChanged = false;
        _dnsMasterSlaveVerifyIvChanged = false;
        _dnsSecondaryRefreshPerSecChanged = false;
        _dnsSecondaryMaxParallelChanged = false;
        _dnsSecondaryExpiredRetryChanged = false;
        _dnsSecondaryUseIxfrChanged = false;
        _dnsSecondaryOnlyPrimIpNotifyChanged = false;
        _dnsSecondaryMinSoaRefreshChanged = false;
        _dnsSecondaryMinSoaRetryChanged = false;
        _dnsSecondaryMinSoaExpireChanged = false;
        _dnsSuspZoneActionChanged = false;
        _dnsSuspZoneSynthAChanged = false;
        _dnsSuspZoneSynthAaaaChanged = false;
        _dnsSuspZoneSynthMxChanged = false;
        _dnsAutoSpfEnableChanged = false;
        _dnsAutoSpfDataChanged = false;
        _dnsAutoSpfTtlChanged = false;
        _dnsTsigUpdateKeysChanged = false;
        _dnsZoneVersionsChanged = false;
        _dnsForwardChanged = false;
        _dnsLameActionChanged = false;
        _dnsLameSynthAChanged = false;
        _dnsLameSynthAaaaChanged = false;
        _dnsLameSynthMxChanged = false;
        _dnsNxDomainEnableChanged = false;
        _dnsNxDomainIPv4Changed = false;
        _dnsNxDomainIPv6Changed = false;
        _dnsNxDomainOnlyWwwChanged = false;
        _dnsNxDomainExceptAaChanged = false;
        _dnsNxDomainExceptDnsblChanged = false;
        _dnsNxDomainExceptDomainsChanged = false;
        _dnsNxDomainExceptIPsChanged = false;
        _dnsNatipAliasEnableChanged = false;
        _dnsNatipAliasAliasesChanged = false;
        _dnsNatipAliasLaniPsChanged = false;
        _dnsNatipAliasSelfOnLanChanged = false;
        _dnsMiscRoundRobinChanged = false;
        _dnsMiscSendNotifyChanged = false;
        _dnsMiscAutoUpdateRootChanged = false;
        _dnsMiscStandardEmptyZonesChanged = false;
        _dnsMiscEdnsPayLoadChanged = false;
        _dnsMiscBindVerChanged = false;
        _dnsMiscBindVerTxtChanged = false;
        _dnsMiscLccChanged = false;
        _dnsMiscLccMaxChanged = false;
        _dnsMiscUdpRootProcChanged = false;
        _dnsMiscUdpRootLogChanged = false;
        _dnsMiscUdpAnyProcChanged = false;
        _dnsMiscUdpAnyLogChanged = false;
        _httpapiEnableChanged = false;
        _httpapiPrefixChanged = false;
        _httpapiAuthChanged = false;
        _httpapiWinUserChanged = false;
        _httpapiUserIdChanged = false;
        _httpapiPasswordChanged = false;
        _httpapiCorsEnableChanged = false;
        _httpapiCorsOriginsChanged = false;
        _httpapiEnableV1Changed = false;
        _logDetailsRecordsChanged = false;
        _logDetailsEdns0Changed = false;
        _logDetailsOutgoingChanged = false;
        _logDetailsBlockedChanged = false;
        _logDetailsOnlyErrorsChanged = false;
        _logDetailsIdnNativeChanged = false;
        _logFilesBeginChanged = false;
        _logFilesRecycleChanged = false;
        _logFilesRawChanged = false;
        _logFilesHttpFullReqChanged = false;
        _logFilesPathChanged = false;
        _logSyslogEnableChanged = false;
        _logSyslogIpChanged = false;
        _logSyslogPortChanged = false;
        _logActiveLogLinesChanged = false;
        _logActiveLogBufferChanged = false;
        _logWinEventsEnableChanged = false;
        _logWinEventsExcludeChanged = false;
        _remoteEnableChanged = false;
        _remotePortChanged = false;
        _remotePasswordChanged = false;

        _dnsInIPsValue.Commit();
        _dnsRecursionAllowValue.Commit();
        _dnsRespFilterRemoveValue.Commit();
        _dnsRespFilterTrustValue.Commit();
        _dnsZoneTransferKeysValue.Commit();
        _dnsZoneTransferIPsValue.Commit();
        _dnsMasterSlaveSlavesValue.Commit();
        _dnsMasterSlaveMastersValue.Commit();
        _dnsTsigUpdateKeysValue.Commit();
        _dnsForwardValue.Commit();
        _dnsNxDomainExceptDomainsValue.Commit();
        _dnsNxDomainExceptIPsValue.Commit();
        _dnsNatipAliasAliasesValue.Commit();
        _dnsNatipAliasLaniPsValue.Commit();
        _httpapiCorsOriginsValue.Commit();
        _logWinEventsExcludeValue.Commit();
    }

    [JsonProperty("General_Name")]
    public string GeneralName { get => _generalNameValue;
        set { _generalNameChanged = true; _generalNameValue = value; } }
    private string _generalNameValue;
    private bool _generalNameChanged;
    public bool ShouldSerializeGeneral_Name() { return _generalNameChanged; }

    [JsonProperty("General_TrayBar")]
    public bool GeneralTrayBar { get => _generalTrayBarValue;
        set { _generalTrayBarChanged = true; _generalTrayBarValue = value; } }
    private bool _generalTrayBarValue;
    private bool _generalTrayBarChanged;
    public bool ShouldSerializeGeneral_TrayBar() { return _generalTrayBarChanged; }

    [JsonProperty("DNS_In_ListenAll")]
    public bool DnsInListenAll { get => _dnsInListenAllValue;
        set { _dnsInListenAllChanged = true; _dnsInListenAllValue = value; } }
    private bool _dnsInListenAllValue;
    private bool _dnsInListenAllChanged;
    public bool ShouldSerializeDNS_In_ListenAll() { return _dnsInListenAllChanged; }

    [JsonProperty("DNS_In_IPs")]
    public IpAddressList DnsInIPs { get => _dnsInIPsValue;
        set { _dnsInIPsChanged = true; _dnsInIPsValue = value; } }
    private IpAddressList _dnsInIPsValue;
    private bool _dnsInIPsChanged;
    public bool ShouldSerializeDNS_In_IPs() { return _dnsInIPsChanged | _dnsInIPsValue.Changed; }

    [JsonProperty("DNS_In_Port")]
    public ushort DnsInPort { get => _dnsInPortValue;
        set { _dnsInPortChanged = true; _dnsInPortValue = value; } }
    private ushort _dnsInPortValue;
    private bool _dnsInPortChanged;
    public bool ShouldSerializeDNS_In_Port() { return _dnsInPortChanged; }

    [JsonProperty("DNS_In_MaxTCP")]
    public ushort DnsInMaxTcp { get => _dnsInMaxTcpValue;
        set { _dnsInMaxTcpChanged = true; _dnsInMaxTcpValue = value; } }
    private ushort _dnsInMaxTcpValue;
    private bool _dnsInMaxTcpChanged;
    public bool ShouldSerializeDNS_In_MaxTCP() { return _dnsInMaxTcpChanged; }

    [JsonProperty("DNS_Out_ViaIPv4")]
    public bool DnsOutViaIPv4 { get => _dnsOutViaIPv4Value;
        set { _dnsOutViaIPv4Changed = true; _dnsOutViaIPv4Value = value; } }
    private bool _dnsOutViaIPv4Value;
    private bool _dnsOutViaIPv4Changed;
    public bool ShouldSerializeDNS_Out_ViaIPv4() { return _dnsOutViaIPv4Changed; }

    [JsonProperty("DNS_Out_ViaIPv6")]
    public bool DnsOutViaIPv6 { get => _dnsOutViaIPv6Value;
        set { _dnsOutViaIPv6Changed = true; _dnsOutViaIPv6Value = value; } }
    private bool _dnsOutViaIPv6Value;
    private bool _dnsOutViaIPv6Changed;
    public bool ShouldSerializeDNS_Out_ViaIPv6() { return _dnsOutViaIPv6Changed; }

    [JsonProperty("DNS_Out_FromIPv4")]
    public IPAddress DnsOutFromIPv4 { get => _dnsOutFromIPv4Value;
        set { _dnsOutFromIPv4Changed = true; _dnsOutFromIPv4Value = value; } }
    private IPAddress _dnsOutFromIPv4Value;
    private bool _dnsOutFromIPv4Changed;
    public bool ShouldSerializeDNS_Out_FromIPv4() { return _dnsOutFromIPv4Changed; }

    [JsonProperty("DNS_Out_FromIPv6")]
    public IPAddress DnsOutFromIPv6 { get => _dnsOutFromIPv6Value;
        set { _dnsOutFromIPv6Changed = true; _dnsOutFromIPv6Value = value; } }
    private IPAddress _dnsOutFromIPv6Value;
    private bool _dnsOutFromIPv6Changed;
    public bool ShouldSerializeDNS_Out_FromIPv6() { return _dnsOutFromIPv6Changed; }

    [JsonProperty("DNS_Out_PortUDPRandom")]
    public bool DnsOutPortUdpRandom { get => _dnsOutPortUdpRandomValue;
        set { _dnsOutPortUdpRandomChanged = true; _dnsOutPortUdpRandomValue = value; } }
    private bool _dnsOutPortUdpRandomValue;
    private bool _dnsOutPortUdpRandomChanged;
    public bool ShouldSerializeDNS_Out_PortUDPRandom() { return _dnsOutPortUdpRandomChanged; }

    [JsonProperty("DNS_Out_PortUDP")]
    public ushort DnsOutPortUdp { get => _dnsOutPortUdpValue;
        set { _dnsOutPortUdpChanged = true; _dnsOutPortUdpValue = value; } }
    private ushort _dnsOutPortUdpValue;
    private bool _dnsOutPortUdpChanged;
    public bool ShouldSerializeDNS_Out_PortUDP() { return _dnsOutPortUdpChanged; }

    [JsonProperty("DNS_Out_EDNS")]
    public bool DnsOutEdns { get => _dnsOutEdnsValue;
        set { _dnsOutEdnsChanged = true; _dnsOutEdnsValue = value; } }
    private bool _dnsOutEdnsValue;
    private bool _dnsOutEdnsChanged;
    public bool ShouldSerializeDNS_Out_EDNS() { return _dnsOutEdnsChanged; }

    [JsonProperty("DNS_Recursion_Allow")]
    public IpAddressMatch DnsRecursionAllow { get => _dnsRecursionAllowValue;
        set { _dnsRecursionAllowChanged = true; _dnsRecursionAllowValue = value; } }
    private IpAddressMatch _dnsRecursionAllowValue;
    private bool _dnsRecursionAllowChanged;
    public bool ShouldSerializeDNS_Recursion_Allow() { return _dnsRecursionAllowChanged | _dnsRecursionAllowValue.Changed; }

    [JsonProperty("DNS_Recursion_MaxParallel")]
    public uint DnsRecursionMaxParallel { get => _dnsRecursionMaxParallelValue;
        set { _dnsRecursionMaxParallelChanged = true; _dnsRecursionMaxParallelValue = value; } }
    private uint _dnsRecursionMaxParallelValue;
    private bool _dnsRecursionMaxParallelChanged;
    public bool ShouldSerializeDNS_Recursion_MaxParallel() { return _dnsRecursionMaxParallelChanged; }

    [JsonProperty("DNS_Recursion_MatchRespIP")]
    public bool DnsRecursionMatchRespIp { get => _dnsRecursionMatchRespIpValue;
        set { _dnsRecursionMatchRespIpChanged = true; _dnsRecursionMatchRespIpValue = value; } }
    private bool _dnsRecursionMatchRespIpValue;
    private bool _dnsRecursionMatchRespIpChanged;
    public bool ShouldSerializeDNS_Recursion_MatchRespIP() { return _dnsRecursionMatchRespIpChanged; }

    [JsonProperty("DNS_Recursion_IgnoreNoQSect")]
    public bool DnsRecursionIgnoreNoQSect { get => _dnsRecursionIgnoreNoQSectValue;
        set { _dnsRecursionIgnoreNoQSectChanged = true; _dnsRecursionIgnoreNoQSectValue = value; } }
    private bool _dnsRecursionIgnoreNoQSectValue;
    private bool _dnsRecursionIgnoreNoQSectChanged;
    public bool ShouldSerializeDNS_Recursion_IgnoreNoQSect() { return _dnsRecursionIgnoreNoQSectChanged; }

    [JsonProperty("DNS_Recursion_DNS0x20")]
    public bool DnsRecursionDns0X20 { get => _dnsRecursionDns0X20Value;
        set { _dnsRecursionDns0X20Changed = true; _dnsRecursionDns0X20Value = value; } }
    private bool _dnsRecursionDns0X20Value;
    private bool _dnsRecursionDns0X20Changed;
    public bool ShouldSerializeDNS_Recursion_DNS0x20() { return _dnsRecursionDns0X20Changed; }

    [JsonProperty("DNS_RespFilter_Enable")]
    public bool DnsRespFilterEnable { get => _dnsRespFilterEnableValue;
        set { _dnsRespFilterEnableChanged = true; _dnsRespFilterEnableValue = value; } }
    private bool _dnsRespFilterEnableValue;
    private bool _dnsRespFilterEnableChanged;
    public bool ShouldSerializeDNS_RespFilter_Enable() { return _dnsRespFilterEnableChanged; }

    [JsonProperty("DNS_RespFilter_Remove")]
    public IpAddressRangeList DnsRespFilterRemove { get => _dnsRespFilterRemoveValue;
        set { _dnsRespFilterRemoveChanged = true; _dnsRespFilterRemoveValue = value; } }
    private IpAddressRangeList _dnsRespFilterRemoveValue;
    private bool _dnsRespFilterRemoveChanged;
    public bool ShouldSerializeDNS_RespFilter_Remove() { return _dnsRespFilterRemoveChanged | _dnsRespFilterRemoveValue.Changed; }

    [JsonProperty("DNS_RespFilter_Trust")]
    public IpAddressRangeList DnsRespFilterTrust { get => _dnsRespFilterTrustValue;
        set { _dnsRespFilterTrustChanged = true; _dnsRespFilterTrustValue = value; } }
    private IpAddressRangeList _dnsRespFilterTrustValue;
    private bool _dnsRespFilterTrustChanged;
    public bool ShouldSerializeDNS_RespFilter_Trust() { return _dnsRespFilterTrustChanged | _dnsRespFilterTrustValue.Changed; }

    [JsonProperty("DNS_Cache_Enable")]
    public bool DnsCacheEnable { get => _dnsCacheEnableValue;
        set { _dnsCacheEnableChanged = true; _dnsCacheEnableValue = value; } }
    private bool _dnsCacheEnableValue;
    private bool _dnsCacheEnableChanged;
    public bool ShouldSerializeDNS_Cache_Enable() { return _dnsCacheEnableChanged; }

    [JsonProperty("DNS_Cache_MaxTTL")]
    public uint DnsCacheMaxTtl { get => _dnsCacheMaxTtlValue;
        set { _dnsCacheMaxTtlChanged = true; _dnsCacheMaxTtlValue = value; } }
    private uint _dnsCacheMaxTtlValue;
    private bool _dnsCacheMaxTtlChanged;
    public bool ShouldSerializeDNS_Cache_MaxTTL() { return _dnsCacheMaxTtlChanged; }

    [JsonProperty("DNS_Cache_MaxNegativeTTL")]
    public uint DnsCacheMaxNegativeTtl { get => _dnsCacheMaxNegativeTtlValue;
        set { _dnsCacheMaxNegativeTtlChanged = true; _dnsCacheMaxNegativeTtlValue = value; } }
    private uint _dnsCacheMaxNegativeTtlValue;
    private bool _dnsCacheMaxNegativeTtlChanged;
    public bool ShouldSerializeDNS_Cache_MaxNegativeTTL() { return _dnsCacheMaxNegativeTtlChanged; }

    [JsonProperty("DNS_Cache_MaxRecords")]
    public uint DnsCacheMaxRecords { get => _dnsCacheMaxRecordsValue;
        set { _dnsCacheMaxRecordsChanged = true; _dnsCacheMaxRecordsValue = value; } }
    private uint _dnsCacheMaxRecordsValue;
    private bool _dnsCacheMaxRecordsChanged;
    public bool ShouldSerializeDNS_Cache_MaxRecords() { return _dnsCacheMaxRecordsChanged; }

    [JsonProperty("DNS_Cache_Reload")]
    public bool DnsCacheReload { get => _dnsCacheReloadValue;
        set { _dnsCacheReloadChanged = true; _dnsCacheReloadValue = value; } }
    private bool _dnsCacheReloadValue;
    private bool _dnsCacheReloadChanged;
    public bool ShouldSerializeDNS_Cache_Reload() { return _dnsCacheReloadChanged; }

    [JsonProperty("DNS_Cache_MinTTL")]
    public uint DnsCacheMinTtl { get => _dnsCacheMinTtlValue;
        set { _dnsCacheMinTtlChanged = true; _dnsCacheMinTtlValue = value; } }
    private uint _dnsCacheMinTtlValue;
    private bool _dnsCacheMinTtlChanged;
    public bool ShouldSerializeDNS_Cache_MinTTL() { return _dnsCacheMinTtlChanged; }

    [JsonProperty("DNS_ZoneTransfer_Keys")]
    public TransferKeyList DnsZoneTransferKeys { get => _dnsZoneTransferKeysValue;
        set { _dnsZoneTransferKeysChanged = true; _dnsZoneTransferKeysValue = value; } }
    private TransferKeyList _dnsZoneTransferKeysValue;
    private bool _dnsZoneTransferKeysChanged;
    public bool ShouldSerializeDNS_ZoneTransfer_Keys() { return _dnsZoneTransferKeysChanged | _dnsZoneTransferKeysValue.Changed; }

    [JsonProperty("DNS_ZoneTransfer_IPs")]
    public IpAddressMatch DnsZoneTransferIPs { get => _dnsZoneTransferIPsValue;
        set { _dnsZoneTransferIPsChanged = true; _dnsZoneTransferIPsValue = value; } }
    private IpAddressMatch _dnsZoneTransferIPsValue;
    private bool _dnsZoneTransferIPsChanged;
    public bool ShouldSerializeDNS_ZoneTransfer_IPs() { return _dnsZoneTransferIPsChanged | _dnsZoneTransferIPsValue.Changed; }

    [JsonProperty("DNS_ZoneTransfer_OneRec")]
    public bool DnsZoneTransferOneRec { get => _dnsZoneTransferOneRecValue;
        set { _dnsZoneTransferOneRecChanged = true; _dnsZoneTransferOneRecValue = value; } }
    private bool _dnsZoneTransferOneRecValue;
    private bool _dnsZoneTransferOneRecChanged;
    public bool ShouldSerializeDNS_ZoneTransfer_OneRec() { return _dnsZoneTransferOneRecChanged; }

    [JsonProperty("DNS_MasterSlave_Slaves")]
    public IpAddressRangeList DnsMasterSlaveSlaves { get => _dnsMasterSlaveSlavesValue;
        set { _dnsMasterSlaveSlavesChanged = true; _dnsMasterSlaveSlavesValue = value; } }
    private IpAddressRangeList _dnsMasterSlaveSlavesValue;
    private bool _dnsMasterSlaveSlavesChanged;
    public bool ShouldSerializeDNS_MasterSlave_Slaves() { return _dnsMasterSlaveSlavesChanged | _dnsMasterSlaveSlavesValue.Changed; }

    [JsonProperty("DNS_MasterSlave_Unsigned")]
    public bool DnsMasterSlaveUnsigned { get => _dnsMasterSlaveUnsignedValue;
        set { _dnsMasterSlaveUnsignedChanged = true; _dnsMasterSlaveUnsignedValue = value; } }
    private bool _dnsMasterSlaveUnsignedValue;
    private bool _dnsMasterSlaveUnsignedChanged;
    public bool ShouldSerializeDNS_MasterSlave_Unsigned() { return _dnsMasterSlaveUnsignedChanged; }

    [JsonProperty("DNS_MasterSlave_Masters")]
    public MasterList DnsMasterSlaveMasters { get => _dnsMasterSlaveMastersValue;
        set { _dnsMasterSlaveMastersChanged = true; _dnsMasterSlaveMastersValue = value; } }
    private MasterList _dnsMasterSlaveMastersValue;
    private bool _dnsMasterSlaveMastersChanged;
    public bool ShouldSerializeDNS_MasterSlave_Masters() { return _dnsMasterSlaveMastersChanged | _dnsMasterSlaveMastersValue.Changed; }

    [JsonProperty("DNS_MasterSlave_VerifyIV")]
    public uint DnsMasterSlaveVerifyIv { get => _dnsMasterSlaveVerifyIvValue;
        set { _dnsMasterSlaveVerifyIvChanged = true; _dnsMasterSlaveVerifyIvValue = value; } }
    private uint _dnsMasterSlaveVerifyIvValue;
    private bool _dnsMasterSlaveVerifyIvChanged;
    public bool ShouldSerializeDNS_MasterSlave_VerifyIV() { return _dnsMasterSlaveVerifyIvChanged; }

    [JsonProperty("DNS_Secondary_RefreshPerSec")]
    public ushort DnsSecondaryRefreshPerSec { get => _dnsSecondaryRefreshPerSecValue;
        set { _dnsSecondaryRefreshPerSecChanged = true; _dnsSecondaryRefreshPerSecValue = value; } }
    private ushort _dnsSecondaryRefreshPerSecValue;
    private bool _dnsSecondaryRefreshPerSecChanged;
    public bool ShouldSerializeDNS_Secondary_RefreshPerSec() { return _dnsSecondaryRefreshPerSecChanged; }

    [JsonProperty("DNS_Secondary_MaxParallel")]
    public byte DnsSecondaryMaxParallel { get => _dnsSecondaryMaxParallelValue;
        set { _dnsSecondaryMaxParallelChanged = true; _dnsSecondaryMaxParallelValue = value; } }
    private byte _dnsSecondaryMaxParallelValue;
    private bool _dnsSecondaryMaxParallelChanged;
    public bool ShouldSerializeDNS_Secondary_MaxParallel() { return _dnsSecondaryMaxParallelChanged; }

    [JsonProperty("DNS_Secondary_ExpiredRetry")]
    public uint DnsSecondaryExpiredRetry { get => _dnsSecondaryExpiredRetryValue;
        set { _dnsSecondaryExpiredRetryChanged = true; _dnsSecondaryExpiredRetryValue = value; } }
    private uint _dnsSecondaryExpiredRetryValue;
    private bool _dnsSecondaryExpiredRetryChanged;
    public bool ShouldSerializeDNS_Secondary_ExpiredRetry() { return _dnsSecondaryExpiredRetryChanged; }

    [JsonProperty("DNS_Secondary_UseIXFR")]
    public bool DnsSecondaryUseIxfr { get => _dnsSecondaryUseIxfrValue;
        set { _dnsSecondaryUseIxfrChanged = true; _dnsSecondaryUseIxfrValue = value; } }
    private bool _dnsSecondaryUseIxfrValue;
    private bool _dnsSecondaryUseIxfrChanged;
    public bool ShouldSerializeDNS_Secondary_UseIXFR() { return _dnsSecondaryUseIxfrChanged; }

    [JsonProperty("DNS_Secondary_OnlyPrimIPNotify")]
    public bool DnsSecondaryOnlyPrimIpNotify { get => _dnsSecondaryOnlyPrimIpNotifyValue;
        set { _dnsSecondaryOnlyPrimIpNotifyChanged = true; _dnsSecondaryOnlyPrimIpNotifyValue = value; } }
    private bool _dnsSecondaryOnlyPrimIpNotifyValue;
    private bool _dnsSecondaryOnlyPrimIpNotifyChanged;
    public bool ShouldSerializeDNS_Secondary_OnlyPrimIPNotify() { return _dnsSecondaryOnlyPrimIpNotifyChanged; }

    [JsonProperty("DNS_Secondary_MinSOARefresh")]
    public uint DnsSecondaryMinSoaRefresh { get => _dnsSecondaryMinSoaRefreshValue;
        set { _dnsSecondaryMinSoaRefreshChanged = true; _dnsSecondaryMinSoaRefreshValue = value; } }
    private uint _dnsSecondaryMinSoaRefreshValue;
    private bool _dnsSecondaryMinSoaRefreshChanged;
    public bool ShouldSerializeDNS_Secondary_MinSOARefresh() { return _dnsSecondaryMinSoaRefreshChanged; }

    [JsonProperty("DNS_Secondary_MinSOARetry")]
    public uint DnsSecondaryMinSoaRetry { get => _dnsSecondaryMinSoaRetryValue;
        set { _dnsSecondaryMinSoaRetryChanged = true; _dnsSecondaryMinSoaRetryValue = value; } }
    private uint _dnsSecondaryMinSoaRetryValue;
    private bool _dnsSecondaryMinSoaRetryChanged;
    public bool ShouldSerializeDNS_Secondary_MinSOARetry() { return _dnsSecondaryMinSoaRetryChanged; }

    [JsonProperty("DNS_Secondary_MinSOAExpire")]
    public uint DnsSecondaryMinSoaExpire { get => _dnsSecondaryMinSoaExpireValue;
        set { _dnsSecondaryMinSoaExpireChanged = true; _dnsSecondaryMinSoaExpireValue = value; } }
    private uint _dnsSecondaryMinSoaExpireValue;
    private bool _dnsSecondaryMinSoaExpireChanged;
    public bool ShouldSerializeDNS_Secondary_MinSOAExpire() { return _dnsSecondaryMinSoaExpireChanged; }

    [JsonProperty("DNS_SuspZone_Action")]
    public string DnsSuspZoneAction { get => _dnsSuspZoneActionValue;
        set { _dnsSuspZoneActionChanged = true; _dnsSuspZoneActionValue = value; } }
    private string _dnsSuspZoneActionValue;
    private bool _dnsSuspZoneActionChanged;
    public bool ShouldSerializeDNS_SuspZone_Action() { return _dnsSuspZoneActionChanged; }

    [JsonProperty("DNS_SuspZone_SynthA")]
    public string DnsSuspZoneSynthA { get => _dnsSuspZoneSynthAValue;
        set { _dnsSuspZoneSynthAChanged = true; _dnsSuspZoneSynthAValue = value; } }
    private string _dnsSuspZoneSynthAValue;
    private bool _dnsSuspZoneSynthAChanged;
    public bool ShouldSerializeDNS_SuspZone_SynthA() { return _dnsSuspZoneSynthAChanged; }

    [JsonProperty("DNS_SuspZone_SynthAAAA")]
    public string DnsSuspZoneSynthAaaa { get => _dnsSuspZoneSynthAaaaValue;
        set { _dnsSuspZoneSynthAaaaChanged = true; _dnsSuspZoneSynthAaaaValue = value; } }
    private string _dnsSuspZoneSynthAaaaValue;
    private bool _dnsSuspZoneSynthAaaaChanged;
    public bool ShouldSerializeDNS_SuspZone_SynthAAAA() { return _dnsSuspZoneSynthAaaaChanged; }

    [JsonProperty("DNS_SuspZone_SynthMX")]
    public string DnsSuspZoneSynthMx { get => _dnsSuspZoneSynthMxValue;
        set { _dnsSuspZoneSynthMxChanged = true; _dnsSuspZoneSynthMxValue = value; } }
    private string _dnsSuspZoneSynthMxValue;
    private bool _dnsSuspZoneSynthMxChanged;
    public bool ShouldSerializeDNS_SuspZone_SynthMX() { return _dnsSuspZoneSynthMxChanged; }

    [JsonProperty("DNS_AutoSPF_Enable")]
    public bool DnsAutoSpfEnable { get => _dnsAutoSpfEnableValue;
        set { _dnsAutoSpfEnableChanged = true; _dnsAutoSpfEnableValue = value; } }
    private bool _dnsAutoSpfEnableValue;
    private bool _dnsAutoSpfEnableChanged;
    public bool ShouldSerializeDNS_AutoSPF_Enable() { return _dnsAutoSpfEnableChanged; }

    [JsonProperty("DNS_AutoSPF_Data")]
    public string DnsAutoSpfData { get => _dnsAutoSpfDataValue;
        set { _dnsAutoSpfDataChanged = true; _dnsAutoSpfDataValue = value; } }
    private string _dnsAutoSpfDataValue;
    private bool _dnsAutoSpfDataChanged;
    public bool ShouldSerializeDNS_AutoSPF_Data() { return _dnsAutoSpfDataChanged; }

    [JsonProperty("DNS_AutoSPF_TTL")]
    public uint DnsAutoSpfTtl { get => _dnsAutoSpfTtlValue;
        set { _dnsAutoSpfTtlChanged = true; _dnsAutoSpfTtlValue = value; } }
    private uint _dnsAutoSpfTtlValue;
    private bool _dnsAutoSpfTtlChanged;
    public bool ShouldSerializeDNS_AutoSPF_TTL() { return _dnsAutoSpfTtlChanged; }

    [JsonProperty("DNS_TSIGUpdate_Keys")]
    public UpdateKeyList DnsTsigUpdateKeys { get => _dnsTsigUpdateKeysValue;
        set { _dnsTsigUpdateKeysChanged = true; _dnsTsigUpdateKeysValue = value; } }
    private UpdateKeyList _dnsTsigUpdateKeysValue;
    private bool _dnsTsigUpdateKeysChanged;
    public bool ShouldSerializeDNS_TSIGUpdate_Keys() { return _dnsTsigUpdateKeysChanged | _dnsTsigUpdateKeysValue.Changed; }

    [JsonProperty("DNS_ZoneVersions")]
    public ushort DnsZoneVersions { get => _dnsZoneVersionsValue;
        set { _dnsZoneVersionsChanged = true; _dnsZoneVersionsValue = value; } }
    private ushort _dnsZoneVersionsValue;
    private bool _dnsZoneVersionsChanged;
    public bool ShouldSerializeDNS_ZoneVersions() { return _dnsZoneVersionsChanged; }

    [JsonProperty("DNS_Forward")]
    public ForwardList DnsForward { get => _dnsForwardValue;
        set { _dnsForwardChanged = true; _dnsForwardValue = value; } }
    private ForwardList _dnsForwardValue;
    private bool _dnsForwardChanged;
    public bool ShouldSerializeDNS_Forward() { return _dnsForwardChanged | _dnsForwardValue.Changed; }

    [JsonProperty("DNS_Lame_Action")]
    public DnsLameAction DnsLameAction { get => _dnsLameActionValue;
        set { _dnsLameActionChanged = true; _dnsLameActionValue = value; } }
    private DnsLameAction _dnsLameActionValue;
    private bool _dnsLameActionChanged;
    public bool ShouldSerializeDNS_Lame_Action() { return _dnsLameActionChanged; }

    [JsonProperty("DNS_Lame_SynthA")]
    public IPAddress DnsLameSynthA { get => _dnsLameSynthAValue;
        set { _dnsLameSynthAChanged = true; _dnsLameSynthAValue = value; } }
    private IPAddress _dnsLameSynthAValue;
    private bool _dnsLameSynthAChanged;
    public bool ShouldSerializeDNS_Lame_SynthA() { return _dnsLameSynthAChanged; }

    [JsonProperty("DNS_Lame_SynthAAAA")]
    public IPAddress DnsLameSynthAaaa { get => _dnsLameSynthAaaaValue;
        set { _dnsLameSynthAaaaChanged = true; _dnsLameSynthAaaaValue = value; } }
    private IPAddress _dnsLameSynthAaaaValue;
    private bool _dnsLameSynthAaaaChanged;
    public bool ShouldSerializeDNS_Lame_SynthAAAA() { return _dnsLameSynthAaaaChanged; }

    [JsonProperty("DNS_Lame_SynthMX")]
    public string DnsLameSynthMx { get => _dnsLameSynthMxValue;
        set { _dnsLameSynthMxChanged = true; _dnsLameSynthMxValue = value; } }
    private string _dnsLameSynthMxValue;
    private bool _dnsLameSynthMxChanged;
    public bool ShouldSerializeDNS_Lame_SynthMX() { return _dnsLameSynthMxChanged; }

    [JsonProperty("DNS_NXDomain_Enable")]
    public bool DnsNxDomainEnable { get => _dnsNxDomainEnableValue;
        set { _dnsNxDomainEnableChanged = true; _dnsNxDomainEnableValue = value; } }
    private bool _dnsNxDomainEnableValue;
    private bool _dnsNxDomainEnableChanged;
    public bool ShouldSerializeDNS_NXDomain_Enable() { return _dnsNxDomainEnableChanged; }

    [JsonProperty("DNS_NXDomain_IPv4")]
    public IPAddress DnsNxDomainIPv4 { get => _dnsNxDomainIPv4Value;
        set { _dnsNxDomainIPv4Changed = true; _dnsNxDomainIPv4Value = value; } }
    private IPAddress _dnsNxDomainIPv4Value;
    private bool _dnsNxDomainIPv4Changed;
    public bool ShouldSerializeDNS_NXDomain_IPv4() { return _dnsNxDomainIPv4Changed; }

    [JsonProperty("DNS_NXDomain_IPv6")]
    public IPAddress DnsNxDomainIPv6 { get => _dnsNxDomainIPv6Value;
        set { _dnsNxDomainIPv6Changed = true; _dnsNxDomainIPv6Value = value; } }
    private IPAddress _dnsNxDomainIPv6Value;
    private bool _dnsNxDomainIPv6Changed;
    public bool ShouldSerializeDNS_NXDomain_IPv6() { return _dnsNxDomainIPv6Changed; }

    [JsonProperty("DNS_NXDomain_OnlyWWW")]
    public bool DnsNxDomainOnlyWww { get => _dnsNxDomainOnlyWwwValue;
        set { _dnsNxDomainOnlyWwwChanged = true; _dnsNxDomainOnlyWwwValue = value; } }
    private bool _dnsNxDomainOnlyWwwValue;
    private bool _dnsNxDomainOnlyWwwChanged;
    public bool ShouldSerializeDNS_NXDomain_OnlyWWW() { return _dnsNxDomainOnlyWwwChanged; }

    [JsonProperty("DNS_NXDomain_ExceptAA")]
    public bool DnsNxDomainExceptAa { get => _dnsNxDomainExceptAaValue;
        set { _dnsNxDomainExceptAaChanged = true; _dnsNxDomainExceptAaValue = value; } }
    private bool _dnsNxDomainExceptAaValue;
    private bool _dnsNxDomainExceptAaChanged;
    public bool ShouldSerializeDNS_NXDomain_ExceptAA() { return _dnsNxDomainExceptAaChanged; }

    [JsonProperty("DNS_NXDomain_ExceptDNSBL")]
    public bool DnsNxDomainExceptDnsbl { get => _dnsNxDomainExceptDnsblValue;
        set { _dnsNxDomainExceptDnsblChanged = true; _dnsNxDomainExceptDnsblValue = value; } }
    private bool _dnsNxDomainExceptDnsblValue;
    private bool _dnsNxDomainExceptDnsblChanged;
    public bool ShouldSerializeDNS_NXDomain_ExceptDNSBL() { return _dnsNxDomainExceptDnsblChanged; }

    [JsonProperty("DNS_NXDomain_ExceptDomains")]
    public StringList DnsNxDomainExceptDomains { get => _dnsNxDomainExceptDomainsValue;
        set { _dnsNxDomainExceptDomainsChanged = true; _dnsNxDomainExceptDomainsValue = value; } }
    private StringList _dnsNxDomainExceptDomainsValue;
    private bool _dnsNxDomainExceptDomainsChanged;
    public bool ShouldSerializeDNS_NXDomain_ExceptDomains() { return _dnsNxDomainExceptDomainsChanged | _dnsNxDomainExceptDomainsValue.Changed; }

    [JsonProperty("DNS_NXDomain_ExceptIPs")]
    public IpAddressRangeList DnsNxDomainExceptIPs { get => _dnsNxDomainExceptIPsValue;
        set { _dnsNxDomainExceptIPsChanged = true; _dnsNxDomainExceptIPsValue = value; } }
    private IpAddressRangeList _dnsNxDomainExceptIPsValue;
    private bool _dnsNxDomainExceptIPsChanged;
    public bool ShouldSerializeDNS_NXDomain_ExceptIPs() { return _dnsNxDomainExceptIPsChanged | _dnsNxDomainExceptIPsValue.Changed; }

    [JsonProperty("DNS_NATIPAlias_Enable")]
    public bool DnsNatipAliasEnable { get => _dnsNatipAliasEnableValue;
        set { _dnsNatipAliasEnableChanged = true; _dnsNatipAliasEnableValue = value; } }
    private bool _dnsNatipAliasEnableValue;
    private bool _dnsNatipAliasEnableChanged;
    public bool ShouldSerializeDNS_NATIPAlias_Enable() { return _dnsNatipAliasEnableChanged; }

    [JsonProperty("DNS_NATIPAlias_Aliases")]
    public IpAliasList DnsNatipAliasAliases { get => _dnsNatipAliasAliasesValue;
        set { _dnsNatipAliasAliasesChanged = true; _dnsNatipAliasAliasesValue = value; } }
    private IpAliasList _dnsNatipAliasAliasesValue;
    private bool _dnsNatipAliasAliasesChanged;
    public bool ShouldSerializeDNS_NATIPAlias_Aliases() { return _dnsNatipAliasAliasesChanged | _dnsNatipAliasAliasesValue.Changed; }

    [JsonProperty("DNS_NATIPAlias_LANIPs")]
    public IpAddressRangeList DnsNatipAliasLaniPs { get => _dnsNatipAliasLaniPsValue;
        set { _dnsNatipAliasLaniPsChanged = true; _dnsNatipAliasLaniPsValue = value; } }
    private IpAddressRangeList _dnsNatipAliasLaniPsValue;
    private bool _dnsNatipAliasLaniPsChanged;
    public bool ShouldSerializeDNS_NATIPAlias_LANIPs() { return _dnsNatipAliasLaniPsChanged | _dnsNatipAliasLaniPsValue.Changed; }

    [JsonProperty("DNS_NATIPAlias_SelfOnLAN")]
    public bool DnsNatipAliasSelfOnLan { get => _dnsNatipAliasSelfOnLanValue;
        set { _dnsNatipAliasSelfOnLanChanged = true; _dnsNatipAliasSelfOnLanValue = value; } }
    private bool _dnsNatipAliasSelfOnLanValue;
    private bool _dnsNatipAliasSelfOnLanChanged;
    public bool ShouldSerializeDNS_NATIPAlias_SelfOnLAN() { return _dnsNatipAliasSelfOnLanChanged; }

    [JsonProperty("DNS_Misc_RoundRobin")]
    public bool DnsMiscRoundRobin { get => _dnsMiscRoundRobinValue;
        set { _dnsMiscRoundRobinChanged = true; _dnsMiscRoundRobinValue = value; } }
    private bool _dnsMiscRoundRobinValue;
    private bool _dnsMiscRoundRobinChanged;
    public bool ShouldSerializeDNS_Misc_RoundRobin() { return _dnsMiscRoundRobinChanged; }

    [JsonProperty("DNS_Misc_SendNotify")]
    public bool DnsMiscSendNotify { get => _dnsMiscSendNotifyValue;
        set { _dnsMiscSendNotifyChanged = true; _dnsMiscSendNotifyValue = value; } }
    private bool _dnsMiscSendNotifyValue;
    private bool _dnsMiscSendNotifyChanged;
    public bool ShouldSerializeDNS_Misc_SendNotify() { return _dnsMiscSendNotifyChanged; }

    [JsonProperty("DNS_Misc_AutoUpdateRoot")]
    public bool DnsMiscAutoUpdateRoot { get => _dnsMiscAutoUpdateRootValue;
        set { _dnsMiscAutoUpdateRootChanged = true; _dnsMiscAutoUpdateRootValue = value; } }
    private bool _dnsMiscAutoUpdateRootValue;
    private bool _dnsMiscAutoUpdateRootChanged;
    public bool ShouldSerializeDNS_Misc_AutoUpdateRoot() { return _dnsMiscAutoUpdateRootChanged; }

    [JsonProperty("DNS_Misc_StandardEmptyZones")]
    public bool DnsMiscStandardEmptyZones { get => _dnsMiscStandardEmptyZonesValue;
        set { _dnsMiscStandardEmptyZonesChanged = true; _dnsMiscStandardEmptyZonesValue = value; } }
    private bool _dnsMiscStandardEmptyZonesValue;
    private bool _dnsMiscStandardEmptyZonesChanged;
    public bool ShouldSerializeDNS_Misc_StandardEmptyZones() { return _dnsMiscStandardEmptyZonesChanged; }

    [JsonProperty("DNS_Misc_EDNSPayLoad")]
    public ushort DnsMiscEdnsPayLoad { get => _dnsMiscEdnsPayLoadValue;
        set { _dnsMiscEdnsPayLoadChanged = true; _dnsMiscEdnsPayLoadValue = value; } }
    private ushort _dnsMiscEdnsPayLoadValue;
    private bool _dnsMiscEdnsPayLoadChanged;
    public bool ShouldSerializeDNS_Misc_EDNSPayLoad() { return _dnsMiscEdnsPayLoadChanged; }

    [JsonProperty("DNS_Misc_BINDVer")]
    public bool DnsMiscBindVer { get => _dnsMiscBindVerValue;
        set { _dnsMiscBindVerChanged = true; _dnsMiscBindVerValue = value; } }
    private bool _dnsMiscBindVerValue;
    private bool _dnsMiscBindVerChanged;
    public bool ShouldSerializeDNS_Misc_BINDVer() { return _dnsMiscBindVerChanged; }

    [JsonProperty("DNS_Misc_BINDVerTXT")]
    public string DnsMiscBindVerTxt { get => _dnsMiscBindVerTxtValue;
        set { _dnsMiscBindVerTxtChanged = true; _dnsMiscBindVerTxtValue = value; } }
    private string _dnsMiscBindVerTxtValue;
    private bool _dnsMiscBindVerTxtChanged;
    public bool ShouldSerializeDNS_Misc_BINDVerTXT() { return _dnsMiscBindVerTxtChanged; }

    [JsonProperty("DNS_Misc_LCC")]
    public bool DnsMiscLcc { get => _dnsMiscLccValue;
        set { _dnsMiscLccChanged = true; _dnsMiscLccValue = value; } }
    private bool _dnsMiscLccValue;
    private bool _dnsMiscLccChanged;
    public bool ShouldSerializeDNS_Misc_LCC() { return _dnsMiscLccChanged; }

    [JsonProperty("DNS_Misc_LCCMax")]
    public uint DnsMiscLccMax { get => _dnsMiscLccMaxValue;
        set { _dnsMiscLccMaxChanged = true; _dnsMiscLccMaxValue = value; } }
    private uint _dnsMiscLccMaxValue;
    private bool _dnsMiscLccMaxChanged;
    public bool ShouldSerializeDNS_Misc_LCCMax() { return _dnsMiscLccMaxChanged; }

    [JsonProperty("DNS_Misc_UdpRootProc")]
    public UdpProcessingMode DnsMiscUdpRootProc { get => _dnsMiscUdpRootProcValue;
        set { _dnsMiscUdpRootProcChanged = true; _dnsMiscUdpRootProcValue = value; } }
    private UdpProcessingMode _dnsMiscUdpRootProcValue;
    private bool _dnsMiscUdpRootProcChanged;
    public bool ShouldSerializeDNS_Misc_UdpRootProc() { return _dnsMiscUdpRootProcChanged; }

    [JsonProperty("DNS_Misc_UdpRootLog")]
    public bool DnsMiscUdpRootLog { get => _dnsMiscUdpRootLogValue;
        set { _dnsMiscUdpRootLogChanged = true; _dnsMiscUdpRootLogValue = value; } }
    private bool _dnsMiscUdpRootLogValue;
    private bool _dnsMiscUdpRootLogChanged;
    public bool ShouldSerializeDNS_Misc_UdpRootLog() { return _dnsMiscUdpRootLogChanged; }

    [JsonProperty("DNS_Misc_UdpAnyProc")]
    public UdpProcessingMode DnsMiscUdpAnyProc { get => _dnsMiscUdpAnyProcValue;
        set { _dnsMiscUdpAnyProcChanged = true; _dnsMiscUdpAnyProcValue = value; } }
    private UdpProcessingMode _dnsMiscUdpAnyProcValue;
    private bool _dnsMiscUdpAnyProcChanged;
    public bool ShouldSerializeDNS_Misc_UdpAnyProc() { return _dnsMiscUdpAnyProcChanged; }

    [JsonProperty("DNS_Misc_UdpAnyLog")]
    public bool DnsMiscUdpAnyLog { get => _dnsMiscUdpAnyLogValue;
        set { _dnsMiscUdpAnyLogChanged = true; _dnsMiscUdpAnyLogValue = value; } }
    private bool _dnsMiscUdpAnyLogValue;
    private bool _dnsMiscUdpAnyLogChanged;
    public bool ShouldSerializeDNS_Misc_UdpAnyLog() { return _dnsMiscUdpAnyLogChanged; }

    [JsonProperty("HTTPAPI_Enable")]
    public bool HttpapiEnable { get => _httpapiEnableValue;
        set { _httpapiEnableChanged = true; _httpapiEnableValue = value; } }
    private bool _httpapiEnableValue;
    private bool _httpapiEnableChanged;
    public bool ShouldSerializeHTTPAPI_Enable() { return _httpapiEnableChanged; }

    [JsonProperty("HTTPAPI_Prefix")]
    public string HttpapiPrefix { get => _httpapiPrefixValue;
        set { _httpapiPrefixChanged = true; _httpapiPrefixValue = value; } }
    private string _httpapiPrefixValue;
    private bool _httpapiPrefixChanged;
    public bool ShouldSerializeHTTPAPI_Prefix() { return _httpapiPrefixChanged; }

    [JsonProperty("HTTPAPI_Auth")]
    public AuthenticationMode HttpapiAuth { get => _httpapiAuthValue;
        set { _httpapiAuthChanged = true; _httpapiAuthValue = value; } }
    private AuthenticationMode _httpapiAuthValue;
    private bool _httpapiAuthChanged;
    public bool ShouldSerializeHTTPAPI_Auth() { return _httpapiAuthChanged; }

    [JsonProperty("HTTPAPI_WinUser")]
    public bool HttpapiWinUser { get => _httpapiWinUserValue;
        set { _httpapiWinUserChanged = true; _httpapiWinUserValue = value; } }
    private bool _httpapiWinUserValue;
    private bool _httpapiWinUserChanged;
    public bool ShouldSerializeHTTPAPI_WinUser() { return _httpapiWinUserChanged; }

    [JsonProperty("HTTPAPI_UserID")]
    public string HttpapiUserId { get => _httpapiUserIdValue;
        set { _httpapiUserIdChanged = true; _httpapiUserIdValue = value; } }
    private string _httpapiUserIdValue;
    private bool _httpapiUserIdChanged;
    public bool ShouldSerializeHTTPAPI_UserID() { return _httpapiUserIdChanged; }

    [JsonProperty("HTTPAPI_Password")]
    public string HttpapiPassword { get => _httpapiPasswordValue;
        set { _httpapiPasswordChanged = true; _httpapiPasswordValue = value; } }
    private string _httpapiPasswordValue;
    private bool _httpapiPasswordChanged;
    public bool ShouldSerializeHTTPAPI_Password() { return _httpapiPasswordChanged; }

    [JsonProperty("HTTPAPI_CorsEnable")]
    public bool HttpapiCorsEnable { get => _httpapiCorsEnableValue;
        set { _httpapiCorsEnableChanged = true; _httpapiCorsEnableValue = value; } }
    private bool _httpapiCorsEnableValue;
    private bool _httpapiCorsEnableChanged;
    public bool ShouldSerializeHTTPAPI_CorsEnable() { return _httpapiCorsEnableChanged; }

    [JsonProperty("HTTPAPI_CorsOrigins")]
    public StringList HttpapiCorsOrigins { get => _httpapiCorsOriginsValue;
        set { _httpapiCorsOriginsChanged = true; _httpapiCorsOriginsValue = value; } }
    private StringList _httpapiCorsOriginsValue;
    private bool _httpapiCorsOriginsChanged;
    public bool ShouldSerializeHTTPAPI_CorsOrigins() { return _httpapiCorsOriginsChanged | _httpapiCorsOriginsValue.Changed; }

    [JsonProperty("HTTPAPI_EnableV1")]
    public bool HttpapiEnableV1 { get => _httpapiEnableV1Value;
        set { _httpapiEnableV1Changed = true; _httpapiEnableV1Value = value; } }
    private bool _httpapiEnableV1Value;
    private bool _httpapiEnableV1Changed;
    public bool ShouldSerializeHTTPAPI_EnableV1() { return _httpapiEnableV1Changed; }

    [JsonProperty("Log_Details_Records")]
    public bool LogDetailsRecords { get => _logDetailsRecordsValue;
        set { _logDetailsRecordsChanged = true; _logDetailsRecordsValue = value; } }
    private bool _logDetailsRecordsValue;
    private bool _logDetailsRecordsChanged;
    public bool ShouldSerializeLog_Details_Records() { return _logDetailsRecordsChanged; }

    [JsonProperty("Log_Details_EDNS0")]
    public bool LogDetailsEdns0 { get => _logDetailsEdns0Value;
        set { _logDetailsEdns0Changed = true; _logDetailsEdns0Value = value; } }
    private bool _logDetailsEdns0Value;
    private bool _logDetailsEdns0Changed;
    public bool ShouldSerializeLog_Details_EDNS0() { return _logDetailsEdns0Changed; }

    [JsonProperty("Log_Details_Outgoing")]
    public bool LogDetailsOutgoing { get => _logDetailsOutgoingValue;
        set { _logDetailsOutgoingChanged = true; _logDetailsOutgoingValue = value; } }
    private bool _logDetailsOutgoingValue;
    private bool _logDetailsOutgoingChanged;
    public bool ShouldSerializeLog_Details_Outgoing() { return _logDetailsOutgoingChanged; }

    [JsonProperty("Log_Details_Blocked")]
    public bool LogDetailsBlocked { get => _logDetailsBlockedValue;
        set { _logDetailsBlockedChanged = true; _logDetailsBlockedValue = value; } }
    private bool _logDetailsBlockedValue;
    private bool _logDetailsBlockedChanged;
    public bool ShouldSerializeLog_Details_Blocked() { return _logDetailsBlockedChanged; }

    [JsonProperty("Log_Details_OnlyErrors")]
    public bool LogDetailsOnlyErrors { get => _logDetailsOnlyErrorsValue;
        set { _logDetailsOnlyErrorsChanged = true; _logDetailsOnlyErrorsValue = value; } }
    private bool _logDetailsOnlyErrorsValue;
    private bool _logDetailsOnlyErrorsChanged;
    public bool ShouldSerializeLog_Details_OnlyErrors() { return _logDetailsOnlyErrorsChanged; }

    [JsonProperty("Log_Details_IDNNative")]
    public bool LogDetailsIdnNative { get => _logDetailsIdnNativeValue;
        set { _logDetailsIdnNativeChanged = true; _logDetailsIdnNativeValue = value; } }
    private bool _logDetailsIdnNativeValue;
    private bool _logDetailsIdnNativeChanged;
    public bool ShouldSerializeLog_Details_IDNNative() { return _logDetailsIdnNativeChanged; }

    [JsonProperty("Log_Files_Begin")]
    public string LogFilesBegin { get => _logFilesBeginValue;
        set { _logFilesBeginChanged = true; _logFilesBeginValue = value; } }
    private string _logFilesBeginValue;
    private bool _logFilesBeginChanged;
    public bool ShouldSerializeLog_Files_Begin() { return _logFilesBeginChanged; }

    [JsonProperty("Log_Files_Recycle")]
    public string LogFilesRecycle { get => _logFilesRecycleValue;
        set { _logFilesRecycleChanged = true; _logFilesRecycleValue = value; } }
    private string _logFilesRecycleValue;
    private bool _logFilesRecycleChanged;
    public bool ShouldSerializeLog_Files_Recycle() { return _logFilesRecycleChanged; }

    [JsonProperty("Log_Files_Raw")]
    public bool LogFilesRaw { get => _logFilesRawValue;
        set { _logFilesRawChanged = true; _logFilesRawValue = value; } }
    private bool _logFilesRawValue;
    private bool _logFilesRawChanged;
    public bool ShouldSerializeLog_Files_Raw() { return _logFilesRawChanged; }

    [JsonProperty("Log_Files_HttpFullReq")]
    public bool LogFilesHttpFullReq { get => _logFilesHttpFullReqValue;
        set { _logFilesHttpFullReqChanged = true; _logFilesHttpFullReqValue = value; } }
    private bool _logFilesHttpFullReqValue;
    private bool _logFilesHttpFullReqChanged;
    public bool ShouldSerializeLog_Files_HttpFullReq() { return _logFilesHttpFullReqChanged; }

    [JsonProperty("Log_Files_Path")]
    public string LogFilesPath { get => _logFilesPathValue;
        set { _logFilesPathChanged = true; _logFilesPathValue = value; } }
    private string _logFilesPathValue;
    private bool _logFilesPathChanged;
    public bool ShouldSerializeLog_Files_Path() { return _logFilesPathChanged; }

    [JsonProperty("Log_Syslog_Enable")]
    public bool LogSyslogEnable { get => _logSyslogEnableValue;
        set { _logSyslogEnableChanged = true; _logSyslogEnableValue = value; } }
    private bool _logSyslogEnableValue;
    private bool _logSyslogEnableChanged;
    public bool ShouldSerializeLog_Syslog_Enable() { return _logSyslogEnableChanged; }

    [JsonProperty("Log_Syslog_IP")]
    public IPAddress LogSyslogIp { get => _logSyslogIpValue;
        set { _logSyslogIpChanged = true; _logSyslogIpValue = value; } }
    private IPAddress _logSyslogIpValue;
    private bool _logSyslogIpChanged;
    public bool ShouldSerializeLog_Syslog_IP() { return _logSyslogIpChanged; }

    [JsonProperty("Log_Syslog_Port")]
    public ushort LogSyslogPort { get => _logSyslogPortValue;
        set { _logSyslogPortChanged = true; _logSyslogPortValue = value; } }
    private ushort _logSyslogPortValue;
    private bool _logSyslogPortChanged;
    public bool ShouldSerializeLog_Syslog_Port() { return _logSyslogPortChanged; }

    [JsonProperty("Log_ActiveLog_Lines")]
    public ushort LogActiveLogLines { get => _logActiveLogLinesValue;
        set { _logActiveLogLinesChanged = true; _logActiveLogLinesValue = value; } }
    private ushort _logActiveLogLinesValue;
    private bool _logActiveLogLinesChanged;
    public bool ShouldSerializeLog_ActiveLog_Lines() { return _logActiveLogLinesChanged; }

    [JsonProperty("Log_ActiveLog_Buffer")]
    public bool LogActiveLogBuffer { get => _logActiveLogBufferValue;
        set { _logActiveLogBufferChanged = true; _logActiveLogBufferValue = value; } }
    private bool _logActiveLogBufferValue;
    private bool _logActiveLogBufferChanged;
    public bool ShouldSerializeLog_ActiveLog_Buffer() { return _logActiveLogBufferChanged; }

    [JsonProperty("Log_WinEvents_Enable")]
    public bool LogWinEventsEnable { get => _logWinEventsEnableValue;
        set { _logWinEventsEnableChanged = true; _logWinEventsEnableValue = value; } }
    private bool _logWinEventsEnableValue;
    private bool _logWinEventsEnableChanged;
    public bool ShouldSerializeLog_WinEvents_Enable() { return _logWinEventsEnableChanged; }

    [JsonProperty("Log_WinEvents_Exclude")]
    public WindowsEventsList LogWinEventsExclude { get => _logWinEventsExcludeValue;
        set { _logWinEventsExcludeChanged = true; _logWinEventsExcludeValue = value; } }
    private WindowsEventsList _logWinEventsExcludeValue;
    private bool _logWinEventsExcludeChanged;
    public bool ShouldSerializeLog_WinEvents_Exclude() { return _logWinEventsExcludeChanged | _logWinEventsExcludeValue.Changed; }

    [JsonProperty("Remote_Enable")]
    public bool RemoteEnable { get => _remoteEnableValue;
        set { _remoteEnableChanged = true; _remoteEnableValue = value; } }
    private bool _remoteEnableValue;
    private bool _remoteEnableChanged;
    public bool ShouldSerializeRemote_Enable() { return _remoteEnableChanged; }

    [JsonProperty("Remote_Port")]
    public ushort RemotePort { get => _remotePortValue;
        set { _remotePortChanged = true; _remotePortValue = value; } }
    private ushort _remotePortValue;
    private bool _remotePortChanged;
    public bool ShouldSerializeRemote_Port() { return _remotePortChanged; }

    [JsonProperty("Remote_Password")]
    public string RemotePassword { get => _remotePasswordValue;
        set { _remotePasswordChanged = true; _remotePasswordValue = value; } }
    private string _remotePasswordValue;
    private bool _remotePasswordChanged;
    public bool ShouldSerializeRemote_Password() { return _remotePasswordChanged; }
}