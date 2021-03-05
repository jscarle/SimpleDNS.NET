using System.Net;
using Newtonsoft.Json;
using SimpleDNS.Common;

namespace SimpleDNS.Options
{
    // https://simpledns.com/swagger-ui/
    public class OptionsInfo : ICommittable
    {
        public OptionsInfo()
        {
            DNS_In_IPs_value = new IPAddressList();
            DNS_Recursion_Allow_value = new IPAddressMatch();
            DNS_RespFilter_Remove_value = new IPAddressRangeList();
            DNS_RespFilter_Trust_value = new IPAddressRangeList();
            DNS_ZoneTransfer_Keys_value = new TransferKeyList();
            DNS_ZoneTransfer_IPs_value = new IPAddressMatch();
            DNS_MasterSlave_Slaves_value = new IPAddressRangeList();
            DNS_MasterSlave_Masters_value = new MasterList();
            DNS_TSIGUpdate_Keys_value = new UpdateKeyList();
            DNS_Forward_value = new ForwardList();
            DNS_NXDomain_ExceptDomains_value = new StringList();
            DNS_NXDomain_ExceptIPs_value = new IPAddressRangeList();
            DNS_NATIPAlias_Aliases_value = new IPAliasList();
            DNS_NATIPAlias_LANIPs_value = new IPAddressRangeList();
            HTTPAPI_CorsOrigins_value = new StringList();
            Log_WinEvents_Exclude_value = new WindowsEventsList();
        }

        [JsonIgnore]
        public bool Changed
        {
            get
            {
                return (changed |
                General_Name_changed |
                General_TrayBar_changed |
                DNS_In_ListenAll_changed |
                DNS_In_IPs_changed |
                DNS_In_Port_changed |
                DNS_In_MaxTCP_changed |
                DNS_Out_ViaIPv4_changed |
                DNS_Out_ViaIPv6_changed |
                DNS_Out_FromIPv4_changed |
                DNS_Out_FromIPv6_changed |
                DNS_Out_PortUDPRandom_changed |
                DNS_Out_PortUDP_changed |
                DNS_Out_EDNS_changed |
                DNS_Recursion_Allow_changed |
                DNS_Recursion_MaxParallel_changed |
                DNS_Recursion_MatchRespIP_changed |
                DNS_Recursion_IgnoreNoQSect_changed |
                DNS_Recursion_DNS0x20_changed |
                DNS_RespFilter_Enable_changed |
                DNS_RespFilter_Remove_changed |
                DNS_RespFilter_Trust_changed |
                DNS_Cache_Enable_changed |
                DNS_Cache_MaxTTL_changed |
                DNS_Cache_MaxNegativeTTL_changed |
                DNS_Cache_MaxRecords_changed |
                DNS_Cache_Reload_changed |
                DNS_Cache_MinTTL_changed |
                DNS_ZoneTransfer_Keys_changed |
                DNS_ZoneTransfer_IPs_changed |
                DNS_ZoneTransfer_OneRec_changed |
                DNS_MasterSlave_Slaves_changed |
                DNS_MasterSlave_Unsigned_changed |
                DNS_MasterSlave_Masters_changed |
                DNS_MasterSlave_VerifyIV_changed |
                DNS_Secondary_RefreshPerSec_changed |
                DNS_Secondary_MaxParallel_changed |
                DNS_Secondary_ExpiredRetry_changed |
                DNS_Secondary_UseIXFR_changed |
                DNS_Secondary_OnlyPrimIPNotify_changed |
                DNS_Secondary_MinSOARefresh_changed |
                DNS_Secondary_MinSOARetry_changed |
                DNS_Secondary_MinSOAExpire_changed |
                DNS_SuspZone_Action_changed |
                DNS_SuspZone_SynthA_changed |
                DNS_SuspZone_SynthAAAA_changed |
                DNS_SuspZone_SynthMX_changed |
                DNS_AutoSPF_Enable_changed |
                DNS_AutoSPF_Data_changed |
                DNS_AutoSPF_TTL_changed |
                DNS_TSIGUpdate_Keys_changed |
                DNS_ZoneVersions_changed |
                DNS_Forward_changed |
                DNS_Lame_Action_changed |
                DNS_Lame_SynthA_changed |
                DNS_Lame_SynthAAAA_changed |
                DNS_Lame_SynthMX_changed |
                DNS_NXDomain_Enable_changed |
                DNS_NXDomain_IPv4_changed |
                DNS_NXDomain_IPv6_changed |
                DNS_NXDomain_OnlyWWW_changed |
                DNS_NXDomain_ExceptAA_changed |
                DNS_NXDomain_ExceptDNSBL_changed |
                DNS_NXDomain_ExceptDomains_changed |
                DNS_NXDomain_ExceptIPs_changed |
                DNS_NATIPAlias_Enable_changed |
                DNS_NATIPAlias_Aliases_changed |
                DNS_NATIPAlias_LANIPs_changed |
                DNS_NATIPAlias_SelfOnLAN_changed |
                DNS_Misc_RoundRobin_changed |
                DNS_Misc_SendNotify_changed |
                DNS_Misc_AutoUpdateRoot_changed |
                DNS_Misc_StandardEmptyZones_changed |
                DNS_Misc_EDNSPayLoad_changed |
                DNS_Misc_BINDVer_changed |
                DNS_Misc_BINDVerTXT_changed |
                DNS_Misc_LCC_changed |
                DNS_Misc_LCCMax_changed |
                DNS_Misc_UdpRootProc_changed |
                DNS_Misc_UdpRootLog_changed |
                DNS_Misc_UdpAnyProc_changed |
                DNS_Misc_UdpAnyLog_changed |
                HTTPAPI_Enable_changed |
                HTTPAPI_Prefix_changed |
                HTTPAPI_Auth_changed |
                HTTPAPI_WinUser_changed |
                HTTPAPI_UserID_changed |
                HTTPAPI_Password_changed |
                HTTPAPI_CorsEnable_changed |
                HTTPAPI_CorsOrigins_changed |
                HTTPAPI_EnableV1_changed |
                Log_Details_Records_changed |
                Log_Details_EDNS0_changed |
                Log_Details_Outgoing_changed |
                Log_Details_Blocked_changed |
                Log_Details_OnlyErrors_changed |
                Log_Details_IDNNative_changed |
                Log_Files_Begin_changed |
                Log_Files_Recycle_changed |
                Log_Files_Raw_changed |
                Log_Files_HttpFullReq_changed |
                Log_Files_Path_changed |
                Log_Syslog_Enable_changed |
                Log_Syslog_IP_changed |
                Log_Syslog_Port_changed |
                Log_ActiveLog_Lines_changed |
                Log_ActiveLog_Buffer_changed |
                Log_WinEvents_Enable_changed |
                Log_WinEvents_Exclude_changed |
                Remote_Enable_changed |
                Remote_Port_changed |
                Remote_Password_changed);
            }
        }
        private bool changed;
        public void Commit()
        {
            changed = false;

            General_Name_changed = false;
            General_TrayBar_changed = false;
            DNS_In_ListenAll_changed = false;
            DNS_In_IPs_changed = false;
            DNS_In_Port_changed = false;
            DNS_In_MaxTCP_changed = false;
            DNS_Out_ViaIPv4_changed = false;
            DNS_Out_ViaIPv6_changed = false;
            DNS_Out_FromIPv4_changed = false;
            DNS_Out_FromIPv6_changed = false;
            DNS_Out_PortUDPRandom_changed = false;
            DNS_Out_PortUDP_changed = false;
            DNS_Out_EDNS_changed = false;
            DNS_Recursion_Allow_changed = false;
            DNS_Recursion_MaxParallel_changed = false;
            DNS_Recursion_MatchRespIP_changed = false;
            DNS_Recursion_IgnoreNoQSect_changed = false;
            DNS_Recursion_DNS0x20_changed = false;
            DNS_RespFilter_Enable_changed = false;
            DNS_RespFilter_Remove_changed = false;
            DNS_RespFilter_Trust_changed = false;
            DNS_Cache_Enable_changed = false;
            DNS_Cache_MaxTTL_changed = false;
            DNS_Cache_MaxNegativeTTL_changed = false;
            DNS_Cache_MaxRecords_changed = false;
            DNS_Cache_Reload_changed = false;
            DNS_Cache_MinTTL_changed = false;
            DNS_ZoneTransfer_Keys_changed = false;
            DNS_ZoneTransfer_IPs_changed = false;
            DNS_ZoneTransfer_OneRec_changed = false;
            DNS_MasterSlave_Slaves_changed = false;
            DNS_MasterSlave_Unsigned_changed = false;
            DNS_MasterSlave_Masters_changed = false;
            DNS_MasterSlave_VerifyIV_changed = false;
            DNS_Secondary_RefreshPerSec_changed = false;
            DNS_Secondary_MaxParallel_changed = false;
            DNS_Secondary_ExpiredRetry_changed = false;
            DNS_Secondary_UseIXFR_changed = false;
            DNS_Secondary_OnlyPrimIPNotify_changed = false;
            DNS_Secondary_MinSOARefresh_changed = false;
            DNS_Secondary_MinSOARetry_changed = false;
            DNS_Secondary_MinSOAExpire_changed = false;
            DNS_SuspZone_Action_changed = false;
            DNS_SuspZone_SynthA_changed = false;
            DNS_SuspZone_SynthAAAA_changed = false;
            DNS_SuspZone_SynthMX_changed = false;
            DNS_AutoSPF_Enable_changed = false;
            DNS_AutoSPF_Data_changed = false;
            DNS_AutoSPF_TTL_changed = false;
            DNS_TSIGUpdate_Keys_changed = false;
            DNS_ZoneVersions_changed = false;
            DNS_Forward_changed = false;
            DNS_Lame_Action_changed = false;
            DNS_Lame_SynthA_changed = false;
            DNS_Lame_SynthAAAA_changed = false;
            DNS_Lame_SynthMX_changed = false;
            DNS_NXDomain_Enable_changed = false;
            DNS_NXDomain_IPv4_changed = false;
            DNS_NXDomain_IPv6_changed = false;
            DNS_NXDomain_OnlyWWW_changed = false;
            DNS_NXDomain_ExceptAA_changed = false;
            DNS_NXDomain_ExceptDNSBL_changed = false;
            DNS_NXDomain_ExceptDomains_changed = false;
            DNS_NXDomain_ExceptIPs_changed = false;
            DNS_NATIPAlias_Enable_changed = false;
            DNS_NATIPAlias_Aliases_changed = false;
            DNS_NATIPAlias_LANIPs_changed = false;
            DNS_NATIPAlias_SelfOnLAN_changed = false;
            DNS_Misc_RoundRobin_changed = false;
            DNS_Misc_SendNotify_changed = false;
            DNS_Misc_AutoUpdateRoot_changed = false;
            DNS_Misc_StandardEmptyZones_changed = false;
            DNS_Misc_EDNSPayLoad_changed = false;
            DNS_Misc_BINDVer_changed = false;
            DNS_Misc_BINDVerTXT_changed = false;
            DNS_Misc_LCC_changed = false;
            DNS_Misc_LCCMax_changed = false;
            DNS_Misc_UdpRootProc_changed = false;
            DNS_Misc_UdpRootLog_changed = false;
            DNS_Misc_UdpAnyProc_changed = false;
            DNS_Misc_UdpAnyLog_changed = false;
            HTTPAPI_Enable_changed = false;
            HTTPAPI_Prefix_changed = false;
            HTTPAPI_Auth_changed = false;
            HTTPAPI_WinUser_changed = false;
            HTTPAPI_UserID_changed = false;
            HTTPAPI_Password_changed = false;
            HTTPAPI_CorsEnable_changed = false;
            HTTPAPI_CorsOrigins_changed = false;
            HTTPAPI_EnableV1_changed = false;
            Log_Details_Records_changed = false;
            Log_Details_EDNS0_changed = false;
            Log_Details_Outgoing_changed = false;
            Log_Details_Blocked_changed = false;
            Log_Details_OnlyErrors_changed = false;
            Log_Details_IDNNative_changed = false;
            Log_Files_Begin_changed = false;
            Log_Files_Recycle_changed = false;
            Log_Files_Raw_changed = false;
            Log_Files_HttpFullReq_changed = false;
            Log_Files_Path_changed = false;
            Log_Syslog_Enable_changed = false;
            Log_Syslog_IP_changed = false;
            Log_Syslog_Port_changed = false;
            Log_ActiveLog_Lines_changed = false;
            Log_ActiveLog_Buffer_changed = false;
            Log_WinEvents_Enable_changed = false;
            Log_WinEvents_Exclude_changed = false;
            Remote_Enable_changed = false;
            Remote_Port_changed = false;
            Remote_Password_changed = false;

            DNS_In_IPs_value.Commit();
            DNS_Recursion_Allow_value.Commit();
            DNS_RespFilter_Remove_value.Commit();
            DNS_RespFilter_Trust_value.Commit();
            DNS_ZoneTransfer_Keys_value.Commit();
            DNS_ZoneTransfer_IPs_value.Commit();
            DNS_MasterSlave_Slaves_value.Commit();
            DNS_MasterSlave_Masters_value.Commit();
            DNS_TSIGUpdate_Keys_value.Commit();
            DNS_Forward_value.Commit();
            DNS_NXDomain_ExceptDomains_value.Commit();
            DNS_NXDomain_ExceptIPs_value.Commit();
            DNS_NATIPAlias_Aliases_value.Commit();
            DNS_NATIPAlias_LANIPs_value.Commit();
            HTTPAPI_CorsOrigins_value.Commit();
            Log_WinEvents_Exclude_value.Commit();
        }

