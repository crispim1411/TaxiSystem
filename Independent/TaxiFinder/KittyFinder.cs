using MockData;
using Supplier;

namespace Finder;

public class KittyFinder(List<TaxiSupplier> suppliers) : TaxiFinder(suppliers)
{
    public static TaxiFinder InitializeWithData() => new KittyFinder(Mock.GetKittySuppliers());
}