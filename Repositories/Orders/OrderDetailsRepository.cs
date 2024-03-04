using Dapper;
using FastFood.Entites.Orders;
using FastFood.Helpers;
using FastFood.Interfaces.Orders;
using FastFood.ViewModels.Baskets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Repositories.Orders;

public class OrderDetailsRepository : BaseRepository, IOrderRepositoryDetails
{
    public Task<long> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(OrderDetail entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.order_details(order_id, product_id, quantity, total_price, " +
                "discount_price, result_price, created_at, updated_at, user_id) VALUES (@OrderId, @ProductId, @Quantity, " +
                "@TotalPrice, @DiscountPrice, @ResultPrice, @CreatedAt, @UpdatedAt, @UserId);";

            var result = await _connection.ExecuteAsync(query, entity);
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

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<OrderDetail>> GetAllAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<IList<BasketViewModel>> GetBasketAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT *" +
                            $"FROM orders " +
                            $"FULL JOIN order_details " +
                            $"ON orders.id = order_details.id;";

            var result = (await _connection.QueryAsync<BasketViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<BasketViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<OrderDetail> GetProductByIdAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<OrderDetail>> SearchAsync(string search)
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, OrderDetail entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.order_details SET order_id=@OrderId, user_id=@UserId, product_id=@ProductId, " +
                "quantity=@Quantity, total_price=@TotalPrice, discount_price=@DiscountPrice, " +
                "result_price=@ResultPrice, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id = {id};";

            var result = await _connection.ExecuteAsync(query, entity);
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

    public async Task<bool> UpdateQuantityAsync(long id, long orderQuantity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.order_details SET " +
                $"quantity={orderQuantity} " +
                $"WHERE id = {id};";

            var result = await _connection.ExecuteAsync(query);
            return result > 0;
        }
        catch
        {
            return false;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