        [JsonProperty("General_Name")]
        public string General_Name { get { return General_Name_value; } set { General_Name_changed = true; General_Name_value = value; } }
        private string General_Name_value;
        private bool General_Name_changed;
        public bool ShouldSerializeGeneral_Name() { return General_Name_changed; }

        [JsonProperty("General_TrayBar")]
        public bool General_TrayBar { get { return General_TrayBar_value; } set { General_TrayBar_changed = true; General_TrayBar_value = value; } }
        private bool General_TrayBar_value;
        private bool General_TrayBar_changed;
        public bool ShouldSerializeGeneral_TrayBar() { return General_TrayBar_changed; }

        [JsonProperty("DNS_In_ListenAll")]
        public bool DNS_In_ListenAll { get { return DNS_In_ListenAll_value; } set { DNS_In_ListenAll_changed = true; DNS_In_ListenAll_value = value; } }
        private bool DNS_In_ListenAll_value;
        private bool DNS_In_ListenAll_changed;
        public bool ShouldSerializeDNS_In_ListenAll() { return DNS_In_ListenAll_changed; }

        [JsonProperty("DNS_In_IPs")]
        public IPAddressList DNS_In_IPs { get { return DNS_In_IPs_value; } set { DNS_In_IPs_changed = true; DNS_In_IPs_value = value; } }
        private IPAddressList DNS_In_IPs_value;
        private bool DNS_In_IPs_changed;
        public bool ShouldSerializeDNS_In_IPs() { return (DNS_In_IPs_changed | DNS_In_IPs_value.Changed); }

        [JsonProperty("DNS_In_Port")]
        public ushort DNS_In_Port { get { return DNS_In_Port_value; } set { DNS_In_Port_changed = true; DNS_In_Port_value = value; } }
        private ushort DNS_In_Port_value;
        private bool DNS_In_Port_changed;
        public bool ShouldSerializeDNS_In_Port() { return DNS_In_Port_changed; }

        [JsonProperty("DNS_In_MaxTCP")]
        public ushort DNS_In_MaxTCP { get { return DNS_In_MaxTCP_value; } set { DNS_In_MaxTCP_changed = true; DNS_In_MaxTCP_value = value; } }
        private ushort DNS_In_MaxTCP_value;
        private bool DNS_In_MaxTCP_changed;
        public bool ShouldSerializeDNS_In_MaxTCP() { return DNS_In_MaxTCP_changed; }

        [JsonProperty("DNS_Out_ViaIPv4")]
        public bool DNS_Out_ViaIPv4 { get { return DNS_Out_ViaIPv4_value; } set { DNS_Out_ViaIPv4_changed = true; DNS_Out_ViaIPv4_value = value; } }
        private bool DNS_Out_ViaIPv4_value;
        private bool DNS_Out_ViaIPv4_changed;
        public bool ShouldSerializeDNS_Out_ViaIPv4() { return DNS_Out_ViaIPv4_changed; }

        [JsonProperty("DNS_Out_ViaIPv6")]
        public bool DNS_Out_ViaIPv6 { get { return DNS_Out_ViaIPv6_value; } set { DNS_Out_ViaIPv6_changed = true; DNS_Out_ViaIPv6_value = value; } }
        private bool DNS_Out_ViaIPv6_value;
        private bool DNS_Out_ViaIPv6_changed;
        public bool ShouldSerializeDNS_Out_ViaIPv6() { return DNS_Out_ViaIPv6_changed; }

        [JsonProperty("DNS_Out_FromIPv4")]
        public IPAddress DNS_Out_FromIPv4 { get { return DNS_Out_FromIPv4_value; } set { DNS_Out_FromIPv4_changed = true; DNS_Out_FromIPv4_value = value; } }
        private IPAddress DNS_Out_FromIPv4_value;
        private bool DNS_Out_FromIPv4_changed;
        public bool ShouldSerializeDNS_Out_FromIPv4() { return DNS_Out_FromIPv4_changed; }

