﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public class IProductRepository
    {
        List<Product> GetAllProductByCategoryId(int categoryId);
    }
}
