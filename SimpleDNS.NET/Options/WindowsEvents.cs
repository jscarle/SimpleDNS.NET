namespace SimpleDNS.Options
{
    public enum WindowsEvents : ushort
    {
        BindErrorForDNS = 101,
        BindErrorForHTTPAPI = 103,
        BindErrorForRemoteManagement = 105,
        DNSSECSigningFailure = 801,
        IPAddressBlocked = 302,
        LameDelegation = 401,
        LogFileOpenFailure = 701,
        LogFileWriteFailure = 702,
        OpenDNSWarning = 140,
        PlugInLoadError = 251,
        PlugInMethodError = 257,
        PlugInOperationError = 258,
        PlugInThreadError = 259,
        RawLogFileOpenFailure = 703,
        RawLogFileWriteFailure = 704,
        RecursionFailure = 601,
        RequestForBINDVersion = 303,
        ServerPaused = 2,
        ServerShutdown = 3,
        ServerStarted = 1,
        TCPDNSError = 311,
        TCPDNSIgnored = 305,
        ZoneFileOpenFailure = 201,
        ZoneFileSaveFailure = 203,
        ZoneNotifyRequestFailure = 501,
        ZoneNotifyResponseFailure = 502,
        ZoneRefreshFailure = 310,
        ZoneTransferConflict = 504,
        ZoneTransferFailure = 503
    }
}
