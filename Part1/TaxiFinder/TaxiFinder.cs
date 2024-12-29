using Entities;
using MockData;
using Selector;
using Supplier;

namespace Finder;

public class TaxiFinder 
{
    private readonly List<TaxiSupplier> _suppliers;
    private readonly TaxiSelector _selector;

    public static TaxiFinder InitializeWithData() => new TaxiFinder(Mock.GetSuppliers());

    public TaxiFinder(List<TaxiSupplier> suppliers) 
    {
        _suppliers = suppliers;
    }

    public List<Candidate> GetAvailableTaxies()
    {
        return _suppliers
            .SelectMany(x => x.GetAvailableTaxies
                .Select(y => new Candidate 
                {
                    Taxi = y, 
                    SupplierId = x.Id
                }))
            .ToList();
    }
}