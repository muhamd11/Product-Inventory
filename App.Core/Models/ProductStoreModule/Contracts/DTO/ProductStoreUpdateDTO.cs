﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Models.ProductModule.Contracts.DTO
{
    public class ProductStoreUpdateDTO : ProductStoreAddDTO
    {
        public int productStoreId { get; set; }

    }
}
