using Entities;

namespace Supplier;

public class TaxiSupplier(int id, string name, List<Taxi> initList)
{
    public int Id { get; } = id;
    public string Name { get; } = name;

    public List<Taxi> GetAvailableTaxies => initList.Where(x => x.isAvailable).ToList();

    public bool TryOrderTaxi(int id) 
    {
        var taxi = initList.FirstOrDefault(x => x.Id == id);
        if (taxi == null) 
            return false;
        
        taxi.isAvailable = false;
        return true;
    }

    public bool TryFinish(int id) 
    {
        var taxi = initList.FirstOrDefault(x => x.Id == id);
        if (taxi == null) 
            return false;
        
        taxi.isAvailable = true;
        return true;
    }
}
