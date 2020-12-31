using MaiaNegocios.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Repository.EntityConfig
{
    public class BancoMap : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("tb_banco");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ban_id");
            builder.Property(c => c.Nome).HasColumnName("ban_nome");
            builder.Property(c => c.Codigo).HasColumnName("ban_codigo");
            builder.Property(c => c.Status).HasColumnName("ban_status");


        }
    }
}
