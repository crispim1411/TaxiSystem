using System.Windows;
using Entities;
using Finder;
using Selector;

namespace TaxiUI;

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
    private List<Candidate> _taxiList = [];
    private readonly TaxiFinder _finder = TaxiFinder.InitializeWithData();
    private readonly TaxiSelector _selector = TaxiSelector.InitializeWithData();
    
    public MainWindow()
    {
        InitializeComponent();
        InitCombos();
        _taxiList = _finder.GetAvailableTaxies();
        dgTaxies.ItemsSource = _taxiList;
    }
    
    private void InitCombos()
    {
        var filterOptions = Enum.GetValues(typeof(FilterType));
        cmbTime.ItemsSource = filterOptions;
        cmbLuxury.ItemsSource = filterOptions;
        cmbCost.ItemsSource = filterOptions;
        
        cmbTime.SelectedItem = FilterType.Any;
        cmbLuxury.SelectedItem = FilterType.Any;
        cmbCost.SelectedItem = FilterType.Any;
    }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        var filteredTaxies = _taxiList
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
        
        if (_selector.TryDispatch(candidates, criteria))
        {
            _taxiList = _finder.GetAvailableTaxies();
            dgTaxies.ItemsSource = _taxiList
                .Where(x =>
                    (cmbTime.SelectedItem is FilterType.Any || x.Taxi.Time == cmbTime.SelectedItem?.ToString()) 
                    && (cmbLuxury.SelectedItem is FilterType.Any  || x.Taxi.Luxury == cmbLuxury.SelectedItem?.ToString()) 
                    && (cmbCost.SelectedItem is FilterType.Any || x.Taxi.Cost == cmbCost.SelectedItem?.ToString())
                )
                .ToList();
        }
    }
}