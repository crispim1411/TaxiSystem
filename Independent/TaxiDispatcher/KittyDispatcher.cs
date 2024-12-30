using MockData;
using Supplier;

namespace Dispatcher;

public class KittyDispatcher(List<TaxiSupplier> suppliers) : TaxiDispatcher(suppliers)
{
    public static TaxiDispatcher InitializeWithData() => new KittyDispatcher(Mock.GetKittySuppliers());
}