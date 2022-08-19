namespace SimpleDNS.Options;

public interface ICommittable
{
    bool Changed { get; }

    void Commit();
}