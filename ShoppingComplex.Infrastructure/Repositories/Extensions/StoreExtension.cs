using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Extensions
{
    internal static class StoreExtension
    {
        // Search by StoreName
        public static IQueryable<Store> SearchStore(this IQueryable<Store> stores, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return stores;

            return stores.Where(s => s.StoreName.ToLower().Contains(name.ToLower()));
        }
    }
}
