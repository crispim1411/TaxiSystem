using Entities;
using Supplier;

namespace MockData;

public static class Mock
{
    private static Dictionary<int, List<Taxi>> _taxiesBySupplier = new()
    {
        {
            1, new()
            {
                new Taxi { Id = 1, Car = "Car 1", Cost = "Low", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 2, Car = "Car 2", Cost = "Medium", Time = "Low", Luxury = "Medium" },
                new Taxi { Id = 3, Car = "Car 3", Cost = "High", Time = "High", Luxury = "Medium" },
            }
        },
        {
            2, new()
            {
                new Taxi { Id = 4, Car = "Car 4", Cost = "Medium", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 5, Car = "Car 5", Cost = "Medium", Time = "Low", Luxury = "Medium"  },
                new Taxi { Id = 6, Car = "Car 6", Cost = "Medium", Time = "High", Luxury = "Medium" },
            }
        }, 
        { 
            3, new() 
            {
                new Taxi { Id = 7, Car = "Car 7", Cost = "High", Time = "Low", Luxury = "High" },
                new Taxi { Id = 8, Car = "Car 8", Cost = "Medium", Time = "Medium", Luxury = "Medium" },
                new Taxi { Id = 9, Car = "Car 9", Cost = "High", Time = "High", Luxury = "High" },
            }
        }
    };

    // public static List<Taxi> GetTaxies(int id)
    // {
    //     return _taxiesBySupplier.TryGetValue(id, out var taxies)
    //         ? taxies
    //         : [];
    // }

    public static List<TaxiSupplier> GetSuppliers() 
    { 
        return new() 
        {
            new(1, "Supplier 1", _taxiesBySupplier[1]),
            new(2, "Supplier 2", _taxiesBySupplier[2]),
            new(3, "Supplier 3", _taxiesBySupplier[3]),
        };
    }
}
