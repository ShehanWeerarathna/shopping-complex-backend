﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs.ResponseDtos
{
    public class PagedDataResponse<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public List<T> PagedData { get; set; } 
    }
}
