using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using MaiaNegocios.Domain.Models;

namespace MaiaNegocios.Repository.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("client");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.CpfUser).HasColumnName("cpf_user");
            builder.Property(c => c.FlagActive).HasColumnName("flag_active");
            builder.Property(c => c.DataInitial).HasColumnName("data_initial");
            builder.Property(c => c.DataRemove).HasColumnName("data_remove");

        }
    }
}
