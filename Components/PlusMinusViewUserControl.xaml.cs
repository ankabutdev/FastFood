using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastFood.Components
{
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
            count++;
        }

        private void lblMinus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
