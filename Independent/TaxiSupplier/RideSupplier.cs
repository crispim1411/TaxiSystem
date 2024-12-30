using Entities;

namespace Supplier;

public class RideSupplier(int id, string name, List<Taxi> initList)
    : TaxiSupplier(id, name, initList);