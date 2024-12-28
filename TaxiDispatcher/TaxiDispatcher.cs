using Entities;
using MockData;
using Supplier;

namespace Dispatcher;

public class TaxiDispatcher 
{
    private List<TaxiSupplier> _suppliers;

    public static TaxiDispatcher InitializeWithData() => new TaxiDispatcher(Mock.GetSuppliers());

    public TaxiDispatcher(List<TaxiSupplier> suppliers) 
    {
        _suppliers = suppliers;
    }

    public bool TryOrderTaxi(int taxiId, int supplierId) 
    {
        var supplier = _suppliers.Where(x => x.Id == supplierId).FirstOrDefault();
        if (supplier == null) 
            return false;
        return supplier.TryOrderTaxi(taxiId);
    }
}
