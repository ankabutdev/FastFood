using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

//#pragma warning disable

namespace FastFood.Components;

/// <summary>
/// Interaction logic for PlusMinusViewUserControl.xaml
/// </summary>
public partial class PlusMinusViewUserControl : UserControl
{
    private int _productCount;

    public int ProductCount
    {
        get { return _productCount; }
        set
        {
            if (_productCount != value)
            {
                _productCount = value;
                OnPropertyChanged(nameof(ProductCount));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        ProductCount++;
    }

    private void lblMinus_Click(object sender, RoutedEventArgs e)
    {
        if (ProductCount > 0)
        {
            ProductCount--;
        }
    }
    public PlusMinusViewUserControl()
    {
        InitializeComponent();
        DataContext = this;
    }

    
}
