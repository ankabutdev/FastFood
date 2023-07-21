using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Common;

public interface ISearchable<TModel>
{
    public Task<(int ItemCount, IList<TModel>)> SearchAsync(string search);
}
