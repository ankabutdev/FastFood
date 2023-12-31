﻿using System;

namespace FastFood.Security;
public class Hashing
{
    public static (string PasswordHash, string salt) Hash(string password)
    {
        string salt = GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
        return (hash, salt);
    }

    public static string GenerateSalt() => Guid.NewGuid().ToString();

    public static bool Verify(string password, string passwordHash, string salt)
    {
        return BCrypt.Net.BCrypt.Verify(password + salt, passwordHash);
    }
}