        [JsonProperty("DNS_Out_FromIPv6")]
        public IPAddress DNS_Out_FromIPv6 { get { return DNS_Out_FromIPv6_value; } set { DNS_Out_FromIPv6_changed = true; DNS_Out_FromIPv6_value = value; } }
        private IPAddress DNS_Out_FromIPv6_value;
        private bool DNS_Out_FromIPv6_changed;
        public bool ShouldSerializeDNS_Out_FromIPv6() { return DNS_Out_FromIPv6_changed; }

        [JsonProperty("DNS_Out_PortUDPRandom")]
        public bool DNS_Out_PortUDPRandom { get { return DNS_Out_PortUDPRandom_value; } set { DNS_Out_PortUDPRandom_changed = true; DNS_Out_PortUDPRandom_value = value; } }
        private bool DNS_Out_PortUDPRandom_value;
        private bool DNS_Out_PortUDPRandom_changed;
        public bool ShouldSerializeDNS_Out_PortUDPRandom() { return DNS_Out_PortUDPRandom_changed; }

        [JsonProperty("DNS_Out_PortUDP")]
        public ushort DNS_Out_PortUDP { get { return DNS_Out_PortUDP_value; } set { DNS_Out_PortUDP_changed = true; DNS_Out_PortUDP_value = value; } }
        private ushort DNS_Out_PortUDP_value;
        private bool DNS_Out_PortUDP_changed;
        public bool ShouldSerializeDNS_Out_PortUDP() { return DNS_Out_PortUDP_changed; }

        [JsonProperty("DNS_Out_EDNS")]
        public bool DNS_Out_EDNS { get { return DNS_Out_EDNS_value; } set { DNS_Out_EDNS_changed = true; DNS_Out_EDNS_value = value; } }
        private bool DNS_Out_EDNS_value;
        private bool DNS_Out_EDNS_changed;
        public bool ShouldSerializeDNS_Out_EDNS() { return DNS_Out_EDNS_changed; }

        [JsonProperty("DNS_Recursion_Allow")]
        public IPAddressMatch DNS_Recursion_Allow { get { return DNS_Recursion_Allow_value; } set { DNS_Recursion_Allow_changed = true; DNS_Recursion_Allow_value = value; } }
        private IPAddressMatch DNS_Recursion_Allow_value;
        private bool DNS_Recursion_Allow_changed;
        public bool ShouldSerializeDNS_Recursion_Allow() { return (DNS_Recursion_Allow_changed | DNS_Recursion_Allow_value.Changed); }

        [JsonProperty("DNS_Recursion_MaxParallel")]
        public uint DNS_Recursion_MaxParallel { get { return DNS_Recursion_MaxParallel_value; } set { DNS_Recursion_MaxParallel_changed = true; DNS_Recursion_MaxParallel_value = value; } }
        private uint DNS_Recursion_MaxParallel_value;
        private bool DNS_Recursion_MaxParallel_changed;
        public bool ShouldSerializeDNS_Recursion_MaxParallel() { return DNS_Recursion_MaxParallel_changed; }

        [JsonProperty("DNS_Recursion_MatchRespIP")]
        public bool DNS_Recursion_MatchRespIP { get { return DNS_Recursion_MatchRespIP_value; } set { DNS_Recursion_MatchRespIP_changed = true; DNS_Recursion_MatchRespIP_value = value; } }
        private bool DNS_Recursion_MatchRespIP_value;
        private bool DNS_Recursion_MatchRespIP_changed;
        public bool ShouldSerializeDNS_Recursion_MatchRespIP() { return DNS_Recursion_MatchRespIP_changed; }

        [JsonProperty("DNS_Recursion_IgnoreNoQSect")]
        public bool DNS_Recursion_IgnoreNoQSect { get { return DNS_Recursion_IgnoreNoQSect_value; } set { DNS_Recursion_IgnoreNoQSect_changed = true; DNS_Recursion_IgnoreNoQSect_value = value; } }
        private bool DNS_Recursion_IgnoreNoQSect_value;
        private bool DNS_Recursion_IgnoreNoQSect_changed;
        public bool ShouldSerializeDNS_Recursion_IgnoreNoQSect() { return DNS_Recursion_IgnoreNoQSect_changed; }

        [JsonProperty("DNS_Recursion_DNS0x20")]
        public bool DNS_Recursion_DNS0x20 { get { return DNS_Recursion_DNS0x20_value; } set { DNS_Recursion_DNS0x20_changed = true; DNS_Recursion_DNS0x20_value = value; } }
        private bool DNS_Recursion_DNS0x20_value;
        private bool DNS_Recursion_DNS0x20_changed;
        public bool ShouldSerializeDNS_Recursion_DNS0x20() { return DNS_Recursion_DNS0x20_changed; }

        [JsonProperty("DNS_RespFilter_Enable")]
        public bool DNS_RespFilter_Enable { get { return DNS_RespFilter_Enable_value; } set { DNS_RespFilter_Enable_changed = true; DNS_RespFilter_Enable_value = value; } }
        private bool DNS_RespFilter_Enable_value;
        private bool DNS_RespFilter_Enable_changed;
        public bool ShouldSerializeDNS_RespFilter_Enable() { return DNS_RespFilter_Enable_changed; }

        [JsonProperty("DNS_RespFilter_Remove")]
        public IPAddressRangeList DNS_RespFilter_Remove { get { return DNS_RespFilter_Remove_value; } set { DNS_RespFilter_Remove_changed = true; DNS_RespFilter_Remove_value = value; } }
        private IPAddressRangeList DNS_RespFilter_Remove_value;
        private bool DNS_RespFilter_Remove_changed;
        public bool ShouldSerializeDNS_RespFilter_Remove() { return (DNS_RespFilter_Remove_changed | DNS_RespFilter_Remove_value.Changed); }

        [JsonProperty("DNS_RespFilter_Trust")]
        public IPAddressRangeList DNS_RespFilter_Trust { get { return DNS_RespFilter_Trust_value; } set { DNS_RespFilter_Trust_changed = true; DNS_RespFilter_Trust_value = value; } }
        private IPAddressRangeList DNS_RespFilter_Trust_value;
        private bool DNS_RespFilter_Trust_changed;
        public bool ShouldSerializeDNS_RespFilter_Trust() { return (DNS_RespFilter_Trust_changed | DNS_RespFilter_Trust_value.Changed); }

        [JsonProperty("DNS_Cache_Enable")]
        public bool DNS_Cache_Enable { get { return DNS_Cache_Enable_value; } set { DNS_Cache_Enable_changed = true; DNS_Cache_Enable_value = value; } }
        private bool DNS_Cache_Enable_value;
        private bool DNS_Cache_Enable_changed;
        public bool ShouldSerializeDNS_Cache_Enable() { return DNS_Cache_Enable_changed; }

        [JsonProperty("DNS_Cache_MaxTTL")]
        public uint DNS_Cache_MaxTTL { get { return DNS_Cache_MaxTTL_value; } set { DNS_Cache_MaxTTL_changed = true; DNS_Cache_MaxTTL_value = value; } }
        private uint DNS_Cache_MaxTTL_value;
        private bool DNS_Cache_MaxTTL_changed;
        public bool ShouldSerializeDNS_Cache_MaxTTL() { return DNS_Cache_MaxTTL_changed; }

        [JsonProperty("DNS_Cache_MaxNegativeTTL")]
        public uint DNS_Cache_MaxNegativeTTL { get { return DNS_Cache_MaxNegativeTTL_value; } set { DNS_Cache_MaxNegativeTTL_changed = true; DNS_Cache_MaxNegativeTTL_value = value; } }
        private uint DNS_Cache_MaxNegativeTTL_value;
        private bool DNS_Cache_MaxNegativeTTL_changed;
        public bool ShouldSerializeDNS_Cache_MaxNegativeTTL() { return DNS_Cache_MaxNegativeTTL_changed; }

        [JsonProperty("DNS_Cache_MaxRecords")]
        public uint DNS_Cache_MaxRecords { get { return DNS_Cache_MaxRecords_value; } set { DNS_Cache_MaxRecords_changed = true; DNS_Cache_MaxRecords_value = value; } }
        private uint DNS_Cache_MaxRecords_value;
        private bool DNS_Cache_MaxRecords_changed;
        public bool ShouldSerializeDNS_Cache_MaxRecords() { return DNS_Cache_MaxRecords_changed; }

