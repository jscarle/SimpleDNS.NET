using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SimpleDNS.Zones
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecordType
    {
        A,
        AAAA,
        AFSDB,
        ALIAS,
        ATMA,
        CAA,
        CERT,
        CNAME,
        DNAME,
        DS,
        HINFO,
        ISDN,
        LOC,
        MB,
        MG,
        MINFO,
        MR,
        MX,
        NAPTR,
        NS,
        NSAP,
        PTR,
        RP,
        RT,
        SOA,
        SRV,
        TLSA,
        TXT,
        Unknown,
        X25
    }
}
