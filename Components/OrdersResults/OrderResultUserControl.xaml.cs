﻿using FastFood.Entites.Orders;
using FastFood.Repositories.Orders;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

#pragma warning disable

namespace FastFood.Components.OrdersResults;

/// <summary>
/// Interaction logic for OrderResultUserControl.xaml
/// </summary>
public partial class OrderResultUserControl : UserControl
{
    public Func<long, Task> Refresh { get; set; }
    private Order Order = new();
    private readonly OrderRepository _orderRepository;
    private readonly OrderDetailsRepository _orderDetailRepository;

    public event EventHandler OrderChanged;

    private void NotifyOrderChanged()
    {
        OrderChanged?.Invoke(this, EventArgs.Empty);
    }

    public OrderResultUserControl()
    {
        InitializeComponent();
        this._orderRepository = new();
        this._orderDetailRepository = new();
    }

    private long _productCount;

    public long ProductCount
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

    private async void AddButton_Click(object sender, RoutedEventArgs e)
    {
        ProductCount += 1;
        lblCount.Content = ProductCount;
        await _orderRepository.UpdateQuantityAndResultPriceAsync(
            Order.Id, ProductCount, Order.ProductsPrice * 2);
    }

    private async void lblMinus_Click(object sender, RoutedEventArgs e)
    {
        if (ProductCount > 1)
        {
            ProductCount -= 1;
        }
        lblCount.Content = ProductCount;
        await _orderRepository.UpdateQuantityAndResultPriceAsync(
            Order.Id, ProductCount, Order.ProductsPrice * 2);
    }

    private async void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        // 
    }

    public void SetData(Order order)
    {
        this.Order = order;
        lblOrderName.Content = order.Description;
        lblPrice.Content = order.ResultPrice.ToString() + " $";
        lblCount.Content = order.Quantity.ToString();
        ProductCount = order.Quantity;
    }

    public Order ReturnThisData()
    {
        return this.Order;
    }

    private async void Delete_Button_Click(object sender, RoutedEventArgs e)
    {
        if (await _orderRepository.DeleteAsync(Order.Id) > 0)
        {
            //MessageBox.Show("Successfully");
            //NotifyOrderChanged();

        }
    }
}
