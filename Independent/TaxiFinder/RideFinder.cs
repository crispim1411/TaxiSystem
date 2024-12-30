using MockData;
using Supplier;

namespace Finder;

public class RideFinder(List<TaxiSupplier> suppliers) : TaxiFinder(suppliers)
{
    public static TaxiFinder InitializeWithData() => new RideFinder(Mock.GetRideSuppliers());
}