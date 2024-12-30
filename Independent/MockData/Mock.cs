using Entities;
using Supplier;

namespace MockData;

public static class Mock
{
    private static readonly Dictionary<int, List<Taxi>> _taxiesBySupplier = new()
    {
        {
            1, 
            [
                new Taxi { Id = 1, Car = "Car 1", Cost = "Low", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 2, Car = "Car 2", Cost = "Medium", Time = "Low", Luxury = "Medium" },
                new Taxi { Id = 3, Car = "Car 3", Cost = "High", Time = "High", Luxury = "Medium" },
            ]
        },
        {
            2,
            [
                new Taxi { Id = 4, Car = "Car 4", Cost = "Medium", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 5, Car = "Car 5", Cost = "Medium", Time = "Low", Luxury = "Medium"  },
                new Taxi { Id = 6, Car = "Car 6", Cost = "Medium", Time = "High", Luxury = "Medium" },
            ]
        }, 
        { 
            3, 
            [
                new Taxi { Id = 7, Car = "Car 7", Cost = "High", Time = "Low", Luxury = "High" },
                new Taxi { Id = 8, Car = "Car 8", Cost = "Medium", Time = "Medium", Luxury = "Medium" },
                new Taxi { Id = 9, Car = "Car 9", Cost = "High", Time = "High", Luxury = "High" },
            ]
        },
        {
            4, 
            [
                new Taxi { Id = 10, Car = "Car 10", Cost = "Low", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 11, Car = "Car 11", Cost = "Medium", Time = "Low", Luxury = "Medium" },
                new Taxi { Id = 12, Car = "Car 12", Cost = "High", Time = "High", Luxury = "Medium" },
            ]
        },
        {
            5, 
            [
                new Taxi { Id = 13, Car = "Car 13", Cost = "Medium", Time = "Low", Luxury = "Low" },
                new Taxi { Id = 14, Car = "Car 14", Cost = "Medium", Time = "Low", Luxury = "Medium"  },
                new Taxi { Id = 15, Car = "Car 15", Cost = "Medium", Time = "High", Luxury = "Medium" },
            ]
        }, 
        { 
            6, 
            [
                new Taxi { Id = 16, Car = "Car 16", Cost = "High", Time = "Low", Luxury = "High" },
                new Taxi { Id = 17, Car = "Car 17", Cost = "Medium", Time = "Medium", Luxury = "Medium" },
                new Taxi { Id = 18, Car = "Car 18", Cost = "High", Time = "High", Luxury = "High" },
            ]
        }
    };

    public static List<TaxiSupplier> GetKittySuppliers() 
    { 
        return 
        [
            new KittySupplier(1, "Supplier 1", _taxiesBySupplier[1]),
            new KittySupplier(2, "Supplier 2", _taxiesBySupplier[2]),
            new KittySupplier(3, "Supplier 3", _taxiesBySupplier[3]),
        ];
    }

    public static List<TaxiSupplier> GetRideSuppliers()
    {
        return
        [
            new RideSupplier(4, "Supplier 4", _taxiesBySupplier[4]),
            new RideSupplier(5, "Supplier 5", _taxiesBySupplier[5]),
            new RideSupplier(6, "Supplier 6", _taxiesBySupplier[6]),
        ];
    }
}
