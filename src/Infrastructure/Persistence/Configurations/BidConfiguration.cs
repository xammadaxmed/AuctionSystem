﻿namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder
                .ToTable("Bids");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Amount)
                .IsRequired();

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .Property(p => p.ItemId);
        }
    }
}