using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using MaiaNegocios.Domain.Models;

namespace MaiaNegocios.Repository.EntityConfig
{
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable("plane");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FlagActive).HasColumnName("flag_active");
            builder.Property(c => c.DateInitial).HasColumnName("date_initial");
            builder.Property(c => c.DateRemove).HasColumnName("date_remove");
        }
    }
}
