using Dispatcher;

namespace Selector;

public class RideSelector(TaxiDispatcher dispatcher) : TaxiSelector(dispatcher)
{
    public static TaxiSelector InitializeWithData()
    {
        return new RideSelector(RideDispatcher.InitializeWithData());
    }
}