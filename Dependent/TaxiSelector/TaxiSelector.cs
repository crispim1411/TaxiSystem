using Dispatcher;
using Entities;

namespace Selector;

public class TaxiSelector(TaxiDispatcher dispatcher)
{
    public static TaxiSelector InitializeWithData() => new TaxiSelector(TaxiDispatcher.InitializeWithData());

    public bool TryDispatch(List<Candidate> candidates, Criteria criteria) 
    {
        var result = candidates
            .FirstOrDefault(x => 
                (string.IsNullOrEmpty(criteria.Cost) || criteria.Cost == x.Taxi.Cost)
                && (string.IsNullOrEmpty(criteria.Time) || criteria.Time == x.Taxi.Time)
                && (string.IsNullOrEmpty(criteria.Luxury) || criteria.Luxury == x.Taxi.Luxury)); 
            
        return result != null && dispatcher.TryOrderTaxi(result.Taxi.Id, result.SupplierId);
    }

    
}