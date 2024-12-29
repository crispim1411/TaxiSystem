using Entities;

namespace Supplier;

public class TaxiSupplier 
{
    private List<Taxi> _taxies = new();
    public int Id { get; }
    public string Name { get; }

    public List<Taxi> GetAvailableTaxies => _taxies.Where(x => x.isAvailable).ToList();
    
    public TaxiSupplier(int id, string name, List<Taxi> initList) 
    {
        Id = id;
        Name = name;
        _taxies = initList;
    }

    public bool TryOrderTaxi(int Id) 
    {
        var taxi = _taxies.Where(x => x.Id == Id).FirstOrDefault();
        if (taxi != null) {
            taxi.isAvailable = false;
            return true;
        }
        return false;
    }

    public bool TryFinish(int Id) 
    {
        var taxi = _taxies.Where(x => x.Id == Id).FirstOrDefault();
        if (taxi != null) {
            taxi.isAvailable = true;
            return true;
        }
        return false;
    }
}
