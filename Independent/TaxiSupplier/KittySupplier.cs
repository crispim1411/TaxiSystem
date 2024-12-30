using Entities;

namespace Supplier;

public class KittySupplier(int id, string name, List<Taxi> initList)
    : TaxiSupplier(id, name, initList);