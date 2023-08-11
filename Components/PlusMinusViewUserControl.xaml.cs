using System.Windows;
using System.Windows.Controls;

namespace FastFood.Components;

/// <summary>
/// Interaction logic for PlusMinusViewUserControl.xaml
/// </summary>
public partial class PlusMinusViewUserControl : UserControl
{
    long count = 1;

    public PlusMinusViewUserControl()
    {
        InitializeComponent();
    }

    private void lblPlus_Click(object sender, RoutedEventArgs e)
    {
        if (count > 1)
        {
            count++;
        }
        else
        {

        }
    }

    private void lblMinus_Click(object sender, RoutedEventArgs e)
    {

    }
}