        [JsonProperty("DNS_Cache_Reload")]
        public bool DNS_Cache_Reload { get { return DNS_Cache_Reload_value; } set { DNS_Cache_Reload_changed = true; DNS_Cache_Reload_value = value; } }
        private bool DNS_Cache_Reload_value;
        private bool DNS_Cache_Reload_changed;
        public bool ShouldSerializeDNS_Cache_Reload() { return DNS_Cache_Reload_changed; }

        [JsonProperty("DNS_Cache_MinTTL")]
        public uint DNS_Cache_MinTTL { get { return DNS_Cache_MinTTL_value; } set { DNS_Cache_MinTTL_changed = true; DNS_Cache_MinTTL_value = value; } }
        private uint DNS_Cache_MinTTL_value;
        private bool DNS_Cache_MinTTL_changed;
        public bool ShouldSerializeDNS_Cache_MinTTL() { return DNS_Cache_MinTTL_changed; }

        [JsonProperty("DNS_ZoneTransfer_Keys")]
        public TransferKeyList DNS_ZoneTransfer_Keys { get { return DNS_ZoneTransfer_Keys_value; } set { DNS_ZoneTransfer_Keys_changed = true; DNS_ZoneTransfer_Keys_value = value; } }
        private TransferKeyList DNS_ZoneTransfer_Keys_value;
        private bool DNS_ZoneTransfer_Keys_changed;
        public bool ShouldSerializeDNS_ZoneTransfer_Keys() { return (DNS_ZoneTransfer_Keys_changed | DNS_ZoneTransfer_Keys_value.Changed); }

        [JsonProperty("DNS_ZoneTransfer_IPs")]
        public IPAddressMatch DNS_ZoneTransfer_IPs { get { return DNS_ZoneTransfer_IPs_value; } set { DNS_ZoneTransfer_IPs_changed = true; DNS_ZoneTransfer_IPs_value = value; } }
        private IPAddressMatch DNS_ZoneTransfer_IPs_value;
        private bool DNS_ZoneTransfer_IPs_changed;
        public bool ShouldSerializeDNS_ZoneTransfer_IPs() { return (DNS_ZoneTransfer_IPs_changed | DNS_ZoneTransfer_IPs_value.Changed); }

        [JsonProperty("DNS_ZoneTransfer_OneRec")]
        public bool DNS_ZoneTransfer_OneRec { get { return DNS_ZoneTransfer_OneRec_value; } set { DNS_ZoneTransfer_OneRec_changed = true; DNS_ZoneTransfer_OneRec_value = value; } }
        private bool DNS_ZoneTransfer_OneRec_value;
        private bool DNS_ZoneTransfer_OneRec_changed;
        public bool ShouldSerializeDNS_ZoneTransfer_OneRec() { return DNS_ZoneTransfer_OneRec_changed; }

        [JsonProperty("DNS_MasterSlave_Slaves")]
        public IPAddressRangeList DNS_MasterSlave_Slaves { get { return DNS_MasterSlave_Slaves_value; } set { DNS_MasterSlave_Slaves_changed = true; DNS_MasterSlave_Slaves_value = value; } }
        private IPAddressRangeList DNS_MasterSlave_Slaves_value;
        private bool DNS_MasterSlave_Slaves_changed;
        public bool ShouldSerializeDNS_MasterSlave_Slaves() { return (DNS_MasterSlave_Slaves_changed | DNS_MasterSlave_Slaves_value.Changed); }

        [JsonProperty("DNS_MasterSlave_Unsigned")]
        public bool DNS_MasterSlave_Unsigned { get { return DNS_MasterSlave_Unsigned_value; } set { DNS_MasterSlave_Unsigned_changed = true; DNS_MasterSlave_Unsigned_value = value; } }
        private bool DNS_MasterSlave_Unsigned_value;
        private bool DNS_MasterSlave_Unsigned_changed;
        public bool ShouldSerializeDNS_MasterSlave_Unsigned() { return DNS_MasterSlave_Unsigned_changed; }

        [JsonProperty("DNS_MasterSlave_Masters")]
        public MasterList DNS_MasterSlave_Masters { get { return DNS_MasterSlave_Masters_value; } set { DNS_MasterSlave_Masters_changed = true; DNS_MasterSlave_Masters_value = value; } }
        private MasterList DNS_MasterSlave_Masters_value;
        private bool DNS_MasterSlave_Masters_changed;
        public bool ShouldSerializeDNS_MasterSlave_Masters() { return (DNS_MasterSlave_Masters_changed | DNS_MasterSlave_Masters_value.Changed); }

        [JsonProperty("DNS_MasterSlave_VerifyIV")]
        public uint DNS_MasterSlave_VerifyIV { get { return DNS_MasterSlave_VerifyIV_value; } set { DNS_MasterSlave_VerifyIV_changed = true; DNS_MasterSlave_VerifyIV_value = value; } }
        private uint DNS_MasterSlave_VerifyIV_value;
        private bool DNS_MasterSlave_VerifyIV_changed;
        public bool ShouldSerializeDNS_MasterSlave_VerifyIV() { return DNS_MasterSlave_VerifyIV_changed; }

        [JsonProperty("DNS_Secondary_RefreshPerSec")]
        public ushort DNS_Secondary_RefreshPerSec { get { return DNS_Secondary_RefreshPerSec_value; } set { DNS_Secondary_RefreshPerSec_changed = true; DNS_Secondary_RefreshPerSec_value = value; } }
        private ushort DNS_Secondary_RefreshPerSec_value;
        private bool DNS_Secondary_RefreshPerSec_changed;
        public bool ShouldSerializeDNS_Secondary_RefreshPerSec() { return DNS_Secondary_RefreshPerSec_changed; }

        [JsonProperty("DNS_Secondary_MaxParallel")]
        public byte DNS_Secondary_MaxParallel { get { return DNS_Secondary_MaxParallel_value; } set { DNS_Secondary_MaxParallel_changed = true; DNS_Secondary_MaxParallel_value = value; } }
        private byte DNS_Secondary_MaxParallel_value;
        private bool DNS_Secondary_MaxParallel_changed;
        public bool ShouldSerializeDNS_Secondary_MaxParallel() { return DNS_Secondary_MaxParallel_changed; }

        [JsonProperty("DNS_Secondary_ExpiredRetry")]
        public uint DNS_Secondary_ExpiredRetry { get { return DNS_Secondary_ExpiredRetry_value; } set { DNS_Secondary_ExpiredRetry_changed = true; DNS_Secondary_ExpiredRetry_value = value; } }
        private uint DNS_Secondary_ExpiredRetry_value;
        private bool DNS_Secondary_ExpiredRetry_changed;
        public bool ShouldSerializeDNS_Secondary_ExpiredRetry() { return DNS_Secondary_ExpiredRetry_changed; }

        [JsonProperty("DNS_Secondary_UseIXFR")]
        public bool DNS_Secondary_UseIXFR { get { return DNS_Secondary_UseIXFR_value; } set { DNS_Secondary_UseIXFR_changed = true; DNS_Secondary_UseIXFR_value = value; } }
        private bool DNS_Secondary_UseIXFR_value;
        private bool DNS_Secondary_UseIXFR_changed;
        public bool ShouldSerializeDNS_Secondary_UseIXFR() { return DNS_Secondary_UseIXFR_changed; }

        [JsonProperty("DNS_Secondary_OnlyPrimIPNotify")]
        public bool DNS_Secondary_OnlyPrimIPNotify { get { return DNS_Secondary_OnlyPrimIPNotify_value; } set { DNS_Secondary_OnlyPrimIPNotify_changed = true; DNS_Secondary_OnlyPrimIPNotify_value = value; } }
        private bool DNS_Secondary_OnlyPrimIPNotify_value;
        private bool DNS_Secondary_OnlyPrimIPNotify_changed;
        public bool ShouldSerializeDNS_Secondary_OnlyPrimIPNotify() { return DNS_Secondary_OnlyPrimIPNotify_changed; }

        [JsonProperty("DNS_Secondary_MinSOARefresh")]
        public uint DNS_Secondary_MinSOARefresh { get { return DNS_Secondary_MinSOARefresh_value; } set { DNS_Secondary_MinSOARefresh_changed = true; DNS_Secondary_MinSOARefresh_value = value; } }
        private uint DNS_Secondary_MinSOARefresh_value;
        private bool DNS_Secondary_MinSOARefresh_changed;
        public bool ShouldSerializeDNS_Secondary_MinSOARefresh() { return DNS_Secondary_MinSOARefresh_changed; }

        [JsonProperty("DNS_Secondary_MinSOARetry")]
        public uint DNS_Secondary_MinSOARetry { get { return DNS_Secondary_MinSOARetry_value; } set { DNS_Secondary_MinSOARetry_changed = true; DNS_Secondary_MinSOARetry_value = value; } }
        private uint DNS_Secondary_MinSOARetry_value;
        private bool DNS_Secondary_MinSOARetry_changed;
        public bool ShouldSerializeDNS_Secondary_MinSOARetry() { return DNS_Secondary_MinSOARetry_changed; }

