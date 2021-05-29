using anti_scam_backend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Services
{
    public static class HashPasswordService
    {
        public static string HashPassword(User user, string password)
        {
            var hash = new PasswordHasher<User>();
            var newPass = hash.HashPassword(user, password);
            return newPass;
        }
        public static bool VerifyPassword(User user, string providedPw)
        {
            var hash = new PasswordHasher<User>();
            var verify = hash.VerifyHashedPassword(user, user.Password, providedPw + user.Salt);
            return verify == PasswordVerificationResult.Success;
        }

        public static bool VerifyPassword(User user, string password, string providedPw)
        {
            var hash = new PasswordHasher<User>();
            var verify = hash.VerifyHashedPassword(user, password, providedPw+user.Salt);
            return verify == PasswordVerificationResult.Success;
        }
    }
}
