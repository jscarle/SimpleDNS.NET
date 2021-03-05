namespace SimpleDNS.Zones
{
    public enum DSAlgorithm : byte
    {
        RSAMD5 = 1,
        DiffieHellman = 2,
        DSASHA1 = 3,
        EllipticCurve = 4,
        RSASHA1 = 5,
        DSASHA1NSEC3 = 6,
        RSASHA1NSEC3 = 7,
        RSASHA256 = 8,
        RSASHA512 = 10,
        Indirect = 252,
        Private253 = 253,
        Private254 = 254
    }
}