        [JsonProperty("DNS_Secondary_MinSOAExpire")]
        public uint DNS_Secondary_MinSOAExpire { get { return DNS_Secondary_MinSOAExpire_value; } set { DNS_Secondary_MinSOAExpire_changed = true; DNS_Secondary_MinSOAExpire_value = value; } }
        private uint DNS_Secondary_MinSOAExpire_value;
        private bool DNS_Secondary_MinSOAExpire_changed;
        public bool ShouldSerializeDNS_Secondary_MinSOAExpire() { return DNS_Secondary_MinSOAExpire_changed; }

        [JsonProperty("DNS_SuspZone_Action")]
        public string DNS_SuspZone_Action { get { return DNS_SuspZone_Action_value; } set { DNS_SuspZone_Action_changed = true; DNS_SuspZone_Action_value = value; } }
        private string DNS_SuspZone_Action_value;
        private bool DNS_SuspZone_Action_changed;
        public bool ShouldSerializeDNS_SuspZone_Action() { return DNS_SuspZone_Action_changed; }

        [JsonProperty("DNS_SuspZone_SynthA")]
        public string DNS_SuspZone_SynthA { get { return DNS_SuspZone_SynthA_value; } set { DNS_SuspZone_SynthA_changed = true; DNS_SuspZone_SynthA_value = value; } }
        private string DNS_SuspZone_SynthA_value;
        private bool DNS_SuspZone_SynthA_changed;
        public bool ShouldSerializeDNS_SuspZone_SynthA() { return DNS_SuspZone_SynthA_changed; }

        [JsonProperty("DNS_SuspZone_SynthAAAA")]
        public string DNS_SuspZone_SynthAAAA { get { return DNS_SuspZone_SynthAAAA_value; } set { DNS_SuspZone_SynthAAAA_changed = true; DNS_SuspZone_SynthAAAA_value = value; } }
        private string DNS_SuspZone_SynthAAAA_value;
        private bool DNS_SuspZone_SynthAAAA_changed;
        public bool ShouldSerializeDNS_SuspZone_SynthAAAA() { return DNS_SuspZone_SynthAAAA_changed; }

        [JsonProperty("DNS_SuspZone_SynthMX")]
        public string DNS_SuspZone_SynthMX { get { return DNS_SuspZone_SynthMX_value; } set { DNS_SuspZone_SynthMX_changed = true; DNS_SuspZone_SynthMX_value = value; } }
        private string DNS_SuspZone_SynthMX_value;
        private bool DNS_SuspZone_SynthMX_changed;
        public bool ShouldSerializeDNS_SuspZone_SynthMX() { return DNS_SuspZone_SynthMX_changed; }

        [JsonProperty("DNS_AutoSPF_Enable")]
        public bool DNS_AutoSPF_Enable { get { return DNS_AutoSPF_Enable_value; } set { DNS_AutoSPF_Enable_changed = true; DNS_AutoSPF_Enable_value = value; } }
        private bool DNS_AutoSPF_Enable_value;
        private bool DNS_AutoSPF_Enable_changed;
        public bool ShouldSerializeDNS_AutoSPF_Enable() { return DNS_AutoSPF_Enable_changed; }

        [JsonProperty("DNS_AutoSPF_Data")]
        public string DNS_AutoSPF_Data { get { return DNS_AutoSPF_Data_value; } set { DNS_AutoSPF_Data_changed = true; DNS_AutoSPF_Data_value = value; } }
        private string DNS_AutoSPF_Data_value;
        private bool DNS_AutoSPF_Data_changed;
        public bool ShouldSerializeDNS_AutoSPF_Data() { return DNS_AutoSPF_Data_changed; }

        [JsonProperty("DNS_AutoSPF_TTL")]
        public uint DNS_AutoSPF_TTL { get { return DNS_AutoSPF_TTL_value; } set { DNS_AutoSPF_TTL_changed = true; DNS_AutoSPF_TTL_value = value; } }
        private uint DNS_AutoSPF_TTL_value;
        private bool DNS_AutoSPF_TTL_changed;
        public bool ShouldSerializeDNS_AutoSPF_TTL() { return DNS_AutoSPF_TTL_changed; }

        [JsonProperty("DNS_TSIGUpdate_Keys")]
        public UpdateKeyList DNS_TSIGUpdate_Keys { get { return DNS_TSIGUpdate_Keys_value; } set { DNS_TSIGUpdate_Keys_changed = true; DNS_TSIGUpdate_Keys_value = value; } }
        private UpdateKeyList DNS_TSIGUpdate_Keys_value;
        private bool DNS_TSIGUpdate_Keys_changed;
        public bool ShouldSerializeDNS_TSIGUpdate_Keys() { return (DNS_TSIGUpdate_Keys_changed | DNS_TSIGUpdate_Keys_value.Changed); }

        [JsonProperty("DNS_ZoneVersions")]
        public ushort DNS_ZoneVersions { get { return DNS_ZoneVersions_value; } set { DNS_ZoneVersions_changed = true; DNS_ZoneVersions_value = value; } }
        private ushort DNS_ZoneVersions_value;
        private bool DNS_ZoneVersions_changed;
        public bool ShouldSerializeDNS_ZoneVersions() { return DNS_ZoneVersions_changed; }

        [JsonProperty("DNS_Forward")]
        public ForwardList DNS_Forward { get { return DNS_Forward_value; } set { DNS_Forward_changed = true; DNS_Forward_value = value; } }
        private ForwardList DNS_Forward_value;
        private bool DNS_Forward_changed;
        public bool ShouldSerializeDNS_Forward() { return (DNS_Forward_changed | DNS_Forward_value.Changed); }

        [JsonProperty("DNS_Lame_Action")]
        public DNSLameAction DNS_Lame_Action { get { return DNS_Lame_Action_value; } set { DNS_Lame_Action_changed = true; DNS_Lame_Action_value = value; } }
        private DNSLameAction DNS_Lame_Action_value;
        private bool DNS_Lame_Action_changed;
        public bool ShouldSerializeDNS_Lame_Action() { return DNS_Lame_Action_changed; }

        [JsonProperty("DNS_Lame_SynthA")]
        public IPAddress DNS_Lame_SynthA { get { return DNS_Lame_SynthA_value; } set { DNS_Lame_SynthA_changed = true; DNS_Lame_SynthA_value = value; } }
        private IPAddress DNS_Lame_SynthA_value;
        private bool DNS_Lame_SynthA_changed;
        public bool ShouldSerializeDNS_Lame_SynthA() { return DNS_Lame_SynthA_changed; }

        [JsonProperty("DNS_Lame_SynthAAAA")]
        public IPAddress DNS_Lame_SynthAAAA { get { return DNS_Lame_SynthAAAA_value; } set { DNS_Lame_SynthAAAA_changed = true; DNS_Lame_SynthAAAA_value = value; } }
        private IPAddress DNS_Lame_SynthAAAA_value;
        private bool DNS_Lame_SynthAAAA_changed;
        public bool ShouldSerializeDNS_Lame_SynthAAAA() { return DNS_Lame_SynthAAAA_changed; }

        [JsonProperty("DNS_Lame_SynthMX")]
        public string DNS_Lame_SynthMX { get { return DNS_Lame_SynthMX_value; } set { DNS_Lame_SynthMX_changed = true; DNS_Lame_SynthMX_value = value; } }
        private string DNS_Lame_SynthMX_value;
        private bool DNS_Lame_SynthMX_changed;
        public bool ShouldSerializeDNS_Lame_SynthMX() { return DNS_Lame_SynthMX_changed; }

        [JsonProperty("DNS_NXDomain_Enable")]
        public bool DNS_NXDomain_Enable { get { return DNS_NXDomain_Enable_value; } set { DNS_NXDomain_Enable_changed = true; DNS_NXDomain_Enable_value = value; } }
        private bool DNS_NXDomain_Enable_value;
        private bool DNS_NXDomain_Enable_changed;
        public bool ShouldSerializeDNS_NXDomain_Enable() { return DNS_NXDomain_Enable_changed; }

        [JsonProperty("DNS_NXDomain_IPv4")]
        public IPAddress DNS_NXDomain_IPv4 { get { return DNS_NXDomain_IPv4_value; } set { DNS_NXDomain_IPv4_changed = true; DNS_NXDomain_IPv4_value = value; } }
        private IPAddress DNS_NXDomain_IPv4_value;
        private bool DNS_NXDomain_IPv4_changed;
        public bool ShouldSerializeDNS_NXDomain_IPv4() { return DNS_NXDomain_IPv4_changed; }

