using FastFood.Common;
using FastFood.Entites.Categories;

namespace FastFood.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>,
    IGetAll<Category>
{
}
