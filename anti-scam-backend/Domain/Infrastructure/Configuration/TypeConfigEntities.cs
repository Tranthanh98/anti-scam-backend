using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class TypeConfigEntities : IEntityTypeConfiguration<Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Entities.Type> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasData(
                new Entities.Type() { Id = 1, Name = "Trang web" },
                new Entities.Type() { Id = 2, Name = "Số tài khoản" },
                new Entities.Type() { Id = 3, Name = "Tài khoản MXH" },
                new Entities.Type() { Id = 4, Name = "Số điện thoại" }
                );
        }
    }
}
