using anti_scam_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Domain.Infrastructure.Configuration
{
    public class UserConfigEntities : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasData(
                new User()
                {
                    Id = Settings.UserId,
                    Email = "Trantienthanh2412@gmail.com",
                    IsActive = true,
                    JoinedDate = DateTimeOffset.UtcNow,
                    IsAdmin = true,
                    Password = "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==",
                    Salt = "pscznq",
                    UserName = "Admin",
                    CodeValidate = "123456",
                },
                new User()
                {
                    Id = Settings.UserIdAdmin,
                    Email = "antiscam.contact@gmail.comm",
                    IsActive = true,
                    JoinedDate = DateTimeOffset.UtcNow,
                    IsAdmin = true,
                    Password = "AQAAAAEAACcQAAAAEBAPlUdwTj0sci7gABciifU0cXR+sD/GUUtK99iAzlEcmqzuCE4Z8TflzHN9Nv6+KQ==",
                    Salt = "pscznq",
                    UserName = "Admin",
                    CodeValidate = "123456",
                });
        }


    }
}
