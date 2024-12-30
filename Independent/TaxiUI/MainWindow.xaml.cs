using System.Windows;
using System.Windows.Controls;
using Entities;
using Finder;
using Selector;

namespace TaxiUI;

public enum DeliveryType
{
    TaxiRide,
    KittyDelivery,
}

public enum FilterType
{
    Any,
    Low,
    Medium,
    High,
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Candidate> _taxiListRide = [];
    private List<Candidate> _taxiListKitty = [];
    private readonly TaxiFinder _rideFinder = RideFinder.InitializeWithData();
    private readonly TaxiFinder _kittyFinder = KittyFinder.InitializeWithData();
    private readonly TaxiSelector _rideSelector = RideSelector.InitializeWithData();
    private readonly TaxiSelector _kittySelector = KittySelector.InitializeWithData();
    
    public MainWindow()
    {
        InitializeComponent();
        InitCombos();
        UpdateList();
    }

    private void InitCombos()
    {
        cmbDelivery.ItemsSource = Enum.GetValues(typeof(DeliveryType));
        cmbDelivery.SelectedItem = DeliveryType.TaxiRide;
        
        var filterOptions = Enum.GetValues(typeof(FilterType));
        cmbTime.ItemsSource = filterOptions;
        cmbLuxury.ItemsSource = filterOptions;
        cmbCost.ItemsSource = filterOptions;
        
        cmbTime.SelectedItem = FilterType.Any;
        cmbLuxury.SelectedItem = FilterType.Any;
        cmbCost.SelectedItem = FilterType.Any;
    }
    
    private List<Candidate> GetActiveList()
    {
        return cmbDelivery.SelectedItem is DeliveryType.TaxiRide
            ? _taxiListRide 
            : _taxiListKitty;
    }

    private TaxiSelector GetSelector()
    {
        return cmbDelivery.SelectedItem is DeliveryType.TaxiRide
            ? _rideSelector
            : _kittySelector;
    }

    private TaxiFinder GetFinder()
    {
        return cmbDelivery.SelectedItem is DeliveryType.TaxiRide
            ? _rideFinder
            : _kittyFinder;
    }
    
    private void OnDeliverySelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (dgTaxies == null) return;
        UpdateList();
    }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        var filteredTaxies = GetActiveList()
            .Where(x =>
                (cmbTime.SelectedItem is FilterType.Any || x.Taxi.Time == cmbTime.SelectedItem?.ToString()) 
                && (cmbLuxury.SelectedItem is FilterType.Any  || x.Taxi.Luxury == cmbLuxury.SelectedItem?.ToString()) 
                && (cmbCost.SelectedItem is FilterType.Any || x.Taxi.Cost == cmbCost.SelectedItem?.ToString())
            )
            .ToList();

        dgTaxies.ItemsSource = filteredTaxies;
    }

    private void OnDispatchClick(object sender, RoutedEventArgs e) 
    {
        var candidates = dgTaxies.ItemsSource as List<Candidate> ?? [];
        var criteria = new Criteria
        {
            Time = cmbTime.SelectedItem is FilterType.Any 
                ? null 
                : cmbTime.SelectedItem?.ToString() ?? string.Empty,
            Luxury = cmbLuxury.SelectedItem is FilterType.Any 
                ? null 
                : cmbLuxury.SelectedItem?.ToString() ?? string.Empty,
            Cost = cmbCost.SelectedItem is FilterType.Any 
                ? null 
                : cmbCost.SelectedItem?.ToString() ?? string.Empty,
        };

        var selector = GetSelector();
        if (selector.TryDispatch(candidates, criteria))
        {
            UpdateList();
        }
    }

    private void UpdateList()
    {
        var finder = GetFinder();
        
        var updatedList = finder.GetAvailableTaxies();
        if (cmbDelivery.SelectedItem is DeliveryType.TaxiRide)
            _taxiListRide = updatedList;
        else
            _taxiListKitty = updatedList;
            
        dgTaxies.ItemsSource = updatedList
            .Where(x =>
                (cmbTime.SelectedItem is FilterType.Any || x.Taxi.Time == cmbTime.SelectedItem?.ToString()) 
                && (cmbLuxury.SelectedItem is FilterType.Any  || x.Taxi.Luxury == cmbLuxury.SelectedItem?.ToString()) 
                && (cmbCost.SelectedItem is FilterType.Any || x.Taxi.Cost == cmbCost.SelectedItem?.ToString())
            )
            .ToList();
    }
}