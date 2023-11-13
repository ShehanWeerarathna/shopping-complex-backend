using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Extensions
{
    internal static class LeaseAgreementExtension
    {
            public static IQueryable<LeaseAgreement> FilterLeaseAgreementByStoreId(this IQueryable<LeaseAgreement> leaseAgreements, int? storeId)
            {
                if (storeId.HasValue && storeId != 0)
                    return leaseAgreements.Where(l => l.StoreId == storeId);

                return leaseAgreements;
            }
    }
}
