using Supplier;

namespace Dispatcher;

public abstract class TaxiDispatcher(List<TaxiSupplier> suppliers)
{
    public bool TryOrderTaxi(int taxiId, int supplierId) 
    {
        var supplier = suppliers.FirstOrDefault(x => x.Id == supplierId);
        return supplier != null && supplier.TryOrderTaxi(taxiId);
    }
}
