using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Domain.DTOs.RequestDtos
{
    public class PagedDataRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

    }
}
