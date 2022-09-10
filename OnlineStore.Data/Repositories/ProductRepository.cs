﻿using OnlineStore.Data.IRepositories;
using OnlineStore.Data.Repositories.BaseRepositories;
using OnlineStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
    }
}
