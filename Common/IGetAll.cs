﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFood.Common;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync();
}
