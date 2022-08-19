namespace SimpleDNS.Options;

public enum WindowsEvents : ushort
{
    BindErrorForDns = 101,
    BindErrorForHttpapi = 103,
    BindErrorForRemoteManagement = 105,
    DnssecSigningFailure = 801,
    IpAddressBlocked = 302,
    LameDelegation = 401,
    LogFileOpenFailure = 701,
    LogFileWriteFailure = 702,
    OpenDnsWarning = 140,
    PlugInLoadError = 251,
    PlugInMethodError = 257,
    PlugInOperationError = 258,
    PlugInThreadError = 259,
    RawLogFileOpenFailure = 703,
    RawLogFileWriteFailure = 704,
    RecursionFailure = 601,
    RequestForBindVersion = 303,
    ServerPaused = 2,
    ServerShutdown = 3,
    ServerStarted = 1,
    TcpdnsError = 311,
    TcpdnsIgnored = 305,
    ZoneFileOpenFailure = 201,
    ZoneFileSaveFailure = 203,
    ZoneNotifyRequestFailure = 501,
    ZoneNotifyResponseFailure = 502,
    ZoneRefreshFailure = 310,
    ZoneTransferConflict = 504,
    ZoneTransferFailure = 503
}