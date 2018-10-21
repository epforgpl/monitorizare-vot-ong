﻿using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using MonitorizareVot.Ong.Api.Models;

namespace MonitorizareVot.Ong.Api.Services
{
    public class HashService : IHashService
    {
        public HashService(IOptions<HashOptions> options)
        {
            Salt = options.Value.Salt;
        }

        public string Salt { get; set; }
        public string GetHash(string clearString)
        {
            return clearString; // TODO take it down after we get hash workings

            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(clearString + Salt));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
