using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using MaiaNegocios.Domain;

namespace MaiaNegocios.Repository.EntityConfig
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NamePt).HasColumnName("name_pt");
        }
    }
}
