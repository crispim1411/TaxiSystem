using MockData;
using Supplier;

namespace Dispatcher;

public class RideDispatcher(List<TaxiSupplier> suppliers) : TaxiDispatcher(suppliers)
{
    public static TaxiDispatcher InitializeWithData() => new RideDispatcher(Mock.GetRideSuppliers());
}