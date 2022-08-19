# SimpleDNS.NET - SimpleDNS REST Client
The SimpleDNS REST Client is designed to abstract the SimpleDNS HTTP API and present the developer with a simplified and strongly typed implementation. Much of the underlying mechanics have therefore purposefully been abstracted behind private modifiers.

## Dependencies
Both [RestSharp](https://github.com/restsharp/RestSharp) and [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) are required dependencies.

## Compatibility
The client has been tested up to [version 8 build 108](https://simpledns.plus/news/78/simple-dns-plus-v-8-0-build-108-released-dns-flag-day-update) of SimpleDNS. [Version 9](https://simpledns.plus/news/79/simple-dns-plus-v-9-0-released) brings breaking changes which may prevent the client from retrieving or updating SimpleDNS settings.

## Quick Start

### Creating an instance of the client
```csharp
string adminUrl = "https://localhost/v2";
string adminUsername = "admin";
string adminPassword = "password";
SimpleDnsManager simpleDns = new SimpleDnsManager(
    adminUrl, AuthenticationMode.Digest,
    adminUsername, adminPassword, true);
```

### Create an A record
```csharp
string zoneDomain = "domain.text";
string recordFqdn = "www.domain.text";
string recordIpAddress = "198.51.100.3";
simpleDns.PatchZoneRecords(zoneDomain, new List<ZoneRecord> {
    new ZoneRecord {
        Name = recordFqdn,
        Type = RecordType.A,
        Data = recordIpAddress,
        Ttl = 14400 }
});
```

### Delete an A record if it exists
```csharp
string zoneDomain = "domain.text";
string recordFqdn = "www.domain.text";
List<ZoneRecord> zoneRecords = simpleDns.GetZoneRecords(zoneDomain);
ZoneRecord zoneRecord = zoneRecords.Find(z => z.Name == recordFqdn);
if (zoneRecord != null)
    simpleDns.PatchZoneRecords(zoneDomain, new List<ZoneRecord> {
        new ZoneRecord {
            Name = recordFqdn,
            Remove = true }
    });
```

### Change SimpleDNS settings
```csharp
var options = simpleDns.GetOptions();
options.DnsCacheReload = false;
simpleDns.PatchOptions(options);
```
