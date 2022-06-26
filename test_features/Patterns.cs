using System.Collections.Generic;

namespace test_features;

public class Singleton
{
    static private Singleton context;

    static public Singleton GetContext()
    {
        if (context is null) context = new();
        return context;
    }
}

class Repository<T>
{
    static private Repository<T> context;

    public Repository<T> Context => context;
    protected Repository() { }

    static public Repository<T> GetContext()
    {
        if (context is null) context = new();
        return context;
    }

    private List<T> data;

    public T[] Data => data.ToArray();

    public void AddData(T item) => data.Add(item);
}
class Fabric
{
    private Repository<int> repository;
    public Fabric()
    {

    }
}