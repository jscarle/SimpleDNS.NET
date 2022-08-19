namespace SimpleDNS.Options;

public enum UdpProcessingMode : byte
{
    Normal = 0,
    Ignore = 1,
    ForceTcp = 2
}