using Dapper;
using FastFood.Entites.Orders;
using FastFood.Interfaces.Orders;
using FastFood.ViewModels.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Repositories.Orders;

public partial class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM public.orders;";
            var result = (await _connection.QueryAsync<long>(query)).FirstOrDefault();
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Order entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.orders(user_id, delivery_id, status, products_price, delivery_price, " +
                "result_price, latitude, longitude, payment_type, is_paid, description, created_at, updated_at) " +
                "VALUES (@UserId, @DeliveryId, @Status, @ProductsPrice, @DeliveryPrice, @ResultPrice, @Latitude, " +
                "@Longitude, @PaymentType, @IsPaid, @Description, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateOrderWithIsPaidTrueAsync(Order order, long orderId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.orders " +
                $"SET status=?, payment_type=@PaymentType, is_paid=@IsPaid, updated_at=@UpdatedAt " +
                $"WHERE id={orderId};";

            var result = await _connection.ExecuteAsync(query, order);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM orders WHERE id={id}";
            var result = await _connection.ExecuteAsync(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Order>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM orders ORDER BY id DESC";
            var result = (await _connection.QueryAsync<Order>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Order>> GetAllOrderByUserIdByIsPaidFalseAsync(long userId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM orders WHERE user_id = {userId} AND is_paid = 'false';";
            var result = (await _connection.QueryAsync<Order>(query)).AsList();
            return result;

        }
        catch
        {
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IQueryable<Order>> GetAllOrderByUserIdByIsPaidTrueAsync(long userId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<OrderViewModel> GetProductByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM Products WHERE Id = @Id";
            var parameters = new { Id = id };

            OrderViewModel product = await _connection.QueryFirstOrDefaultAsync<OrderViewModel>(query, parameters);
            return product;

        }
        catch
        {
            return new OrderViewModel();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<OrderViewModel>> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Order entity)
    {
        throw new System.NotImplementedException();
    }
}
