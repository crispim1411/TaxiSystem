using Dispatcher;

namespace Selector;

public class KittySelector(TaxiDispatcher dispatcher) : TaxiSelector(dispatcher)
{
    public static TaxiSelector InitializeWithData()
    {
        return new KittySelector(KittyDispatcher.InitializeWithData());
    }
}