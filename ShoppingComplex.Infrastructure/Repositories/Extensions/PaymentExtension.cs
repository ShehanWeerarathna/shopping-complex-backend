﻿using ShoppingComplex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingComplex.Infrastructure.Repositories.Extensions
{
    internal static class PaymentExtension
    {
        public static IQueryable<LeasePayment> FilterByLeaseAgreementId(this IQueryable<LeasePayment> payments, int? leaseAgreementId)
        {
            if (leaseAgreementId.HasValue && leaseAgreementId != 0)
                return payments.Where(p => p.LeaseAgreementId == leaseAgreementId);

            return payments;
        }
    }
}
