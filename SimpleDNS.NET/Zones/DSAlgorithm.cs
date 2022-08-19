namespace SimpleDNS.Zones;

public enum DsAlgorithm : byte
{
    Rsamd5 = 1,
    DiffieHellman = 2,
    Dsasha1 = 3,
    EllipticCurve = 4,
    Rsasha1 = 5,
    Dsasha1Nsec3 = 6,
    Rsasha1Nsec3 = 7,
    Rsasha256 = 8,
    Rsasha512 = 10,
    Indirect = 252,
    Private253 = 253,
    Private254 = 254
}