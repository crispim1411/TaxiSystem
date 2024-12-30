using Entities;
using MockData;
using Supplier;

namespace Finder;

public class TaxiFinder(List<TaxiSupplier> suppliers)
{
    public static TaxiFinder InitializeWithData() => new TaxiFinder(Mock.GetSuppliers());

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