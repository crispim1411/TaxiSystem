using Dispatcher;
using Entities;

namespace Selector;

public abstract class TaxiSelector(TaxiDispatcher dispatcher)
{
    public bool TryDispatch(List<Candidate> candidates, Criteria criteria) 
    {
        var result = candidates
            .FirstOrDefault(x => 
                (string.IsNullOrEmpty(criteria.Cost) || criteria.Cost == x.Taxi.Cost)
                && (string.IsNullOrEmpty(criteria.Time) || criteria.Time == x.Taxi.Time)
                && (string.IsNullOrEmpty(criteria.Luxury) || criteria.Luxury == x.Taxi.Luxury)); 
            
        if (result != null)
            return dispatcher.TryOrderTaxi(result.Taxi.Id, result.SupplierId);
        return false;
    }
}