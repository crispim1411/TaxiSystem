using Entities;
using Supplier;

namespace Finder;

public abstract class TaxiFinder(List<TaxiSupplier> suppliers)
{
    public List<Candidate> GetAvailableTaxies()
    {
        return suppliers
            .SelectMany(x => x.GetAvailableTaxies
                .Select(y => new Candidate 
                {
                    Taxi = y, 
                    SupplierId = x.Id
                }))
            .ToList();
    }
}