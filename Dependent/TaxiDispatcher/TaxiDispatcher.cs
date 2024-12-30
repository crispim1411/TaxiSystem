using MockData;
using Supplier;

namespace Dispatcher;

public class TaxiDispatcher(List<TaxiSupplier> suppliers)
{
    public static TaxiDispatcher InitializeWithData() => new TaxiDispatcher(Mock.GetSuppliers());

    public bool TryOrderTaxi(int taxiId, int supplierId) 
    {
        var supplier = suppliers.FirstOrDefault(x => x.Id == supplierId);
        return supplier != null && supplier.TryOrderTaxi(taxiId);
    }
}
