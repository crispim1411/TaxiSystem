using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using Finder;
using Selector;

namespace TaxiUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Candidate> _taxiList = new();
    private readonly TaxiFinder _finder = TaxiFinder.InitializeWithData();
    private readonly TaxiSelector _selector = TaxiSelector.InitializeWithData();
    
    public MainWindow()
    {
        InitializeComponent();
        LoadTaxiData();
        dgTaxies.ItemsSource = _taxiList;
    }

    private void LoadTaxiData()
    {
        _taxiList = _finder.GetAvailableTaxies();
    }

    private void OnSearchClick(object sender, RoutedEventArgs e)
    {
        string time = (cmbTime.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
        string luxury = (cmbLuxury.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
        string cost = (cmbCost.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

        var filteredTaxies = _taxiList
            .Where(x =>
                (time == "Any" || x.Taxi.Time == time) &&
                (luxury == "Any" || x.Taxi.Luxury == luxury) &&
                (cost == "Any" || x.Taxi.Cost == cost)
            )
            .ToList();

        dgTaxies.ItemsSource = filteredTaxies;
    }

    private void OnDispatchClick(object sender, RoutedEventArgs e) 
    {
        var candidates = dgTaxies.ItemsSource as List<Candidate>;
        var criteria = new Criteria
        {
            Time = MapCriteria((cmbTime.SelectedItem as ComboBoxItem)?.Content),
            Luxury = MapCriteria((cmbLuxury.SelectedItem as ComboBoxItem)?.Content),
            Cost = MapCriteria((cmbCost.SelectedItem as ComboBoxItem)?.Content)
        };
        if (_selector.TryDispatch(candidates, criteria))
        {
            _taxiList = _finder.GetAvailableTaxies();
            dgTaxies.ItemsSource = _taxiList;
        }
    }

    private string? MapCriteria(object? criteria)
    {
        return criteria switch
        {
            "Any" => null,
            null => null,
            _ => criteria.ToString()
        };
    }
}