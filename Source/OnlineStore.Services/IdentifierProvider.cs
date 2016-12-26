﻿using System;
using System.Text;

namespace OnlineStore.Services
{
    public class IdentifierProvider : IIdentifierProvider
    {
        private const string Salt = ".123123123";
        public int DecodeId(string urlId)
        {
            var base64EncodedBytes = Convert.FromBase64String(urlId);
            var bytesAsString =  Encoding.UTF8
                                .GetString(base64EncodedBytes)
                                .Replace(Salt, string.Empty);

            return int.Parse(bytesAsString);
        }

        public string EncodeId(int id)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(id.ToString()+Salt);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
