using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touring.Models;

namespace Touring.DataAccess
{
    public class PaymentsConfig : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.Property(p => p.MoneyIn).HasColumnType("decimal(10,2)");
            builder.Property(p => p.MoneyOut).HasColumnType("decimal(10,2)");
            
        }
    }

    public class TourBookConfig : IEntityTypeConfiguration<TourBook>
    {
        public void Configure(EntityTypeBuilder<TourBook> builder)
        {
            builder.Property(p => p.TotalPrice).HasColumnType("decimal(10,2)");
            builder.Property(p => p.discountAmmount).HasColumnType("decimal(10,2)");
        }
    }

    public class DiscountConfig : IEntityTypeConfiguration<Discounts>
    {
        public void Configure(EntityTypeBuilder<Discounts> builder)
        {
            builder.Property(p => p.DiscountAmount).HasColumnType("decimal(10,2)");
        }

    }

    public class TourHeaderConfig : IEntityTypeConfiguration<TourHeader>
    {
        public void Configure(EntityTypeBuilder<TourHeader> builder)
        {
            builder.Property(p => p.CalculatedCosts).HasColumnType("decimal(10,2)");
            builder.Property(p => p.BenefitPerPerson).HasColumnType("decimal(10,2)");
            builder.Property(p => p.ExtraCosts).HasColumnType("decimal(10,2)");
        }
    }

    public class TourDetailsConfig : IEntityTypeConfiguration<TourDetails>
    {
        public void Configure(EntityTypeBuilder<TourDetails> builder)
        {
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
        }

    }
}
