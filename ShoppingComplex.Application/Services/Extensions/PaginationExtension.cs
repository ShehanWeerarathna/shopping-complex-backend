using ShoppingComplex.Domain.DTOs.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Application.Services.Extensions
{
    public static class PaginationExtension
    {
        public static PagedDataResponse<T> GetPaged<T>(this IEnumerable<T> query, int? page, int? pageSize)
        {
            var pagedDataRespone = new PagedDataResponse<T>();
            pagedDataRespone.PageSize = pageSize ?? 10;
            pagedDataRespone.CurrentPage = page ?? 1;
            pagedDataRespone.TotalItemsCount = query.Count();

            var skip = (pagedDataRespone.CurrentPage - 1) * pagedDataRespone.PageSize;
            pagedDataRespone.PagedData = query.Skip(skip).Take(pagedDataRespone.PageSize).ToList();

            return pagedDataRespone;
        }
    }
}
