using FastFood.Entites.Orders;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastFood.Components.Baskets;

/// <summary>
/// Interaction logic for BasketUserControl.xaml
/// </summary>
public partial class BasketUserControl : UserControl
{
    public long Id { get; set; }

    public BasketUserControl()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    public async Task RefreshAsync()
    {

    }

    public void SetData(Order order)
    {
        Id = order.Id;
        orderName.Content = order.Description.ToString();
        lblOrderPrice.Content = order.ProductsPrice.ToString() + " $";
        //lblOrderQuantity.Content = order

        /*
            SELECT orders.id as order_id, orders.user_id, order_details.id as order_details_id
            FROM orders
            FULL JOIN order_details 
            ON orders.id=order_details.order_id;
         */

        /*
        SELECT *
        FROM orders
        FULL JOIN order_details ON orders.id = order_details.id;

         */
    }
}