        [JsonProperty("DNS_NXDomain_IPv6")]
        public IPAddress DNS_NXDomain_IPv6 { get { return DNS_NXDomain_IPv6_value; } set { DNS_NXDomain_IPv6_changed = true; DNS_NXDomain_IPv6_value = value; } }
        private IPAddress DNS_NXDomain_IPv6_value;
        private bool DNS_NXDomain_IPv6_changed;
        public bool ShouldSerializeDNS_NXDomain_IPv6() { return DNS_NXDomain_IPv6_changed; }

        [JsonProperty("DNS_NXDomain_OnlyWWW")]
        public bool DNS_NXDomain_OnlyWWW { get { return DNS_NXDomain_OnlyWWW_value; } set { DNS_NXDomain_OnlyWWW_changed = true; DNS_NXDomain_OnlyWWW_value = value; } }
        private bool DNS_NXDomain_OnlyWWW_value;
        private bool DNS_NXDomain_OnlyWWW_changed;
        public bool ShouldSerializeDNS_NXDomain_OnlyWWW() { return DNS_NXDomain_OnlyWWW_changed; }

        [JsonProperty("DNS_NXDomain_ExceptAA")]
        public bool DNS_NXDomain_ExceptAA { get { return DNS_NXDomain_ExceptAA_value; } set { DNS_NXDomain_ExceptAA_changed = true; DNS_NXDomain_ExceptAA_value = value; } }
        private bool DNS_NXDomain_ExceptAA_value;
        private bool DNS_NXDomain_ExceptAA_changed;
        public bool ShouldSerializeDNS_NXDomain_ExceptAA() { return DNS_NXDomain_ExceptAA_changed; }

        [JsonProperty("DNS_NXDomain_ExceptDNSBL")]
        public bool DNS_NXDomain_ExceptDNSBL { get { return DNS_NXDomain_ExceptDNSBL_value; } set { DNS_NXDomain_ExceptDNSBL_changed = true; DNS_NXDomain_ExceptDNSBL_value = value; } }
        private bool DNS_NXDomain_ExceptDNSBL_value;
        private bool DNS_NXDomain_ExceptDNSBL_changed;
        public bool ShouldSerializeDNS_NXDomain_ExceptDNSBL() { return DNS_NXDomain_ExceptDNSBL_changed; }

        [JsonProperty("DNS_NXDomain_ExceptDomains")]
        public StringList DNS_NXDomain_ExceptDomains { get { return DNS_NXDomain_ExceptDomains_value; } set { DNS_NXDomain_ExceptDomains_changed = true; DNS_NXDomain_ExceptDomains_value = value; } }
        private StringList DNS_NXDomain_ExceptDomains_value;
        private bool DNS_NXDomain_ExceptDomains_changed;
        public bool ShouldSerializeDNS_NXDomain_ExceptDomains() { return (DNS_NXDomain_ExceptDomains_changed | DNS_NXDomain_ExceptDomains_value.Changed); }

        [JsonProperty("DNS_NXDomain_ExceptIPs")]
        public IPAddressRangeList DNS_NXDomain_ExceptIPs { get { return DNS_NXDomain_ExceptIPs_value; } set { DNS_NXDomain_ExceptIPs_changed = true; DNS_NXDomain_ExceptIPs_value = value; } }
        private IPAddressRangeList DNS_NXDomain_ExceptIPs_value;
        private bool DNS_NXDomain_ExceptIPs_changed;
        public bool ShouldSerializeDNS_NXDomain_ExceptIPs() { return (DNS_NXDomain_ExceptIPs_changed | DNS_NXDomain_ExceptIPs_value.Changed); }

        [JsonProperty("DNS_NATIPAlias_Enable")]
        public bool DNS_NATIPAlias_Enable { get { return DNS_NATIPAlias_Enable_value; } set { DNS_NATIPAlias_Enable_changed = true; DNS_NATIPAlias_Enable_value = value; } }
        private bool DNS_NATIPAlias_Enable_value;
        private bool DNS_NATIPAlias_Enable_changed;
        public bool ShouldSerializeDNS_NATIPAlias_Enable() { return DNS_NATIPAlias_Enable_changed; }

        [JsonProperty("DNS_NATIPAlias_Aliases")]
        public IPAliasList DNS_NATIPAlias_Aliases { get { return DNS_NATIPAlias_Aliases_value; } set { DNS_NATIPAlias_Aliases_changed = true; DNS_NATIPAlias_Aliases_value = value; } }
        private IPAliasList DNS_NATIPAlias_Aliases_value;
        private bool DNS_NATIPAlias_Aliases_changed;
        public bool ShouldSerializeDNS_NATIPAlias_Aliases() { return (DNS_NATIPAlias_Aliases_changed | DNS_NATIPAlias_Aliases_value.Changed); }

        [JsonProperty("DNS_NATIPAlias_LANIPs")]
        public IPAddressRangeList DNS_NATIPAlias_LANIPs { get { return DNS_NATIPAlias_LANIPs_value; } set { DNS_NATIPAlias_LANIPs_changed = true; DNS_NATIPAlias_LANIPs_value = value; } }
        private IPAddressRangeList DNS_NATIPAlias_LANIPs_value;
        private bool DNS_NATIPAlias_LANIPs_changed;
        public bool ShouldSerializeDNS_NATIPAlias_LANIPs() { return (DNS_NATIPAlias_LANIPs_changed | DNS_NATIPAlias_LANIPs_value.Changed); }

        [JsonProperty("DNS_NATIPAlias_SelfOnLAN")]
        public bool DNS_NATIPAlias_SelfOnLAN { get { return DNS_NATIPAlias_SelfOnLAN_value; } set { DNS_NATIPAlias_SelfOnLAN_changed = true; DNS_NATIPAlias_SelfOnLAN_value = value; } }
        private bool DNS_NATIPAlias_SelfOnLAN_value;
        private bool DNS_NATIPAlias_SelfOnLAN_changed;
        public bool ShouldSerializeDNS_NATIPAlias_SelfOnLAN() { return DNS_NATIPAlias_SelfOnLAN_changed; }

        [JsonProperty("DNS_Misc_RoundRobin")]
        public bool DNS_Misc_RoundRobin { get { return DNS_Misc_RoundRobin_value; } set { DNS_Misc_RoundRobin_changed = true; DNS_Misc_RoundRobin_value = value; } }
        private bool DNS_Misc_RoundRobin_value;
        private bool DNS_Misc_RoundRobin_changed;
        public bool ShouldSerializeDNS_Misc_RoundRobin() { return DNS_Misc_RoundRobin_changed; }

        [JsonProperty("DNS_Misc_SendNotify")]
        public bool DNS_Misc_SendNotify { get { return DNS_Misc_SendNotify_value; } set { DNS_Misc_SendNotify_changed = true; DNS_Misc_SendNotify_value = value; } }
        private bool DNS_Misc_SendNotify_value;
        private bool DNS_Misc_SendNotify_changed;
        public bool ShouldSerializeDNS_Misc_SendNotify() { return DNS_Misc_SendNotify_changed; }

        [JsonProperty("DNS_Misc_AutoUpdateRoot")]
        public bool DNS_Misc_AutoUpdateRoot { get { return DNS_Misc_AutoUpdateRoot_value; } set { DNS_Misc_AutoUpdateRoot_changed = true; DNS_Misc_AutoUpdateRoot_value = value; } }
        private bool DNS_Misc_AutoUpdateRoot_value;
        private bool DNS_Misc_AutoUpdateRoot_changed;
        public bool ShouldSerializeDNS_Misc_AutoUpdateRoot() { return DNS_Misc_AutoUpdateRoot_changed; }

        [JsonProperty("DNS_Misc_StandardEmptyZones")]
        public bool DNS_Misc_StandardEmptyZones { get { return DNS_Misc_StandardEmptyZones_value; } set { DNS_Misc_StandardEmptyZones_changed = true; DNS_Misc_StandardEmptyZones_value = value; } }
        private bool DNS_Misc_StandardEmptyZones_value;
        private bool DNS_Misc_StandardEmptyZones_changed;
        public bool ShouldSerializeDNS_Misc_StandardEmptyZones() { return DNS_Misc_StandardEmptyZones_changed; }

        [JsonProperty("DNS_Misc_EDNSPayLoad")]
        public ushort DNS_Misc_EDNSPayLoad { get { return DNS_Misc_EDNSPayLoad_value; } set { DNS_Misc_EDNSPayLoad_changed = true; DNS_Misc_EDNSPayLoad_value = value; } }
        private ushort DNS_Misc_EDNSPayLoad_value;
        private bool DNS_Misc_EDNSPayLoad_changed;
        public bool ShouldSerializeDNS_Misc_EDNSPayLoad() { return DNS_Misc_EDNSPayLoad_changed; }

