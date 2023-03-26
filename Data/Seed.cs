using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingProject.Data;
using DatingProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data
{
    public class Seed
    {
        public static async Task SeedUsers (DataContext context)
        /* {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foreach (var user in JsonSerializer.Deserialize<List<AppUser>>(userData, options))
            {
                using var hmac = new System.Security.Cryptography.HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        } */
        {
        if (await context.Users.AnyAsync()) return;

        var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new DateOnlyConverter()); // Add the custom converter

        foreach (var user in JsonSerializer.Deserialize<List<AppUser>>(userData, options))
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
        }
        await context.SaveChangesAsync();
    }
    }
}