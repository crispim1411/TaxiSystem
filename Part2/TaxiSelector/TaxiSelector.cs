using Dispatcher;
using Entities;
using MockData;

namespace Selector;

public class TaxiSelector 
{
    private TaxiDispatcher _dispatcher;
    
    public static TaxiSelector InitializeWithData() => new TaxiSelector(TaxiDispatcher.InitializeWithData());

    public TaxiSelector(TaxiDispatcher dispatcher) 
    {
        _dispatcher = dispatcher;
    }

    public bool TryDispatch(List<Candidate> candidates, Criteria criteria) 
    {
        var result = candidates
            .Where(x => (string.IsNullOrEmpty(criteria.Cost) || criteria.Cost == x.Taxi.Cost)
                && (string.IsNullOrEmpty(criteria.Time) || criteria.Time == x.Taxi.Time)
                && (string.IsNullOrEmpty(criteria.Luxury) || criteria.Luxury == x.Taxi.Luxury))
            .FirstOrDefault(); 
            
        if (result != null)
            return _dispatcher.TryOrderTaxi(result.Taxi.Id, result.SupplierId);
        return false;
    }

    
}