        [JsonProperty("DNS_Misc_BINDVer")]
        public bool DNS_Misc_BINDVer { get { return DNS_Misc_BINDVer_value; } set { DNS_Misc_BINDVer_changed = true; DNS_Misc_BINDVer_value = value; } }
        private bool DNS_Misc_BINDVer_value;
        private bool DNS_Misc_BINDVer_changed;
        public bool ShouldSerializeDNS_Misc_BINDVer() { return DNS_Misc_BINDVer_changed; }

        [JsonProperty("DNS_Misc_BINDVerTXT")]
        public string DNS_Misc_BINDVerTXT { get { return DNS_Misc_BINDVerTXT_value; } set { DNS_Misc_BINDVerTXT_changed = true; DNS_Misc_BINDVerTXT_value = value; } }
        private string DNS_Misc_BINDVerTXT_value;
        private bool DNS_Misc_BINDVerTXT_changed;
        public bool ShouldSerializeDNS_Misc_BINDVerTXT() { return DNS_Misc_BINDVerTXT_changed; }

        [JsonProperty("DNS_Misc_LCC")]
        public bool DNS_Misc_LCC { get { return DNS_Misc_LCC_value; } set { DNS_Misc_LCC_changed = true; DNS_Misc_LCC_value = value; } }
        private bool DNS_Misc_LCC_value;
        private bool DNS_Misc_LCC_changed;
        public bool ShouldSerializeDNS_Misc_LCC() { return DNS_Misc_LCC_changed; }

        [JsonProperty("DNS_Misc_LCCMax")]
        public uint DNS_Misc_LCCMax { get { return DNS_Misc_LCCMax_value; } set { DNS_Misc_LCCMax_changed = true; DNS_Misc_LCCMax_value = value; } }
        private uint DNS_Misc_LCCMax_value;
        private bool DNS_Misc_LCCMax_changed;
        public bool ShouldSerializeDNS_Misc_LCCMax() { return DNS_Misc_LCCMax_changed; }

        [JsonProperty("DNS_Misc_UdpRootProc")]
        public UDPProcessingMode DNS_Misc_UdpRootProc { get { return DNS_Misc_UdpRootProc_value; } set { DNS_Misc_UdpRootProc_changed = true; DNS_Misc_UdpRootProc_value = value; } }
        private UDPProcessingMode DNS_Misc_UdpRootProc_value;
        private bool DNS_Misc_UdpRootProc_changed;
        public bool ShouldSerializeDNS_Misc_UdpRootProc() { return DNS_Misc_UdpRootProc_changed; }

        [JsonProperty("DNS_Misc_UdpRootLog")]
        public bool DNS_Misc_UdpRootLog { get { return DNS_Misc_UdpRootLog_value; } set { DNS_Misc_UdpRootLog_changed = true; DNS_Misc_UdpRootLog_value = value; } }
        private bool DNS_Misc_UdpRootLog_value;
        private bool DNS_Misc_UdpRootLog_changed;
        public bool ShouldSerializeDNS_Misc_UdpRootLog() { return DNS_Misc_UdpRootLog_changed; }

        [JsonProperty("DNS_Misc_UdpAnyProc")]
        public UDPProcessingMode DNS_Misc_UdpAnyProc { get { return DNS_Misc_UdpAnyProc_value; } set { DNS_Misc_UdpAnyProc_changed = true; DNS_Misc_UdpAnyProc_value = value; } }
        private UDPProcessingMode DNS_Misc_UdpAnyProc_value;
        private bool DNS_Misc_UdpAnyProc_changed;
        public bool ShouldSerializeDNS_Misc_UdpAnyProc() { return DNS_Misc_UdpAnyProc_changed; }

        [JsonProperty("DNS_Misc_UdpAnyLog")]
        public bool DNS_Misc_UdpAnyLog { get { return DNS_Misc_UdpAnyLog_value; } set { DNS_Misc_UdpAnyLog_changed = true; DNS_Misc_UdpAnyLog_value = value; } }
        private bool DNS_Misc_UdpAnyLog_value;
        private bool DNS_Misc_UdpAnyLog_changed;
        public bool ShouldSerializeDNS_Misc_UdpAnyLog() { return DNS_Misc_UdpAnyLog_changed; }

        [JsonProperty("HTTPAPI_Enable")]
        public bool HTTPAPI_Enable { get { return HTTPAPI_Enable_value; } set { HTTPAPI_Enable_changed = true; HTTPAPI_Enable_value = value; } }
        private bool HTTPAPI_Enable_value;
        private bool HTTPAPI_Enable_changed;
        public bool ShouldSerializeHTTPAPI_Enable() { return HTTPAPI_Enable_changed; }

        [JsonProperty("HTTPAPI_Prefix")]
        public string HTTPAPI_Prefix { get { return HTTPAPI_Prefix_value; } set { HTTPAPI_Prefix_changed = true; HTTPAPI_Prefix_value = value; } }
        private string HTTPAPI_Prefix_value;
        private bool HTTPAPI_Prefix_changed;
        public bool ShouldSerializeHTTPAPI_Prefix() { return HTTPAPI_Prefix_changed; }

        [JsonProperty("HTTPAPI_Auth")]
        public AuthenticationMode HTTPAPI_Auth { get { return HTTPAPI_Auth_value; } set { HTTPAPI_Auth_changed = true; HTTPAPI_Auth_value = value; } }
        private AuthenticationMode HTTPAPI_Auth_value;
        private bool HTTPAPI_Auth_changed;
        public bool ShouldSerializeHTTPAPI_Auth() { return HTTPAPI_Auth_changed; }

        [JsonProperty("HTTPAPI_WinUser")]
        public bool HTTPAPI_WinUser { get { return HTTPAPI_WinUser_value; } set { HTTPAPI_WinUser_changed = true; HTTPAPI_WinUser_value = value; } }
        private bool HTTPAPI_WinUser_value;
        private bool HTTPAPI_WinUser_changed;
        public bool ShouldSerializeHTTPAPI_WinUser() { return HTTPAPI_WinUser_changed; }

        [JsonProperty("HTTPAPI_UserID")]
        public string HTTPAPI_UserID { get { return HTTPAPI_UserID_value; } set { HTTPAPI_UserID_changed = true; HTTPAPI_UserID_value = value; } }
        private string HTTPAPI_UserID_value;
        private bool HTTPAPI_UserID_changed;
        public bool ShouldSerializeHTTPAPI_UserID() { return HTTPAPI_UserID_changed; }

        [JsonProperty("HTTPAPI_Password")]
        public string HTTPAPI_Password { get { return HTTPAPI_Password_value; } set { HTTPAPI_Password_changed = true; HTTPAPI_Password_value = value; } }
        private string HTTPAPI_Password_value;
        private bool HTTPAPI_Password_changed;
        public bool ShouldSerializeHTTPAPI_Password() { return HTTPAPI_Password_changed; }

        [JsonProperty("HTTPAPI_CorsEnable")]
        public bool HTTPAPI_CorsEnable { get { return HTTPAPI_CorsEnable_value; } set { HTTPAPI_CorsEnable_changed = true; HTTPAPI_CorsEnable_value = value; } }
        private bool HTTPAPI_CorsEnable_value;
        private bool HTTPAPI_CorsEnable_changed;
        public bool ShouldSerializeHTTPAPI_CorsEnable() { return HTTPAPI_CorsEnable_changed; }

        [JsonProperty("HTTPAPI_CorsOrigins")]
        public StringList HTTPAPI_CorsOrigins { get { return HTTPAPI_CorsOrigins_value; } set { HTTPAPI_CorsOrigins_changed = true; HTTPAPI_CorsOrigins_value = value; } }
        private StringList HTTPAPI_CorsOrigins_value;
        private bool HTTPAPI_CorsOrigins_changed;
        public bool ShouldSerializeHTTPAPI_CorsOrigins() { return (HTTPAPI_CorsOrigins_changed | HTTPAPI_CorsOrigins_value.Changed); }

        [JsonProperty("HTTPAPI_EnableV1")]
        public bool HTTPAPI_EnableV1 { get { return HTTPAPI_EnableV1_value; } set { HTTPAPI_EnableV1_changed = true; HTTPAPI_EnableV1_value = value; } }
        private bool HTTPAPI_EnableV1_value;
        private bool HTTPAPI_EnableV1_changed;
        public bool ShouldSerializeHTTPAPI_EnableV1() { return HTTPAPI_EnableV1_changed; }

        [JsonProperty("Log_Details_Records")]
        public bool Log_Details_Records { get { return Log_Details_Records_value; } set { Log_Details_Records_changed = true; Log_Details_Records_value = value; } }
        private bool Log_Details_Records_value;
        private bool Log_Details_Records_changed;
        public bool ShouldSerializeLog_Details_Records() { return Log_Details_Records_changed; }

        [JsonProperty("Log_Details_EDNS0")]
        public bool Log_Details_EDNS0 { get { return Log_Details_EDNS0_value; } set { Log_Details_EDNS0_changed = true; Log_Details_EDNS0_value = value; } }
        private bool Log_Details_EDNS0_value;
        private bool Log_Details_EDNS0_changed;
        public bool ShouldSerializeLog_Details_EDNS0() { return Log_Details_EDNS0_changed; }

        [JsonProperty("Log_Details_Outgoing")]
        public bool Log_Details_Outgoing { get { return Log_Details_Outgoing_value; } set { Log_Details_Outgoing_changed = true; Log_Details_Outgoing_value = value; } }
        private bool Log_Details_Outgoing_value;
        private bool Log_Details_Outgoing_changed;
        public bool ShouldSerializeLog_Details_Outgoing() { return Log_Details_Outgoing_changed; }

        [JsonProperty("Log_Details_Blocked")]
        public bool Log_Details_Blocked { get { return Log_Details_Blocked_value; } set { Log_Details_Blocked_changed = true; Log_Details_Blocked_value = value; } }
        private bool Log_Details_Blocked_value;
        private bool Log_Details_Blocked_changed;
        public bool ShouldSerializeLog_Details_Blocked() { return Log_Details_Blocked_changed; }

        [JsonProperty("Log_Details_OnlyErrors")]
        public bool Log_Details_OnlyErrors { get { return Log_Details_OnlyErrors_value; } set { Log_Details_OnlyErrors_changed = true; Log_Details_OnlyErrors_value = value; } }
        private bool Log_Details_OnlyErrors_value;
        private bool Log_Details_OnlyErrors_changed;
        public bool ShouldSerializeLog_Details_OnlyErrors() { return Log_Details_OnlyErrors_changed; }

        [JsonProperty("Log_Details_IDNNative")]
        public bool Log_Details_IDNNative { get { return Log_Details_IDNNative_value; } set { Log_Details_IDNNative_changed = true; Log_Details_IDNNative_value = value; } }
        private bool Log_Details_IDNNative_value;
        private bool Log_Details_IDNNative_changed;
        public bool ShouldSerializeLog_Details_IDNNative() { return Log_Details_IDNNative_changed; }

        [JsonProperty("Log_Files_Begin")]
        public string Log_Files_Begin { get { return Log_Files_Begin_value; } set { Log_Files_Begin_changed = true; Log_Files_Begin_value = value; } }
        private string Log_Files_Begin_value;
        private bool Log_Files_Begin_changed;
        public bool ShouldSerializeLog_Files_Begin() { return Log_Files_Begin_changed; }

        [JsonProperty("Log_Files_Recycle")]
        public string Log_Files_Recycle { get { return Log_Files_Recycle_value; } set { Log_Files_Recycle_changed = true; Log_Files_Recycle_value = value; } }
        private string Log_Files_Recycle_value;
        private bool Log_Files_Recycle_changed;
        public bool ShouldSerializeLog_Files_Recycle() { return Log_Files_Recycle_changed; }

        [JsonProperty("Log_Files_Raw")]
        public bool Log_Files_Raw { get { return Log_Files_Raw_value; } set { Log_Files_Raw_changed = true; Log_Files_Raw_value = value; } }
        private bool Log_Files_Raw_value;
        private bool Log_Files_Raw_changed;
        public bool ShouldSerializeLog_Files_Raw() { return Log_Files_Raw_changed; }

        [JsonProperty("Log_Files_HttpFullReq")]
        public bool Log_Files_HttpFullReq { get { return Log_Files_HttpFullReq_value; } set { Log_Files_HttpFullReq_changed = true; Log_Files_HttpFullReq_value = value; } }
        private bool Log_Files_HttpFullReq_value;
        private bool Log_Files_HttpFullReq_changed;
        public bool ShouldSerializeLog_Files_HttpFullReq() { return Log_Files_HttpFullReq_changed; }

        [JsonProperty("Log_Files_Path")]
        public string Log_Files_Path { get { return Log_Files_Path_value; } set { Log_Files_Path_changed = true; Log_Files_Path_value = value; } }
        private string Log_Files_Path_value;
        private bool Log_Files_Path_changed;
        public bool ShouldSerializeLog_Files_Path() { return Log_Files_Path_changed; }

        [JsonProperty("Log_Syslog_Enable")]
        public bool Log_Syslog_Enable { get { return Log_Syslog_Enable_value; } set { Log_Syslog_Enable_changed = true; Log_Syslog_Enable_value = value; } }
        private bool Log_Syslog_Enable_value;
        private bool Log_Syslog_Enable_changed;
        public bool ShouldSerializeLog_Syslog_Enable() { return Log_Syslog_Enable_changed; }

        [JsonProperty("Log_Syslog_IP")]
        public IPAddress Log_Syslog_IP { get { return Log_Syslog_IP_value; } set { Log_Syslog_IP_changed = true; Log_Syslog_IP_value = value; } }
        private IPAddress Log_Syslog_IP_value;
        private bool Log_Syslog_IP_changed;
        public bool ShouldSerializeLog_Syslog_IP() { return Log_Syslog_IP_changed; }

        [JsonProperty("Log_Syslog_Port")]
        public ushort Log_Syslog_Port { get { return Log_Syslog_Port_value; } set { Log_Syslog_Port_changed = true; Log_Syslog_Port_value = value; } }
        private ushort Log_Syslog_Port_value;
        private bool Log_Syslog_Port_changed;
        public bool ShouldSerializeLog_Syslog_Port() { return Log_Syslog_Port_changed; }

        [JsonProperty("Log_ActiveLog_Lines")]
        public ushort Log_ActiveLog_Lines { get { return Log_ActiveLog_Lines_value; } set { Log_ActiveLog_Lines_changed = true; Log_ActiveLog_Lines_value = value; } }
        private ushort Log_ActiveLog_Lines_value;
        private bool Log_ActiveLog_Lines_changed;
        public bool ShouldSerializeLog_ActiveLog_Lines() { return Log_ActiveLog_Lines_changed; }

        [JsonProperty("Log_ActiveLog_Buffer")]
        public bool Log_ActiveLog_Buffer { get { return Log_ActiveLog_Buffer_value; } set { Log_ActiveLog_Buffer_changed = true; Log_ActiveLog_Buffer_value = value; } }
        private bool Log_ActiveLog_Buffer_value;
        private bool Log_ActiveLog_Buffer_changed;
        public bool ShouldSerializeLog_ActiveLog_Buffer() { return Log_ActiveLog_Buffer_changed; }

        [JsonProperty("Log_WinEvents_Enable")]
        public bool Log_WinEvents_Enable { get { return Log_WinEvents_Enable_value; } set { Log_WinEvents_Enable_changed = true; Log_WinEvents_Enable_value = value; } }
        private bool Log_WinEvents_Enable_value;
        private bool Log_WinEvents_Enable_changed;
        public bool ShouldSerializeLog_WinEvents_Enable() { return Log_WinEvents_Enable_changed; }

        [JsonProperty("Log_WinEvents_Exclude")]
        public WindowsEventsList Log_WinEvents_Exclude { get { return Log_WinEvents_Exclude_value; } set { Log_WinEvents_Exclude_changed = true; Log_WinEvents_Exclude_value = value; } }
        private WindowsEventsList Log_WinEvents_Exclude_value;
        private bool Log_WinEvents_Exclude_changed;
        public bool ShouldSerializeLog_WinEvents_Exclude() { return (Log_WinEvents_Exclude_changed | Log_WinEvents_Exclude_value.Changed); }

        [JsonProperty("Remote_Enable")]
        public bool Remote_Enable { get { return Remote_Enable_value; } set { Remote_Enable_changed = true; Remote_Enable_value = value; } }
        private bool Remote_Enable_value;
        private bool Remote_Enable_changed;
        public bool ShouldSerializeRemote_Enable() { return Remote_Enable_changed; }

        [JsonProperty("Remote_Port")]
        public ushort Remote_Port { get { return Remote_Port_value; } set { Remote_Port_changed = true; Remote_Port_value = value; } }
        private ushort Remote_Port_value;
        private bool Remote_Port_changed;
        public bool ShouldSerializeRemote_Port() { return Remote_Port_changed; }

        [JsonProperty("Remote_Password")]
        public string Remote_Password { get { return Remote_Password_value; } set { Remote_Password_changed = true; Remote_Password_value = value; } }
        private string Remote_Password_value;
        private bool Remote_Password_changed;
        public bool ShouldSerializeRemote_Password() { return Remote_Password_changed; }
    }
}